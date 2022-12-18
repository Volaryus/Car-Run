using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    bool stopTime = true;
    public GameObject startPanel;
    private void Awake()
    {
        if(stopTime)
        {
            Time.timeScale = 0;
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

    public void StartLevel()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }
}
