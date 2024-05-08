using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinClass : MonoBehaviour
{
    public Transform _followParent;
    void Start()
    {
        
    }

    void Update()
    {
        if (_followParent == null) return;
        transform.position += _followParent.position;
        
    }
}
