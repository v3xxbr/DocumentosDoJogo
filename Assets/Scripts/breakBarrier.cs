using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakBarrier : MonoBehaviour
{
    public GameObject[] breaker;
    public int n=0;
    bool fall;

    private void FixedUpdate()
    {
        startFall();
    }

    void startFall()
    {
        if(n >= breaker.Length && !fall)
        {
            StartCoroutine(Falling());
        }
    }

    IEnumerator Falling()
    {
        fall = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().gravityScale = 2f;

        yield return new WaitForSeconds(1.1f);
        gameObject.layer = LayerMask.NameToLayer("Ground");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        for(int h=0; h<breaker.Length; ++h)
        {
            if (other.gameObject == breaker[h])
            {
                if (breaker.Length > n)
                    ++n;
            }
        }
    }
}
