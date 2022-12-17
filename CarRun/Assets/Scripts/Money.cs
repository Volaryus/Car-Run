using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    public float textTime = 1f;
    float timer;
    public TMP_Text valueText;
    public TMP_Text moneyText;
    Player player;
    int money;
    int showMoney;
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
        if(timer<=0)
        {
            moneyText.text = "";
            timer = 100f;
        }
        timer -= Time.deltaTime;
        
    }

    public void AddMoney(int amount)
    {
        if (amount < 0)
        {
            DecreaseMoney(amount);
            return;
        }

        money += amount;
        showMoney += amount;
        valueText.text = showMoney + "K";
        moneyText.color = Color.green;
        moneyText.text = amount + "K";
        timer = textTime;
        Invoke("ResetText", 1f);
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
        showMoney -= amount;
        moneyText.color = Color.red;
        moneyText.text = amount + "K";
        timer = textTime;
        if (showMoney < 0)
        {
            showMoney = 0;
        }
        valueText.text = showMoney + "K";
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

    void ResetText()
    {
        moneyText.text = "";
    }
}
