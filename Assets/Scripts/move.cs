using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Sensor sensor;
    private Rigidbody2D rb;
    public Transform targetobj;
    Vector2 direction;
    public float speed;

    bool moved=false;
    public int dir;

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
        switch (dir)
        {
            case 1: direction = Vector2.up; break;
            case 2: direction = Vector2.right; break;
            case 3: direction = Vector2.down; break;
            case 4: direction = Vector2.left; break;
        }

        if (targetobj != null)
        {
            while (Vector2.Distance(transform.position, targetobj.position) > 0.01f)
            {
                Vector2 MovePos = Vector2.MoveTowards(rb.position, targetobj.position, speed * Time.fixedDeltaTime);
                rb.MovePosition(MovePos);
                yield return new WaitForFixedUpdate();
            }

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }

        else
        {
            while (true)
            {
                Vector2 uMove = rb.position + direction * speed * Time.fixedDeltaTime;
                rb.MovePosition(uMove);
                yield return new WaitForFixedUpdate();
            }
        }

        moved = true;
    }
}
