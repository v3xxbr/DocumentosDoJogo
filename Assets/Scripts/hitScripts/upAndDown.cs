using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDown : MonoBehaviour
{
    [Header("Desires")]
    Vector2 desiredPos;
    [SerializeField] float desiredHeight=2;

    float time = 0;
    public float desiredTime=0.75f;
    
    bool started;
    [SerializeField] float speedMove=2f;
    float initialY;


    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        desiredPos = new Vector2(transform.position.x, desiredHeight);
        //StartCoroutine(moveNow());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= desiredTime)
        {
            if (!started)
            {
                StartCoroutine(moveNow());
            }
        }
    }


    IEnumerator moveNow()
    {
        started = true;
        desiredPos = new Vector2(transform.position.x, initialY+desiredHeight);
        while (Vector2.Distance(transform.position, desiredPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, desiredPos, speedMove * Time.deltaTime);

            if(Vector2.Distance(transform.position, desiredPos) < 0.01f)
            {
                desiredPos = new Vector2(transform.position.x, initialY);
            }

            yield return null;
        }
        started = false;
    }
}
