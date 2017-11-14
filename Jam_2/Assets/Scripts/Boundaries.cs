using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        //Destroy everything that enter the trigger
        Destroy(other.gameObject);
    }
}
