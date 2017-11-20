using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public float rotationOffset = 50f;
    public bool rotationFlag = true;

    Vector3 randRotation;
    Transform myT;
    bool isPicked = false;

    void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        CalculateRotation();
    }

    void Update()
    {
        FoodRotation();
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerCollision(other);
    }

    void OnCollisionEnter(Collision col)
    {
        //Avoid collision if the collider object is Player or food and is not already picked
        if(((col.gameObject.tag == "Player") || (col.gameObject.tag == "Food")) && !isPicked)
        {
            Debug.Log(this.name + " colliding with " + col.gameObject.name);
            Physics.IgnoreCollision(col.collider, this.GetComponent<Collider>());
        }
        //Otherwise: do stuff
        else
        {
            StopperCollision(col);
        }
        
    }

    void CalculateRotation()
    {
        randRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    void FoodRotation()
    {
        if (rotationFlag)
        {
            myT.Rotate(randRotation * Time.deltaTime);
        }
        
    }

    void PlayerCollision(Collider player)
    {
        if(player.tag == "Player")
        {
            //Player's head collision
            if(player.GetType().ToString() == "UnityEngine.SphereCollider")
            {
                //Set isPicked true
                isPicked = true;
                //Set player as parent
                this.transform.parent = player.transform;
                //Set rotation off
                rotationFlag = false;
                //Set isTrigger property off (to collide with player bottom and other food)
                GetComponent<Collider>().isTrigger = false;
            }
        }
    }

    void StopperCollision(Collision col)
    {
        if (isPicked)
        {
            if (col.gameObject.tag == "Player")
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        
    }
}
