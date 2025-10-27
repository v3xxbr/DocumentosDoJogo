using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSpin : MonoBehaviour
{
    public float speed=2f;
    public Sensor stckSensor;
    bool isRunning=false;
    public GameObject[] targets;
    int j;

    // Start is called before the first frame update
    void Start()
    {
        j = 0;
        stckSensor.detection += startRun;
    }

    // Update is called once per frame
    void startRun()
    {
        if (!isRunning)
            StartCoroutine(Running());
    }

    IEnumerator Running()
    {
        isRunning = true;

        if(j+1 < targets.Length)
        {
            Vector3 sensorDesiredPos = new Vector3((targets[j].transform.position.x + targets[j + 1].transform.position.x) / 2, stckSensor.transform.position.y, 0);
            stckSensor.transform.position = sensorDesiredPos;
        }

        Debug.Log("Animação de Levantando");
        yield return new WaitForSeconds(1f);

        while (Vector2.Distance(targets[j].transform.position,transform.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[j].transform.position, speed * Time.deltaTime);
            yield return null;
        }

        if (j < targets.Length-1)
            ++j;

        else
        {
            GameObject EndLevel = GameObject.FindGameObjectWithTag("EndLevel");

            EndLevel.GetComponent<BoxCollider2D>().isTrigger = false;
            EndLevel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            EndLevel.GetComponent<Rigidbody2D>().gravityScale = 1f;
            yield return new WaitForSeconds(2.5f);
            EndLevel.GetComponent<BoxCollider2D>().isTrigger = true;
            EndLevel.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            yield break;
        }

        isRunning = false;
    }
}