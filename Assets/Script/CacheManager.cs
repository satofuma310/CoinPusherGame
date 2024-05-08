using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CacheManager : MonoBehaviour
{
    // CacheManagerのインスタンスを保持するための変数
    private static CacheManager _ins;

    // インスタンスを取得するプロパティ
    public static CacheManager instance
    {
        get
        {
            // インスタンスが存在しない場合は新しいGameObjectにアタッチして生成する
            if (_ins == null)
                _ins = new GameObject(typeof(CacheManager).Name).AddComponent<CacheManager>();
            return _ins;
        }
    }

    // キャッシュの値を保持する変数
    private int _cache;

    // キャッシュの値を取得・設定するプロパティ
    public int Cache
    {
        get
        {
            return _cache;
        }
        set
        {
            // 値を設定し、キャッシュ変更時のイベントを呼び出す
            _cache = value;
            _onCacheChange(value);
        }
    }

    // キャッシュ変更時のイベント
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

    // キャッシュ変更時のイベントを保持する変数
    private Action<int> _onCacheChange;

    void Start()
    {
        // ゲームオブジェクトがシーン間で破棄されないようにする
        DontDestroyOnLoad(gameObject);

        // キャッシュをロードして設定
        var loadData = SaveJson.Load<SaveStatus>();
        if (loadData != null)
            Cache = loadData.cache;

        // キャッシュをセーブ
        SaveJson.Save<SaveStatus>(new SaveStatus(_cache));
    }

    void Update()
    {
        // 何もしない
    }
}

// セーブデータのクラス
[System.Serializable]
public class SaveStatus
{
    public SaveStatus(int _cache)
    {
        cache = _cache;
    }

    // キャッシュの値
    public int cache;
}
