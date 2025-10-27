using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sensor : MonoBehaviour
{
    [Header("Vectors")]
    Vector2 posicao;
    Vector2 tamanho;

    public float sensorWidth = 1f;
    public float sensorHeight = 1f;

    LayerMask playerLayer;

    public event Action detection;

    // Start is called before the first frame update
    void Start()
    {
        playerLayer = LayerMask.GetMask("playerLayer");
    }

    // Update is called once per frame
    void Update()
    {
        posicao = (Vector2)transform.position + Vector2.up * sensorHeight;
        tamanho = new Vector2(sensorWidth, sensorHeight);

        Collider2D sensor = Physics2D.OverlapBox(posicao, tamanho, 0f, playerLayer);

        if (sensor != null)
        {
            if(detection != null)
            {
                detection.Invoke();
            }
        }
    }

    private void OnDrawGizmos()
    {
        posicao = (Vector2)transform.position + Vector2.up * sensorHeight;
        tamanho = new Vector2(sensorWidth, sensorHeight);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(posicao, tamanho);
    }
}
