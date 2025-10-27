using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickSand : MonoBehaviour
{
    public float sandSpeed = 3f;
    bool isRising;

    [SerializeField]float heighttPlayer=1f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        RisingAndStop();
    }

    void RisingAndStop()
    {
        if ((player.transform.position.y + heighttPlayer) > (transform.position.y + transform.localScale.y))
        {
            Vector3 yscale = transform.localScale;
            yscale.y += sandSpeed * Time.deltaTime;
            transform.localScale = yscale;
        }

        else
        {
            if (Player.currentStage != Player.stages.Dead)
                Player.currentStage = Player.stages.Dead;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player.speed = 2.5f;
        }
    }
}
