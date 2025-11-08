using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkSpin : MonoBehaviour
{
    [Header("Componnents")]
    public float speed=2f;
    public Sensor stckSensor;

    bool isRunning=false;
    [SerializeField]float smallOffside=0.2f;

    [Header("Targets")]
    public GameObject[] targets;
    public Transform endLevelfinalPos;
    int j;

    // Start is called before the first frame update
    void Start()
    {
        j = 0;
        stckSensor.detection += startRun;
    }


    private void Update()
    {

    }

    void startRun()
    {
        if (!isRunning)
            StartCoroutine(Running());
    }

    IEnumerator Running()
    {
        isRunning = true;
        Rigidbody2D rbb = GetComponent<Rigidbody2D>();
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

        if(j+1 < targets.Length)
        {
            Vector3 sensorDesiredPos = new Vector3((targets[j].transform.position.x + targets[j + 1].transform.position.x) / 2, stckSensor.transform.position.y, 0);
            stckSensor.transform.position = sensorDesiredPos;
        }

        Debug.Log("Animação de Levantando");
        yield return new WaitForSeconds(1f);

        transform.position += new Vector3(0f, smallOffside, 0f);

        gameObject.GetComponent<Animator>().SetBool("Run", true);

        while (Vector2.Distance(targets[j].transform.position,transform.position) > 0.05f)
        {
            rbb.MovePosition(Vector2.MoveTowards(rbb.position, targets[j].transform.position, speed * Time.fixedDeltaTime));
            float direction = Mathf.Sign(targets[j].transform.position.x - rbb.position.x);
            if (direction != 0)
                spr.flipX = direction > 0;

            yield return new WaitForFixedUpdate();
        }

        gameObject.GetComponent<Animator>().SetBool("Run", false);
        transform.position -= new Vector3(0f, smallOffside, 0f);

        if (j < targets.Length-1)
            ++j;

        else
        {
            GameObject EndLevel = GameObject.FindGameObjectWithTag("EndLevel");

            while(Vector2.Distance(endLevelfinalPos.position, EndLevel.transform.position) > 0.05f)
            {
                Vector3 desiredPos = new Vector3(EndLevel.transform.position.x, endLevelfinalPos.position.y);
                EndLevel.transform.position = Vector3.MoveTowards(EndLevel.transform.position, desiredPos, speed*Time.deltaTime);
                yield return null;
            }
        }
        isRunning = false;
    }
}