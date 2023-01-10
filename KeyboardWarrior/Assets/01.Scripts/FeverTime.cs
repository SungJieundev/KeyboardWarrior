using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTime : MonoBehaviour
{
    private CompareChar compareChar;
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
            Debug.Log(feverKeyBoardChar);
        }
    }

    private void RandomFeverKeyBoardRoutine(){

        RandomFeverKeyBoard(); // 피버키보드 뽑기

        // 만약 피버키보드가 사라질 예정이라면 다시 뽑기
        while(!compareChar.keyWord.Contains(feverKeyBoardChar)){

            RandomFeverKeyBoard();
        }

        // 뽑은 피버키보드를 밟으면 currentTriggerCount++
        
        
        // 만약 currentTriggerCount >= triggerCount 라면
        // 피버타임을 시작하기

        // 만약 피버타임을 시작하면
        // 현재 키보드리스트를 다 검사하여 꺼져있는 스프라이트 렌더러를 전부 켜주기
    }

    private void RandomFeverKeyBoard(){

        feverKeyBoardIndex = Random.Range(0, compareChar.keyBoard.Count);
        feverKeyBoardChar = compareChar.keyBoard[feverKeyBoardIndex].name[0];    
    }

    private void FeverKeyBoardTrigger(){

        
    }

    private void StartFeverTime(){


    }
}
