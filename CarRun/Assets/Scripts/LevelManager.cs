using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public AdsManager adsManager;
    public GameObject[] levelEffects;
    int maxLevel = 1;
    private void Awake()
    {
        maxLevel = PlayerPrefs.GetInt("Level");
        if (maxLevel == 0)
        {
            maxLevel = 1;
            adsManager = gameObject.GetComponent<AdsManager>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            maxLevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("level", maxLevel);
            foreach (GameObject item in levelEffects)
            {
                item.SetActive(true);
            }
            //Show effects like fireworks
            //Play level end sound
            //other.gameObject.GetComponent<Player>().forwardSpeed = 0;
            other.gameObject.GetComponent<Player>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (SceneManager.GetActiveScene().buildIndex % 3 == 2)
            {
                Invoke("PlayAd", 3f);
            }
            Invoke("LoadNextLevel", 3f);
        }
    }

    void PlayAd()
    {
        adsManager.PlayAd();
    }
    public void LoadLatestLevel()
    {
        SceneManager.LoadScene(maxLevel);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
