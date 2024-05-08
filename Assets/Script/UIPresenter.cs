using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField]
    private UIViewController _uIViewController; // UI�𐧌䂷��r���[�R���g���[���[

    void Awake()
    {
        // �L���b�V���ύX���̃C�x���g���󂯎����UI�ɔ��f����
        CacheManager.instance.OnCacheChange += i => _uIViewController.SetChacheText(i);
    }

    void Update()
    {
        // �������Ȃ�
    }
}
