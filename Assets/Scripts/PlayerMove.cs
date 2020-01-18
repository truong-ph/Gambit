using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float rotateSpeed = 150.0f;
    public float translateSpeed = 10.0f;
    public float jumpSpeed = 200.0f;
    private Rigidbody body;
    private bool onGround = true;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input axis
        float translate = Input.GetAxis("Vertical") * translateSpeed;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed;

        //set to movement per second
        translate *= Time.deltaTime;
        rotate *= Time.deltaTime;

        transform.Translate(0, 0, translate, Space.Self);
        transform.Rotate(0, rotate, 0, Space.Self);

        //jump key sent to fixedUpdate
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

    }

    
    void FixedUpdate()
    {
        //jump mechanic
        if (jump && onGround)
        {
            body.AddForce(0, jumpSpeed * Time.deltaTime, 0, ForceMode.Impulse);
        }
    }

    //detects whether player on ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = false;
        }
    }

    //prevents player from being lopsided
    protected void LateUpdate()
    {
        if(transform.rotation.x != 0 || transform.rotation.z != 0)
        {
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }
    }
}
