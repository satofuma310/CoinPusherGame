using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinClass : MonoBehaviour
{
    public Transform _followRigidbody;
    void Start()
    {
        
    }

    void Update()
    {
        if (_followRigidbody == null) return;
        transform.position += _followRigidbody.position;
        
    }
}
