using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject objectGO;
    public GameObject plantGO;

    public bool isBuilding;
    public bool objectsCanMove; //Enable moving in all objects when instantiated

    private GameObject clone;

	// Use this for initialization
	void Start () {

        //Make GameController inmortal
        DontDestroyOnLoad(this);

        //Initialize variables
        isBuilding = false;
	}

    void Update()
    {
        if(isBuilding)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                isBuilding = false;
            }
        }
    }

    public void BuildObject()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            clone = Instantiate(objectGO, GetMousePosition(), Quaternion.identity);
            //Set Move ability for all the objects
            clone.SendMessage("SetCanMove", objectsCanMove);
        }
    }

    public void PlantObject()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            clone = Instantiate(plantGO, GetMousePosition(), Quaternion.identity);
            //Set Move ability for all the objects
            clone.SendMessage("SetCanMove", objectsCanMove);
        }
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
