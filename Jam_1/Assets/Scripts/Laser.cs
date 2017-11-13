using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {
    [SerializeField]
    float laserOffTime = 0.5f;
    [SerializeField]
    float maxDist = 300f;

    LineRenderer lr;
    bool canFire;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Start()
    {
        lr.enabled = false;
    }

    void Update()
    {
        FireLaser(transform.forward * maxDist);
    }

    public void FireLaser(Vector3 targetPos)
    {

        if (canFire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPos);
            lr.enabled = true;

            canFire = false;
        }        

        Invoke("TurnOffLaser", laserOffTime);
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        canFire = true;
    }

}
