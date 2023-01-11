using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FeverTime : MonoBehaviour
{
    private CompareChar compareChar;
    private KeyboardPushed keyboardPushed;
    private int currentTriggerCount = 0; // 현재 피버키보드 밟은 횟수
    private int triggerCount = 0; // 피버타임을 발동하기 위한 목표 횟수

    private int feverKeyBoardIndex;
    private char feverKeyBoardChar;
    


    private void Awake() {
        
        compareChar = GetComponent<CompareChar>();

        
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.S)){
            RandomFeverKeyBoardRoutine();
            Debug.Log($"뽑힌 피버키보드 : {feverKeyBoardChar}");

            StartFeverTime();
        }    
    }

    public void RandomFeverKeyBoardRoutine(){

        RandomFeverKeyBoard(); // 피버키보드 뽑기

        // 만약 피버키보드가 사라질 예정이라면 다시 뽑기
        while(compareChar.keyWord.Contains(feverKeyBoardChar)){

            RandomFeverKeyBoard();
        }

        // 뽑은 피버키보드를 밟으면 currentTriggerCount++
        
        
        // 만약 currentTriggerCount >= triggerCount 라면
        // 피버타임을 시작하기

        // 만약 피버타임을 시작하면
        // 현재 키보드리스트를 다 검사하여 꺼져있는 스프라이트 렌더러를 전부 켜주기
    }

    private void RandomFeverKeyBoard(){

        feverKeyBoardIndex = Random.Range(0, compareChar.parentkeyBoard.Count);
        feverKeyBoardChar = compareChar.parentkeyBoard[feverKeyBoardIndex].name[0];    
    }

    private void StartFeverTime(){

        if(currentTriggerCount >= triggerCount){

            Sequence seq = DOTween.Sequence();

            seq.Append(keyboardPushed.sr.DOColor(Color.red, 0.1f));
            seq.Append(keyboardPushed.sr.DOColor(Color.yellow, 0.1f));
            seq.Append(keyboardPushed.sr.DOColor(Color.green, 0.1f));
            seq.Append(keyboardPushed.sr.DOColor(Color.blue, 0.1f));
            seq.Append(keyboardPushed.sr.DOColor(Color.magenta, 0.1f));
            seq.Append(keyboardPushed.sr.DOColor(Color.white, 0.1f));
            
            seq.OnComplete(() => {

                compareChar.AllKeyBoardTrue();
            });
        }
    }
}
