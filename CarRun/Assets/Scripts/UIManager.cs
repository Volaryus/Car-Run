using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    bool stopTime = true;
    [SerializeField]
    Player player;
    public GameObject startPanel;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (stopTime)
        {
            player.enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            StartLevel();
        }
    }

    public void StartLevel()
    {
        player.enabled = true;
        startPanel.SetActive(false);
        this.enabled = false;
    }
}
