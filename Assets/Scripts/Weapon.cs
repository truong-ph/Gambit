using UnityEngine;
using UnityEngine.UI;

public class Weapon : Interactable
{
    public float damage;
    public float range;
    public Vector3 position;
    public Vector3 rotation;
    public Text textObject;

    //displays different game messages for the weapon
    void Start()
    {
        textObject.text = "";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textObject.text = "Press E to Equip";
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            textObject.text = "";
        }
    }

}
