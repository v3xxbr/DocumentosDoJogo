using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private moveSensor mvSensor;
    GameObject player;
    bool isFollowing;

    [Header("Movement")]
    [SerializeField] float speed = 6f;
    public GameObject[] targets;
    int i=0;

    GameObject currentTarget;
    public GameObject terminatorObject;

    // Start is called before the first frame update
    void Start()
    {
        //changeTarget();
        player = GameObject.FindGameObjectWithTag("Player");
        mvSensor = GetComponent<moveSensor>();

        if (mvSensor == null)
            mvSensor = GetComponentInChildren<moveSensor>();
    }

    void changeTarget()
    {
        if(i<=targets.Length)
            currentTarget = targets[i];

        if (currentTarget == targets[targets.Length - 1])
            speed *= 10;
        
    }

    // Update is called once per frame
    void StartFollow()
    {
        if(!isFollowing)
            StartCoroutine(Follow());
    }

    IEnumerator Follow()
    {
        isFollowing = true;
        while (Vector3.Distance(transform.position, currentTarget.transform.position) >= 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentTarget.transform.position) < 0.01f)
            {
                ++i;
                changeTarget();

                while(transform.position.y > currentTarget.transform.position.y)
                {
                    Vector3 followPos = new Vector3(transform.position.x, currentTarget.transform.position.y, 0);
                    transform.position = Vector3.MoveTowards(transform.position, followPos, speed * Time.deltaTime);

                    yield return null;
                }
            }

            yield return null;
        }
        isFollowing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (terminatorObject != null && collision.gameObject == terminatorObject)
        {
            Destroy(gameObject);
        }
    }
}
