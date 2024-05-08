using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIViewController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _chacheText; // キャッシュ表示用のテキスト

    // キャッシュの値を表示するメソッド
    public void SetChacheText(int value)
    {
        _chacheText.text = "Score:" + value.ToString();
    }

    void Start()
    {
        // 何もしない
    }

    void Update()
    {
        // 何もしない
    }
}
