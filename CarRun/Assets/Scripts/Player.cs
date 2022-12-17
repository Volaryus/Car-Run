using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 moveVector;
    int speedBoost;
    AudioSource audioSource;
    public AudioClip moneyClip;
    public AudioClip speedUpClip;
    public AudioClip hitClip;
    Rigidbody rb;
    Money money;
    public float xLimit = 1.7f;
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 4f;
    public float slowSpeed = 1f;
    float moveX;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moveVector = Vector2.zero;
        rb = gameObject.GetComponent<Rigidbody>();
        money = gameObject.GetComponent<Money>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        moveX = Input.GetAxisRaw("Horizontal");
#else
Touch finger = Input.GetTouch(0);
 /*if (finger.deltaPosition.x > 25)
            {
                rb.velocity = Vector3.Lerp(transform.position, new Vector3(xLimit, 0, transform.position.z), horizontalSpeed * Time.deltaTime);
            }
            if (finger.deltaPosition.x < -25)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-xLimit, 0, transform.position.z), horizontalSpeed * Time.deltaTime);
            }*/

            if (finger.deltaPosition.x > 4)
            {
                moveX=finger.deltaPosition.x/10;
            }
            else if (finger.deltaPosition.x < -4)
            {
                moveX=finger.deltaPosition.x/10;
            }
        else
        {
            moveVector.x = moveX;
            moveVector = Vector2.Lerp(new Vector2(moveVector.x, 0), Vector2.zero, slowSpeed);
            moveX = moveVector.x;
        }
#endif
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit - 0.05f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit + 0.05f, transform.position.y, transform.position.z);
        }

        rb.velocity = new Vector3(moveX * horizontalSpeed, 0, forwardSpeed + speedBoost);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollisionObject>())
        {
            CollisionObject colObject = other.gameObject.GetComponent<CollisionObject>();
            if (colObject.type == CollisionObject.ObjectType.Money)
            {
                //Add money
                money.AddMoney(colObject.value);
                if (colObject.value > 0)
                {
                    audioSource.PlayOneShot(moneyClip);
                }
                Debug.Log("Money Added");
            }
            else if (colObject.type == CollisionObject.ObjectType.Gold)
            {
                //Add gold
                Debug.Log("Gold Added");
            }
            else if (colObject.type == CollisionObject.ObjectType.Speed)
            {
                speedBoost += colObject.value;
                if (colObject.value > 0)
                {
                    audioSource.PlayOneShot(speedUpClip);
                }
                else
                {
                    // audioSource.PlayOneShot(hitClip);
                }
                Debug.Log("Speed Added");
            }
            else if (colObject.type == CollisionObject.ObjectType.Obstacle)
            {
                speedBoost += colObject.value;
                audioSource.PlayOneShot(hitClip);
            }
        }
    }
}
