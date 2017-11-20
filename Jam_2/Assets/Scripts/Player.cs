using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 origPosition;
    private Collider m_Collider;

    public float speed = 5f;
    public float skewerRange = 0.5f;
    public float originalHeight = -1f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Collider = GetComponent<SphereCollider>();
        m_Collider.enabled = false;
    }

    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"));

        Shoot();
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        FoodCollision(other);
    }

    void Move(float horizInput)
    {
        Vector3 moveVelocity = rb.velocity;
        moveVelocity.x = horizInput * speed;
        rb.velocity = moveVelocity;
    }

    void Shoot()
    {
        origPosition.x = transform.position.x;
        origPosition.y = originalHeight;
        origPosition.z = transform.position.z;
        if (Input.GetButton("Fire1"))
        {
            rb.MovePosition(origPosition + new Vector3(0, skewerRange, 0));
            m_Collider.enabled = true;

        }
        else
        {
            rb.MovePosition(origPosition);
            m_Collider.enabled = false;
        }
            


    }

    void FoodCollision(Collider food)
    {
        
    }
}
