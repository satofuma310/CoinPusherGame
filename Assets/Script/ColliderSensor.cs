using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ColliderSensor : MonoBehaviour
{
    private Action<GameObject> _onCollision;
    public event Action<GameObject> OnCollision
    {
        add
        {
            _onCollision = value;
        }
        remove
        {
            _onCollision = value;
        }
    }
    private Action<GameObject> _onExitCollision;
    public event Action<GameObject> OnExitCollision
    {
        add
        {
            _onExitCollision = value;
        }
        remove
        {
            _onExitCollision = value;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        _onCollision(collision.gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        _onExitCollision(collision.gameObject);
    }
}
