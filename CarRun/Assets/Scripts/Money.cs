using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    Player player;
    int money;
    int count = 0;
    public int[] carPrice;
    public float[] speeds;
    public GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money >= carPrice[count])
        {
            money -= carPrice[count];
            cars[count].SetActive(false);
            count++;
            player.forwardSpeed = speeds[count];
            cars[count].SetActive(true);
        }
    }

    public void DecreaseMoney(int amount)
    {
        money -= amount;
        if (money < 0)
        {
            if (count == 0)
            {
                //Kill the player
                return;
            }
            else
            {
                cars[count].SetActive(false);
                count--;
                player.forwardSpeed = speeds[count];
                cars[count].SetActive(true);
            }
        }
    }
}
