using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float maxRotateValue = 200f;
    [SerializeField]
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb.angularVelocity = Random.value * maxRotateValue;
    }
}
