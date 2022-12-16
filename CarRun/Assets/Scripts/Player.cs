using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Money money;
    public float xLimit = 1.7f;
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 4f;
    float moveX;
    // Start is called before the first frame update
    void Start()
    {
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
                moveX=finger.deltaPosition.x/5;
            }
            else if (finger.deltaPosition.x < -4)
            {
                moveX=finger.deltaPosition.x/5;
            }
            else
            {
                moveX=0;
            }


#endif
        rb.velocity = new Vector3(moveX * horizontalSpeed, 0, forwardSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollisionObject>())
        {
            if (other.gameObject.GetComponent<CollisionObject>().type == CollisionObject.ObjectType.Money)
            {
                //Add money
                money.AddMoney(other.gameObject.GetComponent<CollisionObject>().value);
                Debug.Log("Money Added");
            }
            else if (other.gameObject.GetComponent<CollisionObject>().type == CollisionObject.ObjectType.Gold)
            {
                //Add gold
                Debug.Log("Gold Added");
            }
            else if (other.gameObject.GetComponent<CollisionObject>().type == CollisionObject.ObjectType.Speed)
            {
                //Increase speed
                Debug.Log("Speed Added");
            }
        }
    }
}
