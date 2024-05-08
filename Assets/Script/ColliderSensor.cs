using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderSensor : MonoBehaviour
{
    // ���̃I�u�W�F�N�g���g���K�[�ɓ��������̃C�x���g
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

    // ���̃I�u�W�F�N�g���g���K�[����o�����̃C�x���g
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
        // �������Ȃ�
    }

    void Update()
    {
        // �������Ȃ�
    }

    // ���̃R���C�_�[�����̃R���C�_�[�ɓ��������̏���
    private void OnTriggerEnter(Collider other)
    {
        // �g���K�[�ɓ������I�u�W�F�N�g���ݒ肳�ꂽ�C�x���g�����s
        if (_onTriggerEnter != null)
            _onTriggerEnter(other.gameObject);
    }

    // ���̃R���C�_�[�����̃R���C�_�[����o�����̏���
    private void OnTriggerExit(Collider other)
    {
        // �g���K�[����o���I�u�W�F�N�g���ݒ肳�ꂽ�C�x���g�����s
        if (_onTriggerExit != null)
            _onTriggerExit(other.gameObject);
    }
}
