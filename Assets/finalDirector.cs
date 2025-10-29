using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDirector : MonoBehaviour
{
    [SerializeField]GameObject target;
    public float speed;
    private GameObject player, spin;
    public GameObject thanksText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spin = GameObject.FindGameObjectWithTag("Hit");
        StartCoroutine(finalCustcene());
    }

    IEnumerator finalCustcene()
    {
        Vector2 targetPos = target.transform.position;

        yield return new WaitForSeconds(0.9f);
        while (Mathf.Abs(player.transform.position.x - targetPos.x) > 0.05f)
        {
            //Math Sign = 1 ou -1
            float direction = Mathf.Sign(targetPos.x - player.transform.position.x);
            player.GetComponent<Player>().moveInput = new Vector2(direction, 0);
            yield return new WaitForFixedUpdate();
        }
        player.GetComponent<Player>().moveInput = Vector2.zero;
        Destroy(player);

        yield return new WaitForSeconds(0.4f);
        StartCoroutine(goToTarget(spin, targetPos));
    }

    IEnumerator goToTarget(GameObject a, Vector2 target)
    {
        Rigidbody2D aRbb = a.GetComponent<Rigidbody2D>();

        while (Mathf.Abs(aRbb.position.x - target.x) > 0.05f)
        {
            //Math Sign = 1 ou -1
            float posX = Mathf.Sign(target.x - aRbb.position.x);
            aRbb.velocity = new Vector2(posX * speed, aRbb.velocity.y);

            yield return new WaitForFixedUpdate();
        }

        aRbb.velocity = Vector2.zero;
        Destroy(a);

        //rodar animação do texto
        Animator textAnim = thanksText.GetComponent<Animator>();
        yield return new WaitForSeconds(0.2f);
        textAnim.SetTrigger("textTrigger");
        yield return new WaitForSeconds(textAnim.GetCurrentAnimatorStateInfo(0).length);
        thanksText.GetComponent<CanvasGroup>().alpha = 1f;
    }
}
