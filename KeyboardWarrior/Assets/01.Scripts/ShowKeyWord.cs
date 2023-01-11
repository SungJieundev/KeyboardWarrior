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

    [SerializeField] private int truep; // 키워드가 옳을 활률
    [SerializeField] private int falsep; //키워드가 옳지 않을 확률
    private int longIndex; //
    private int shortIndex;

    private float ttttt;

    private string keyWordType; //키워드 타입 (옳, 옳 않)

    private float duration = 1.5f; //키워드 타이핑 지속시간

    private void Awake() {

        keyWordTxt.text = "null";
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) keyWordShow(); //테스트용
        if (Input.GetKeyDown(KeyCode.K)) CompareChar.instance.AllKeyBoardTrue(); //테스트용
    }

    public void keyWordShow() { //이 메서드를 언제 호출하느냐 중요쓰 / 시작

        int ran = Random.Range(1, 101);

        // Debug.Log(ran); //확률이 몇이 나왔는지
        
        if (ran >= 1 && ran <= falsep) { //옳지 않은 코딩이 나왔다면

            longIndex = Random.Range(0, trueKeyWordList.Count);
            keyWord = trueKeyWordList[longIndex];
            keyWordType = "falseT";
        }
        else if (ran > falsep && ran <= truep) { //옳은 코딩이 나왔다면

            shortIndex = Random.Range(0, falseKeyWordList.Count);
            keyWord = falseKeyWordList[shortIndex];
            keyWordType = "trueT";
        }
        else { Debug.LogError("옳은 코딩 옳지 않은 코딩 확률이 뜨지 않음 = 오류");}

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
