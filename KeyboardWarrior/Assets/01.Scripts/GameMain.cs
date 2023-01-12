using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMain : MonoBehaviour
{
    ShowKeyWord showKeyWord;

    public TextMeshProUGUI keyWordTxt; //키워드

    [SerializeField] private string[] startMsg;

    [SerializeField] private float turnDelay;

    bool endStartMsg = false; //시작 메세지가 실행됐는지 확인하는 변수

    public bool isTurnEnd = true; //한 턴이 끝났는지 확인하는 변수

    public bool isPlayer = true; //플레이어가 살아있는지 확인하는 변수

    private void Awake() {
        
        showKeyWord = GetComponent<ShowKeyWord>();
    }

    private void Start() { //시작!
        
        StartCoroutine(StartMsg()); //처음 Start 3 2 1 띄워주는 메서드

        StartCoroutine(Game()); //한 턴의 게임을 담아둔 Game 코루틴 시작
    }

    IEnumerator Game() { //한 턴의 게임
    
        while (true) {

            if (endStartMsg) {

                showKeyWord.keyWordShow(); //키워드를 제시해준다
                isTurnEnd = false;
            }
            yield return new WaitUntil(() => isTurnEnd && isPlayer);
            yield return new WaitForSeconds(turnDelay);
        }
    }

    IEnumerator StartMsg() { //시작 메세지를 띄워주는 메서드

        for (int i = 0; i < startMsg.Length; i++) {
            
            keyWordTxt.text = startMsg[i];
            yield return new WaitForSeconds(0.7f);
            keyWordTxt.text = "";
            yield return new WaitForSeconds(0.3f);

        }
        endStartMsg = true;
    }
}
