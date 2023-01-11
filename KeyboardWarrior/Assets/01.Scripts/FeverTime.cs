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
    
    [SerializeField] private List<Color> testColor = new List<Color>(); 
    //팔레트 담아둔 리스트, SerializeField 거슬리면 Awake에서 값 넣어주기 - 색 임의로 내가 해둔거라 너가 바꿔줘

    private void Awake() {
        
        compareChar = GetComponent<CompareChar>();
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.S)){
            
            StartCoroutine(ColorRoutine());

            Debug.Log(feverKeyBoardChar);
        }

        if(Input.GetKeyDown(KeyCode.A)){

            RandomFeverKeyBoardRoutine();
        }
    }

    private void RandomFeverKeyBoardRoutine(){

        RandomFeverKeyBoard(); // 피버키보드 뽑기

        // 만약 피버키보드가 사라질 예정이라면 다시 뽑기

        while(compareChar.keyWord.Contains(feverKeyBoardChar) && 
            GameObject.Find(feverKeyBoardChar.ToString()).GetComponent<SpriteRenderer>().enabled == false &&
            feverKeyBoardChar ==  compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0]){ //- 얘가 문제임, 안 멈춰서 터졌던 거

            RandomFeverKeyBoard();
        }

        FeverColor(Color.yellow);

        // 뽑은 피버키보드를 밟으면 currentTriggerCount++
        
        
        // 만약 currentTriggerCount >= triggerCount 라면
        // 피버타임을 시작하기

        // 만약 피버타임을 시작하면
        // 현재 키보드리스트를 다 검사하여 꺼져있는 스프라이트 렌더러를 전부 켜주기
    }

    private GameObject[] childs;

    private void RandomFeverKeyBoard(){

        feverKeyBoardIndex = Random.Range(0, compareChar.parentkeyBoardls.Count);
        feverKeyBoardChar = compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0];    
    }

    private void StartFeverTime(){

        StartCoroutine(ColorRoutine());
    }

    public void FeverColor(Color color){

        compareChar.childkeyBoardls[feverKeyBoardIndex].GetComponent<SpriteRenderer>().color = color;
    }

    IEnumerator ColorRoutine(){
        

        for (int j = 0; j < testColor.Count; j++) { //팔레트 수 만큼

            for (int i = 0; i < compareChar.childkeyBoardls.Count; i++) { //키보드 수 만큼

                compareChar.childkeyBoardls[i].GetComponent<SpriteRenderer>().color = testColor[j];
            }
            yield return new WaitForSeconds(0.1f); //몇 초 있다가 색 바뀌게 할건지
        }

        //compareChar.AllKeyBoardTrue(); //보상
    }
}
