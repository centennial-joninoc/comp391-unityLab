using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float _beamSpeed = 10.0f;
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private BoxCollider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = new Vector2(_beamSpeed, 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_rb.tag == "Beam" && collision.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

    }
}
