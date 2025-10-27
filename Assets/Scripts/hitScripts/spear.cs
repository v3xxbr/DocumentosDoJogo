using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    public Sensor sensor;
    public Transform tt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sensor.detection += startExpand;
    }

    void startExpand()
    {
        StartCoroutine(Expand());
    }

    IEnumerator Expand()
    {
        while ((transform.position.x - transform.localScale.x) > tt.position.x)
        {
            Vector3 newScale = transform.localScale;
            newScale.x += speed * Time.deltaTime;
            transform.localScale = newScale;
            yield return null;
        }
    }
}
