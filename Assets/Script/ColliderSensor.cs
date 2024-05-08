using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderSensor : MonoBehaviour
{
    // 他のオブジェクトがトリガーに入った時のイベント
    private Action<GameObject> _onTriggerEnter;
    public event Action<GameObject> OnTriggerEnterObject
    {
        add
        {
            _onTriggerEnter += value;
        }
        remove
        {
            _onTriggerEnter -= value;
        }
    }

    // 他のオブジェクトがトリガーから出た時のイベント
    private Action<GameObject> _onTriggerExit;
    public event Action<GameObject> OnTriggerExitObject
    {
        add
        {
            _onTriggerExit += value;
        }
        remove
        {
            _onTriggerExit -= value;
        }
    }

    void Start()
    {
        // 何もしない
    }

    void Update()
    {
        // 何もしない
    }

    // 他のコライダーがこのコライダーに入った時の処理
    private void OnTriggerEnter(Collider other)
    {
        // トリガーに入ったオブジェクトが設定されたイベントを実行
        if (_onTriggerEnter != null)
            _onTriggerEnter(other.gameObject);
    }

    // 他のコライダーがこのコライダーから出た時の処理
    private void OnTriggerExit(Collider other)
    {
        // トリガーから出たオブジェクトが設定されたイベントを実行
        if (_onTriggerExit != null)
            _onTriggerExit(other.gameObject);
    }
}
