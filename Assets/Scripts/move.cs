using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Sensor sensor;
    private Rigidbody2D rb;
    public Transform targetobj;
    public float speed;

    bool moved=false;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        rb = GetComponent<Rigidbody2D>();
        sensor = GetComponent<Sensor>();

        if (sensor == null)
            sensor = GetComponentInChildren<Sensor>();

        sensor.detection += startMove;
    }

    void startMove()
    {
        if (!moved)
          StartCoroutine(moving());
    }

    IEnumerator moving()
    {
        switch (direction)
        {
            case 1: rb.AddForce(Vector2.up * Time.deltaTime, ForceMode2D.Force); break;
            case 2: rb.AddForce(Vector2.right * Time.deltaTime, ForceMode2D.Force); break;
            case 3: rb.AddForce(Vector2.down * Time.deltaTime, ForceMode2D.Force); break;
            case 4: rb.AddForce(Vector2.left * Time.deltaTime, ForceMode2D.Force); break;
        }

        if (targetobj != null)
        {
            while (Vector2.Distance(transform.position, targetobj.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetobj.position, speed * Time.deltaTime);
                yield return null;
            }
        }

        moved = true;
    }
}
