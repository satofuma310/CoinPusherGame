using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField]
    private UIViewController _uIViewController;
    void Awake()
    {
        CacheManager.instnace.OnCacheChange += i => _uIViewController.SetChacheText(i);
    }

    void Update()
    {

    }
}
