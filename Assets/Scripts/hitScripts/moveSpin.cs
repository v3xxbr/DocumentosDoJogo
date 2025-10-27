using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpin : MonoBehaviour
{
    private Sensor sensor;
    private Rigidbody2D rb;

    bool changing;
    GameObject EndLevel;
    public GameObject target;
    public GameObject plataformAfter;

    // Start is called before the first frame update
    void Start()
    {
        plataformAfter.SetActive(false);
        EndLevel = GameObject.FindGameObjectWithTag("EndLevel");
        sensor = GetComponent<Sensor>();

        sensor.detection += movingHit;
    }

    void movingHit()
    {
        if (!changing)
        {
            StartCoroutine(changingEL());
        }
        changing = true;
    }

    IEnumerator changingEL()
    {
        EndLevel.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.2f);
        while (EndLevel.transform.position.x - target.transform.position.x > 0.1f)
        {
            EndLevel.transform.position = Vector2.MoveTowards(EndLevel.transform.position, target.transform.position, 5f * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.7f);
        EndLevel.GetComponent<BoxCollider2D>().enabled = true;

        plataformAfter.SetActive(true);
    }
}