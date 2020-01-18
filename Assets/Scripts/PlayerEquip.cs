using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    private Transform rightHand;
    private Rigidbody body;
    private bool ePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform i in GetComponentsInChildren<Transform>())
        {
            if (i.name == "B-hand_R")
            {
                rightHand = i;
            }
        }
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ePressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            ePressed = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        GameObject equipment = collision.gameObject;

        if (equipment.tag == "Equipment" && ePressed)
        {
            Weapon script = equipment.GetComponent<Weapon>();

            //freezes sword so it doesn't wobble in hand
            Rigidbody weaponBody = equipment.GetComponent<Rigidbody>();
            weaponBody.constraints = RigidbodyConstraints.FreezeAll;
            weaponBody.detectCollisions = false;


            equipment.GetComponent<Transform>().parent = rightHand;
            equipment.transform.localPosition = script.position;
            equipment.transform.localEulerAngles = script.rotation;
        }
    }
}
