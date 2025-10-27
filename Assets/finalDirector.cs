using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDirector : MonoBehaviour
{
    [SerializeField]GameObject target;
    public float speed;
    private GameObject player, spin;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spin = GameObject.FindGameObjectWithTag("Hit");
        StartCoroutine(finalCustcene());
    }

    IEnumerator finalCustcene()
    {
        Rigidbody2D playerRbb = player.GetComponent<Rigidbody2D>();
        Rigidbody2D spinRbb = spin.GetComponent<Rigidbody2D>();

        Vector2 targetPos = target.transform.position;
        yield return new WaitForSeconds(0.9f);

        while(Vector2.Distance(playerRbb.position, targetPos) > 0.05f)
        {
            Vector2 desiredPos = Vector2.MoveTowards(playerRbb.position, targetPos, speed * Time.fixedDeltaTime);
            playerRbb.MovePosition(desiredPos);
            yield return new WaitForFixedUpdate();
        }
        Destroy(player);

        yield return new WaitForSeconds(0.4f);

        while (Vector2.Distance(spinRbb.position, targetPos) > 0.05f)
        {
            Debug.Log(spinRbb.position);
            Vector2 desiredPos = Vector2.MoveTowards(spinRbb.position, targetPos, speed * Time.fixedDeltaTime);
            spinRbb.MovePosition(desiredPos);
            yield return new WaitForFixedUpdate();
        }
        Destroy(spin);
        spin = null;
    }
}
