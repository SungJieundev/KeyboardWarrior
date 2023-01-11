using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    ShowKeyWord showKeyWord;

    [SerializeField] private TextMeshProUGUI keyWordTxt; //키워드

    [SerializeField] private string[] startMsg;

    [SerializeField] private float gameDelay;

    private void Start() { //시작!
        
        StartCoroutine(StartMsg()); //처음 Start 3 2 1 띄워주는 메서드

        StartCoroutine(Game()); //한 턴의 게임을 담아둔 Game 코루틴 시작
    }

    private void Awake() {

        showKeyWord.GetComponent<ShowKeyWord>();
    }

    IEnumerator Game() { //한 턴의 게임

        showKeyWord.keyWordShow(); //키워드를 제시해준다
        //옳, 옳 않을 특정 확률로 구해 그 종류에 맞는 제시어를 랜덤으로 생성하고
        //옳, 옳 않 타입을 Compare에 보낸다
        //키워드가 작성되는 다트윈을 실행한다.

        yield return new WaitForSeconds(gameDelay);
    }

    IEnumerator StartMsg() { //시작 메세지를 띄워주는 메서드

        for (int i = 0; i < startMsg.Length; i++) {
            keyWordTxt.text = startMsg[i];
            yield return new WaitForSeconds(0.7f);
            keyWordTxt.text = "";
            yield return new WaitForSeconds(0.3f);
        }
    }
}