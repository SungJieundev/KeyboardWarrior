using System.Net.Http.Headers;
using System.Globalization;
using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ShowKeyWord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyWordTxt;

    [SerializeField] private List<string> longKeyWordList = new List<string>(); //비영구
    [SerializeField] private List<string> shortKeyWordList = new List<string>(); //영군

    [SerializeField] private int longp; //ex - 20
    private string keyWord;
    private float duration = 1.5f;
    private int longIndex, shortIndex;

    private void Awake() {

        keyWordTxt.text = "null";
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) keyWordShow();
    }

    public void keyWordShow() { //이 메서드를 언제 호출하느냐 중요쓰

        int ran = Random.Range(1, 101);

        Debug.Log(ran);

        if (ran <= longp) { //영구 키워드에 걸렸다면 값 <= 20

            longIndex = Random.Range(0, longKeyWordList.Count + 1);
            keyWord = longKeyWordList[longIndex];
        }
        else { //비영구 키워드에 걸렸다면

            shortIndex = Random.Range(0, shortKeyWordList.Count + 1);
            keyWord = shortKeyWordList[shortIndex];
        }

        Sequence sequence = DOTween.Sequence();

        //DoTweens.instance.DoString(keyWord, keyWordTxt, duration);
        // sequence.Append(keyWordTxt.DOText(keyWord, duration));

        // sequence.OnComplete(() => {

        //     CompareChar.instance.Compare();
        // });

        // DoTweens.instance.DoString(keyWord, keyWordTxt, duration); //현재 수리중
        //다트윈으로 나타낼 무튼 다트윈 메서드인데 매개변수로 keyWord 넘겨주면 댐 ㅎㅎ;
    }
}
