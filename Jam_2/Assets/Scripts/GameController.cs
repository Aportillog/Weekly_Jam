﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject foodContainer;
    public GameObject foodContainerModel;
    public GameObject playerModel;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float gravity = 0.5f;
    public float spawnLimit_x_max = 2;
    public float spawnLimit_x_min =-5;
    public int level = 0;
    public bool levelPassed = false;
    public Text LevelText;
    public Vector3 targetPosition;

    int foodCount = 0;
    

    void Start()
    {
        levelPassed = false;
        LevelText.text = "0";
        TargetGenerator();
        ChangeGravity();
        StartCoroutine(SpawnWaves());

    }

    void Update()
    {
    }

    //Waves spawner
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            while (!levelPassed)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnLimit_x_min, spawnLimit_x_max), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(foodContainer.transform.GetChild(Random.Range(0, foodContainer.transform.childCount)), spawnPosition, spawnRotation);
                foodCount += 1;
                yield return new WaitForSeconds(spawnWait);
            }
            LevelUp();

            yield return new WaitForSeconds(waveWait);
        }
    }

    void ChangeGravity()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);
    }

    void LevelUp()
    {
        level += 1;
        levelPassed = false;
        //Update level marker
        LevelText.text = level.ToString();
        //Gravity increments with level
        gravity += 0.1f;
        ChangeGravity();
        //SpawnWait decrements with level
        spawnWait -= 0.1f;
    }

    void TargetGenerator()
    {
        //Create skewer
        Instantiate(playerModel, targetPosition, Quaternion.identity);
        //Create Food
        for (int i = 0; i < 5; i++)
        {
            Quaternion randRot = new Quaternion(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1), 0);
            Instantiate(foodContainerModel.transform.GetChild(Random.Range(0, foodContainerModel.transform.childCount)), targetPosition + new Vector3(0, i*0.42f, 0), randRot);
        }
    }
}
