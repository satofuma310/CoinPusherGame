using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIViewController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _chacheText;
    public void SetChacheText(int value)
    {
        _chacheText.text = "Score:" + value.ToString();
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
}
