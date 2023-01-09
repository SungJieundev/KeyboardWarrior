using System.Globalization;
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowKeyWord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyWordTxt;

    [SerializeField] private List<string> longKeyWordList = new List<string>(); //비영구
    [SerializeField] private List<string> shortKeyWordList = new List<string>(); //영군

    [SerializeField] private int longp, shortp; //비영구, 영구 나올 확률 변수
    private string keyWord;

    private void Awake() {

        keyWordTxt.text = "";
    }
    private void Update() {
        
    }

    public void keyWordShow() {
        //int n = Random.Range
        //제시어 선정하는 스크립트
        //제시어 담은 변수를 매개변수로 받는 다트윈(타닥타닥) 호출

        DoTween.instance.DoString(keyWord);
    }
}
