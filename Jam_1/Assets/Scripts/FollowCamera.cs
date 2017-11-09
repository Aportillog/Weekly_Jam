using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField]
    Vector3 defaultDistance = new Vector3(0f, 4f, -10f);
    [SerializeField]
    float distanceDamp = 0.15f;

    Transform myT;
    Transform target;
    Vector3 velocity = Vector3.one;

    void Awake()
    {
        myT = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        SmoothFollow();

    }


    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;

        myT.LookAt(target, target.up);
    }
}
