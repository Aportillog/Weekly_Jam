using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed = 50f;
    [SerializeField]
    float sideThursterSpeed = 5f;
    [SerializeField]
    float turnSpeed = 60f; 

    Transform myT;

    void Awake()
    {
        myT = transform;
    }
    void Update()
    {
        Thrust();
        Turn();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Yaw");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch,yaw,-roll);
    }


    void Thrust()
    {
        //Forward
        if(Input.GetAxis("Vertical") > 0)
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        //Side
        myT.position += myT.right * sideThursterSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

    }
}
