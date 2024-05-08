using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ColliderSensor : MonoBehaviour
{
    private Action<GameObject> _onTriggerEnter;
    public event Action<GameObject> OnTriggerEnterObject
    {
        add
        {
            _onTriggerEnter = value;
        }
        remove
        {
            _onTriggerEnter = value;
        }
    }
    private Action<GameObject> _onTriggerExit;
    public event Action<GameObject> OnTriggerExitObject
    {
        add
        {
            _onTriggerExit = value;
        }
        remove
        {
            _onTriggerExit = value;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_onTriggerEnter != null)
            _onTriggerEnter(other.gameObject);

    }
    private void OnTriggerExit(Collider other)
    {
        if(_onTriggerExit != null)
        _onTriggerExit(other.gameObject);

    }
}
