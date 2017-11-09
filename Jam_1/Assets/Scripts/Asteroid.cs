using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    [SerializeField]
    float minScale = 0.8f;
    [SerializeField]
    float maxScale = 1.2f;
    [SerializeField]
    float rotationOffset = 50f;

    Transform myT;
    Vector3 randRotation;

    void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        //Random Size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale) * myT.localScale.x;
        scale.y = Random.Range(minScale, maxScale) * myT.localScale.y;
        scale.z = Random.Range(minScale, maxScale) * myT.localScale.z;

        myT.localScale = scale;

        //Random Rotation
        randRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }
	void Update()
    {
        myT.Rotate(randRotation * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }

}
