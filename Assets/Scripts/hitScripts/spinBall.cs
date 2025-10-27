using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinBall : MonoBehaviour
{
    [SerializeField]float initialRotPos;
    float counter;
    int parts=1;

    [Header("Float VARs")]
    public float timeRotation;
    public float velocity=2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,0,initialRotPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.fixedDeltaTime;

        if (counter > timeRotation)
        {
            ++parts;
            parts %= 4;
            counter = 0;
        }

        switch (parts)
        {
            case 0:
                transform.Rotate(0, 0, velocity * (timeRotation-counter)); break;
            case 1:
                transform.Rotate(0, 0, -velocity * counter); break;
            case 2:
                transform.Rotate(0, 0, -velocity * (timeRotation - counter)); break;
            case 3:
                transform.Rotate(0, 0, velocity * counter); break;
        }

        Debug.Log(parts);
    }
}
