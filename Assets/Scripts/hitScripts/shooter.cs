using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectile;
    public Transform shootingArea;
    public int direction;

    public button buttonz;

    [SerializeField]float speed;
    [SerializeField] float time;
    bool itsHappening=false;
    [SerializeField]Transform finalPos;

    // Start is called before the first frame update
    void Start()
    {
        StartShooting();

        if(buttonz==null)
            buttonz = GetComponentInChildren<button>();

        buttonz.pressed += StopShooting;
    }

    void StartShooting()
    {
        if(!itsHappening)
            StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (buttonz.itHappened == false)
        {
            yield return new WaitForSeconds(time);
            GameObject projectileNow = Instantiate(projectile, shootingArea.position, Quaternion.identity);

            switch (direction)
            {
                case 2: projectileNow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed, ForceMode2D.Impulse); break;
                case 4: projectileNow.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed, ForceMode2D.Impulse); break;
            }

            Destroy(projectileNow, 3f);
        }
    }

    void StopShooting()
    {
        StartCoroutine(Down());
    }

    IEnumerator Down()
    {
        while (true)
        {
            Vector2 posicao = transform.position;
            posicao.y = Mathf.MoveTowards(posicao.y, finalPos.position.y, speed * Time.deltaTime);
            transform.position = posicao;

            if (Mathf.Abs(posicao.y - finalPos.position.y) < 0.05f) break;
            yield return null;
        }
    }
}