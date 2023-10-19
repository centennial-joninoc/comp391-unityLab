using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _beam;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private AudioSource _audio;
    private float _horizontalMovement;
    private float _verticalMovement;
    private float _fireTimer = 0f;

    private void Start()
    {
        Debug.Log("Hello World from Start!");
    }

    void Update()
    {

        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        MoveShip(_horizontalMovement, _verticalMovement);
    }

    private void MoveShip(float horizontalMovement, float verticalMovement) 
    {
        _rigidBody.velocity = new Vector3(Mathf.Clamp(horizontalMovement, -4f, 4f) * _speed, Mathf.Clamp(verticalMovement, -8f, 5f) * _speed, transform.position.z);
    }

    private void FireBeams() 
    {
        var beam = Instantiate(_beam, transform);
        beam.transform.localPosition = new Vector3(_rigidBody.transform.localPosition.x + 1.0f, _rigidBody.transform.localPosition.y, -1.0f);
    }

    private void LateUpdate()
    {
        _fireTimer += Time.deltaTime;

        if (_fireTimer >= _fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                FireBeams();
                _audio.Play();
            }
            _fireTimer = 0f;
        }
    }
}
