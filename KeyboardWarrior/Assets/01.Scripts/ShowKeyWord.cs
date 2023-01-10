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
    [SerializeField] private TextMeshProUGUI keyWordTxt; //키워드
    private string keyWord; //키워드를 저장할 변수

    [SerializeField] private List<string> trueKeyWordList = new List<string>(); //옳은 - 비영구
    [SerializeField] private List<string> falseKeyWordList = new List<string>(); //옳지 않은 - 영구

    [SerializeField] private int turep; // 키워드가 옳을 활률
    [SerializeField] private int falsep; //키워드가 옳지 않을 확률
    private int longIndex; //
    private int shortIndex;

    private int ttttt;

    private string keyWordType; //키워드 타입 (옳, 옳 않)

    private float duration = 1.5f; //키워드 타이핑 지속시간

    private void Awake() {

        keyWordTxt.text = "null";
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) keyWordShow(); //테스트용
    }

    public void keyWordShow() { //이 메서드를 언제 호출하느냐 중요쓰 / 시작

        ttttt = 100 / (trueKeyWordList.Count + falseKeyWordList.Count);
        Debug.Log(ttttt);
        int ran = Random.Range(1, (trueKeyWordList.Count + falseKeyWordList.Count) * ttttt + 1);
        Debug.Log(ttttt);


        Debug.Log(ran); //확률이 몇이 나왔는지

        if (ran <= turep) { //옳은 코딩이 나올 확률

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
