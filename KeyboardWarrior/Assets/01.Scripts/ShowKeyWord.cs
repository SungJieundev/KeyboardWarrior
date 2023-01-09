using System.Net.Http.Headers;
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

    [SerializeField] private int longp; //ex - 20
    private string keyWord;
    private float duration;
    private int longIndex, shortIndex;

    private void Awake() {

        keyWordTxt.text = "";
    }
    private void Update() {
        
    }

    public void keyWordShow() {

        int ran = Random.Range(1, 101);

        if (ran <= longp) { //영구 키워드에 걸렸다면 값 <= 20

            int n = Random.Range(0, longKeyWordList.Count + 1);
            keyWord = longKeyWordList[n];
        }
        else { //비영구 키워드에 걸렸다면

            int m = Random.Range(0, shortKeyWordList.Count + 1);
            keyWord = shortKeyWordList[m];
        }

        // DoTweens.instance.DoString(keyWord, keyWordTxt, duration); //현재 수리중
    }
}
