using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField]
    private UIViewController _uIViewController; // UIを制御するビューコントローラー

    void Awake()
    {
        // キャッシュ変更時のイベントを受け取ってUIに反映する
        CacheManager.instance.OnCacheChange += i => _uIViewController.SetChacheText(i);
    }

    void Update()
    {
        // 何もしない
    }
}
