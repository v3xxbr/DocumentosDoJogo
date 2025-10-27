using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectile;
    public Transform shootingArea;
    public int direction;

    private button buttonz;

    [SerializeField]float speed;
    [SerializeField] float time;
    bool itsHappening=false;

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
        itsHappening = true;

        while (itsHappening)
        {
            yield return new WaitForSeconds(time);
            GameObject projectileNow = Instantiate(projectile, shootingArea.position, Quaternion.identity);

            switch (direction)
            {
                case 2: projectileNow.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed, ForceMode2D.Impulse); break;
                case 4: projectileNow.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed, ForceMode2D.Impulse); break;
            }

            Destroy(projectileNow, 2f);
        }
    }

    void StopShooting()
    {
        itsHappening = false;
        GetComponent<shooter>().enabled = false;
    }
}
