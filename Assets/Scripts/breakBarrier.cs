using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakBarrier : MonoBehaviour
{
    public GameObject[] breaker;
    public int n=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Falling();
    }

    void Falling()
    {
        if(n >= breaker.Length)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GetComponent<Rigidbody2D>().gravityScale = 2f;
        }
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
