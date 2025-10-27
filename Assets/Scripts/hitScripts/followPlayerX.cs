using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerX : MonoBehaviour
{
    //private Sensor sensor;
    //private Rigidbody2D rb;
    //bool moving;

    //GameObject EndLevel;
    //public GameObject target;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    sensor = GetComponent<Sensor>();

    //    sensor.detection += movingHit;
    //}

    //void movingHit()
    //{
    //    if (!moving)
    //    {
    //        StartCoroutine(changingEL());
    //    }
    //    moving = true;
    //}

    //IEnumerator changingEL()
    //{
    //    while (EndLevel.transform.position.x - target.transform.position.x > 0.1f)
    //    {
    //        EndLevel.transform.position = Vector2.MoveTowards(EndLevel.transform.position, target.transform.position, 5f * Time.deltaTime);
    //        yield return null;
    //    }

    //    yield return new WaitForSeconds(0.7f);
    //    EndLevel.GetComponent<BoxCollider2D>().enabled = true;
    //}
}
