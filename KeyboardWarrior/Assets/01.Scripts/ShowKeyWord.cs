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
    private CompareChar compareChar;
    private GameMain gameMain;
    private FeverTime feverTime;
    private ChangeBGColor changeBGColor;

    private TextMeshProUGUI keyWordTxt; //키워드
    private string keyWord; //키워드를 저장할 변수

    [SerializeField] private List<string> trueKeyWordList = new List<string>(); //옳은 - 비영구
    [SerializeField] private List<string> falseKeyWordList = new List<string>(); //옳지 않은 - 영구

    [SerializeField] private int truep; // 키워드가 옳을 활률
    [SerializeField] private int falsep; //키워드가 옳지 않을 확률

    private int trueIndex;
    private int falseIndex;

    private string keyWordType; //키워드 타입 (옳, 옳 않)

    private float typingDuration = 1.5f; //키워드 타이핑 지속시간

    private void Awake() {

        compareChar = GetComponent<CompareChar>();
        gameMain = GetComponent<GameMain>();
        feverTime = GetComponent<FeverTime>();
        changeBGColor = GetComponent<ChangeBGColor>();
    
        keyWordTxt = gameMain.keyWordTxt;
        keyWord = keyWordTxt.text;
    }

    public void keyWordShow() { //이 메서드를 언제 호출하느냐 중요

        int ran = Random.Range(1, 101);

        changeBGColor.Change();
        
        if (ran >= 1 && ran <= falsep) { //옳지 않은 코딩이 나왔다면

            falseIndex = Random.Range(0, falseKeyWordList.Count);
            keyWord = falseKeyWordList[falseIndex];
            keyWordType = "falseT";
        }
        else if (ran > falsep && ran <= truep) { //옳은 코딩이 나왔다면

            trueIndex = Random.Range(0, trueKeyWordList.Count);
            keyWord = trueKeyWordList[trueIndex];
            keyWordType = "trueT";
        }
        else { Debug.LogError("옳은 코딩 옳지 않은 코딩 확률이 뜨지 않음 = 오류");}

        Sequence sequence = DOTween.Sequence();

        sequence.Append(keyWordTxt.DOText(keyWord, typingDuration));

        sequence.OnComplete(() => {

            compareChar.Compare(keyWordType);
            feverTime.RandomFeverKeyBoardRoutine(keyWordType);
        });
    }
}
