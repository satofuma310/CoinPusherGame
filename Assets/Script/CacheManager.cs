using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CacheManager : MonoBehaviour
{
    // CacheManager�̃C���X�^���X��ێ����邽�߂̕ϐ�
    private static CacheManager _ins;

    // �C���X�^���X���擾����v���p�e�B
    public static CacheManager instance
    {
        get
        {
            // �C���X�^���X�����݂��Ȃ��ꍇ�͐V����GameObject�ɃA�^�b�`���Đ�������
            if (_ins == null)
                _ins = new GameObject(typeof(CacheManager).Name).AddComponent<CacheManager>();
            return _ins;
        }
    }

    // �L���b�V���̒l��ێ�����ϐ�
    private int _cache;

    // �L���b�V���̒l���擾�E�ݒ肷��v���p�e�B
    public int Cache
    {
        get
        {
            return _cache;
        }
        set
        {
            // �l��ݒ肵�A�L���b�V���ύX���̃C�x���g���Ăяo��
            _cache = value;
            _onCacheChange(value);
        }
    }

    // �L���b�V���ύX���̃C�x���g
    public event Action<int> OnCacheChange
    {
        add
        {
            _onCacheChange += value;
        }
        remove
        {
            _onCacheChange -= value;
        }
    }

    // �L���b�V���ύX���̃C�x���g��ێ�����ϐ�
    private Action<int> _onCacheChange;

    void Start()
    {
        // �Q�[���I�u�W�F�N�g���V�[���ԂŔj������Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);

        // �L���b�V�������[�h���Đݒ�
        var loadData = SaveJson.Load<SaveStatus>();
        if (loadData != null)
            Cache = loadData.cache;

        // �L���b�V�����Z�[�u
        SaveJson.Save<SaveStatus>(new SaveStatus(_cache));
    }

    void Update()
    {
        // �������Ȃ�
    }
}

// �Z�[�u�f�[�^�̃N���X
[System.Serializable]
public class SaveStatus
{
    public SaveStatus(int _cache)
    {
        cache = _cache;
    }

    // �L���b�V���̒l
    public int cache;
}
