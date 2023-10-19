using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _beam;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private int _health = 5;
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private BoxCollider2D _collider;
    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private Sprite[] _sprites;
    private float _horizontalMovement;
    private float _verticalMovement;
    private float _fireTimer = 0f;
    private bool _isHit = false;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Beam")
        {
            Destroy(collision.gameObject);
            if (_isHit) 
            {
                return;
            }
            _isHit = true;
            Invoke("OnHit", 0.1f);
            Debug.Log("Got hit");
            _renderer.sprite = _sprites[1];
        }
    }

    private void OnHit() 
    {
        _renderer.sprite = _sprites[1];
        _health--;
        _renderer.sprite = _sprites[0];

        if (_health == 0) 
        {
            Destroy(this.gameObject);
        }
        _isHit = false;
    }
}
