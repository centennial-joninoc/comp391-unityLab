using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D _boxCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Beam")
        {
            Destroy(collision.gameObject);
        }
    }

}
