using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CacheManager : MonoBehaviour
{
    private static CacheManager _ins;
    public static CacheManager instnace
    {
        get
        {
            if (_ins == null)
                _ins = new GameObject(typeof(CacheManager).Name).AddComponent<CacheManager>();
            return _ins;
        }
    }
    private int _cache;
    public int Cache
    {
        get
        {
            return _cache;
        }
        set
        {
            _cache = value;
            _onCacheChange(value);
        }
    }
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
    private Action<int> _onCacheChange;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        var loadData = SaveJson.Load<SaveStatus>();
        if (loadData != null)
            Cache = loadData.cache;
        SaveJson.Save<SaveStatus>(new SaveStatus(_cache));
    }

    void Update()
    {

    }
}
[System.Serializable]
public class SaveStatus
{
    public SaveStatus(int _cache)
    {
        cache = _cache;
    }
    public int cache;
}