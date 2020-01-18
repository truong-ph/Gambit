using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{

    private Animator anim;
    private Rigidbody body;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.transform.Find("Dummy").GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    //moveCond reference: 0 Idle, 1 Jump, 2 Land, 3 Run, 4 Back, 5 Attack
    void Update()
    {
        //finds when to jump and land
        if (!onGround)
        {
            if (body.velocity.y > 0)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    //instant jump animation looks more choppy but is more efficient
                    anim.Play("Jump");
                    anim.SetInteger("moveCond", 1);
                }
            }
            //if falling, set to land
            if (body.velocity.y < 0)
            {
                anim.SetInteger("moveCond", 2);
            }
        }
        else
        {
            //finds when to start and stop running
            if (Input.GetKey(KeyCode.W))
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    anim.SetInteger("moveCond", 3);
                }
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("moveCond", 0);
            }

            //same code but for the backwards runing
            else if (Input.GetKey(KeyCode.S))
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Back"))
                {
                    anim.SetInteger("moveCond", 4);
                }
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetInteger("moveCond", 0);
            }

            //attack code
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    anim.SetInteger("moveCond", 5);
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                anim.SetInteger("moveCond", 0);
            }

            //sets idle animation after landing
            else
            {
                anim.SetInteger("moveCond", 0);
            }
        }
        
    }


    //finds when the player is on the ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

    //sets time counter
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = false;
        }
    }
}
