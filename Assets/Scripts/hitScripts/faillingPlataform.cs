using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faillingPlataform : MonoBehaviour
{
    [Header("Atribbutes")]
    public float speedFall = 0.1f;
    public float forceFall = 10f;

    public GameObject realPlataform;
    Vector3 initialPos;

    [SerializeField]float destructionTime=0.4f;
    private Sensor sensor;

    [Header("Componnents")]
    Rigidbody2D rbb;
    BoxCollider2D boxc;

    public bool isFake;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<Sensor>();

        if (sensor == null)
            sensor = GetComponentInChildren<Sensor>();

        initialPos = transform.position;

        //componnents
        rbb = GetComponent<Rigidbody2D>();
        boxc = GetComponent<BoxCollider2D>();

        sensor.detection += StartFall;
    }

    void StartFall()
    {
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        rbb.bodyType = RigidbodyType2D.Dynamic;
        rbb.gravityScale = 6f;
        rbb.AddForce(Vector2.down * forceFall, ForceMode2D.Impulse);

       yield return new WaitForSeconds(destructionTime);

       if (isFake)
       {
          GameObject instanciadeObj = Instantiate(realPlataform, initialPos, Quaternion.identity);
       }
       
       boxc.isTrigger = true;
    }
}
