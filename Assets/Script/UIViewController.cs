using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIViewController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _chacheText; // �L���b�V���\���p�̃e�L�X�g

    // �L���b�V���̒l��\�����郁�\�b�h
    public void SetChacheText(int value)
    {
        _chacheText.text = "Score:" + value.ToString();
    }

    void Start()
    {
        // �������Ȃ�
    }

    void Update()
    {
        // �������Ȃ�
    }
}
