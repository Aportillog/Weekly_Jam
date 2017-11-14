using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public float rotationOffset = 50f;

    Vector3 randRotation;
    Transform myT;

    void Awake()
    {
        myT = transform;
    }

    void Start()
    {
    }

    void Update()
    {
        randRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randRotation.z = Random.Range(-rotationOffset, rotationOffset);
        myT.Rotate(randRotation * Time.deltaTime);
    }
}
