using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [Header("Objects")]
    public GameObject localDeSpawn;
    GameObject summonedHit;
    public GameObject hitObject;

    [Header("Logical Vars")]
    public float timeFakeSpawn = 0.6f;
    bool alredySpawned;
    public bool isFake;

    public enum staged
    {
        nonSpawned,
        alredySpawned
    }

    staged currentStage;

    private Sensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<Sensor>();
        sensor.detection += Spawn;
    }


    void Spawn()
    {
        if (currentStage == staged.nonSpawned)
        {
            summonedHit = Instantiate(hitObject, localDeSpawn.transform.position, Quaternion.identity);
            summonedHit.SetActive(true);

            if (isFake)
            {
                StartCoroutine(fakeSpawn());
            }

            currentStage = staged.alredySpawned;
        }
    }

    IEnumerator fakeSpawn()
    {
        yield return new WaitForSeconds(timeFakeSpawn);
        summonedHit.SetActive(false);
    }
}
