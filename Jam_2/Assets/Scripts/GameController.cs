using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject food;
    public Vector3 spawnValues;
    public int foodCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float rotationOffset = 50f;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for(int i = 0; i < foodCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = new Quaternion(Random.Range(-rotationOffset, rotationOffset),
                                                          Random.Range(-rotationOffset, rotationOffset),
                                                          Random.Range(-rotationOffset, rotationOffset),
                                                          Random.Range(-rotationOffset, rotationOffset));
                Instantiate(food, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
