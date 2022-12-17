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
            Invoke("PlayAd", 3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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


}
