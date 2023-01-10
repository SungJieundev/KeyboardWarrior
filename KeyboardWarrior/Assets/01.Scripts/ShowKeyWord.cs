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

    [SerializeField] private List<string> trueKeyWordList = new List<string>(); //옳은 - 비영구
    [SerializeField] private List<string> falseKeyWordList = new List<string>(); //옳지 않은 - 영구

    private string keyWordType; //키워드 타입

    [SerializeField] private int longp; // 확률?
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

        int ran = Random.Range(1, 9);

        Debug.Log(ran);

        if (ran <= longp) { //영구 키워드에 걸렸다면 값 <= 1, 2만 걸림

            longIndex = Random.Range(0, trueKeyWordList.Count);
            keyWord = trueKeyWordList[longIndex]; //인덱스 초과
            keyWordType = "long";
        }
        else { //비영구 키워드에 걸렸다면

            shortIndex = Random.Range(0, falseKeyWordList.Count);
            keyWord = falseKeyWordList[shortIndex];
            keyWordType = "short";
        }

        Sequence sequence = DOTween.Sequence();

        //DoTweens.instance.DoString(keyWord, keyWordTxt, duration);
        sequence.Append(keyWordTxt.DOText(keyWord, duration));

        sequence.OnComplete(() => {

            CompareChar.instance.Compare(keyWordType);
        });

        // DoTweens.instance.DoString(keyWord, keyWordTxt, duration); //현재 수리중
        //다트윈으로 나타낼 무튼 다트윈 메서드인데 매개변수로 keyWord 넘겨주면 댐 ㅎㅎ;
    }
}
