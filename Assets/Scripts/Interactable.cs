using UnityEngine;

public class Interactable : MonoBehaviour
{

    //this provides a visual aid for the item
    public float radius = 3f;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
