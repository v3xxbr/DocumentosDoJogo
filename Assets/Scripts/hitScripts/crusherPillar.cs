using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crusherPillar : MonoBehaviour
{
    [Header("Componnents")]
    private Sensor sensor;
    Rigidbody2D rbHead;
    public int height;
    bool isGrowing;

    [Header("Positions")]
    Vector3 originalPos;
    public GameObject finalPos;
    public GameObject head;

    bool isActive;
    [SerializeField]float speedOfSmash=7f;

    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<Sensor>();
        rbHead = head.GetComponent<Rigidbody2D>();
        originalPos = rbHead.position;

        sensor.detection += Smash;
    }

    void Smash()
    {
        if (!isGrowing)
        {
            StartCoroutine(Grow());
        }
    }

    IEnumerator Grow()
    {
        isGrowing = true;

        head.tag = "Hit";
        //primeiro pegamos o valor da posição local do objeto, depois somamos seu y com o valor da velocidade de crescimento de modo lento (por meio do Time.deltaTime)
        while (Vector2.Distance(rbHead.position, finalPos.transform.position) > 0.01f)
        {
            Vector3 goPos = Vector3.MoveTowards(rbHead.position, finalPos.transform.position, speedOfSmash * Time.deltaTime);
            rbHead.MovePosition(goPos);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(2.3f);

        //retorna a posição inicial
        while (Vector2.Distance(rbHead.position, originalPos) > 0.01f)
        {
            Vector3 backPos = Vector3.MoveTowards(rbHead.position, originalPos, speedOfSmash * Time.deltaTime);
            rbHead.MovePosition(backPos);
            yield return new WaitForFixedUpdate();
        }

        head.layer = LayerMask.NameToLayer("Ground");
    }
}
