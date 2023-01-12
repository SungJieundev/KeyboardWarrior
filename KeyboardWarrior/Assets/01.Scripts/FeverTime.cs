using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTime : MonoBehaviour
{
    CompareChar compareChar;

    [SerializeField] private List<GameObject> allChildKeyBoardList = new List<GameObject>(); //모든 자식 키보드가 담긴 리스트

    [SerializeField] private int feverCount; //총 몇 번의 피버키를 모아야 하는지

    private int currentTriggerCount = 0; // 현재 피버키보드 밟은 횟수
    private int triggerCount = 0; // 피버타임을 발동하기 위한 목표 횟수

    public int feverKeyBoardIndex = 0; //정해진 피버키의 인덱스를 담을 변수
    private char feverKeyBoardChar; //정해진 피버키의 이름을 담을 변수

    public bool needFK = false; //현재 피버키가 정해져 있는지

    private bool triggerFeverKey = false; //현재 턴에 플레이어가 피버키를 체크했는지

    public bool feverTiming = false; //현재 피버 타임이 진행중인지

    
    [SerializeField] private List<Color> feverTimeColor = new List<Color>(); 

    private void Awake() {
        
        compareChar = GetComponent<CompareChar>();
    }

    public void RandomFeverKeyBoardRoutine(string keyWordType){

        needFK = false;

        if (keyWordType == "falseT") {

            RandomFeverKeyBoard(); // 피버키 뽑기

            //뽑은 피버키 상태가 없거나 제시어에 포함되거나 이전 피버키와 동일하다면 다시 뽑는다

            while(compareChar.keyWord.Contains(feverKeyBoardChar) && 
                GameObject.Find(feverKeyBoardChar.ToString()).GetComponent<SpriteRenderer>().enabled == true &&
                feverKeyBoardChar ==  compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0]){ //- 얘가 문제임, 안 멈춰서 터졌던 거

                RandomFeverKeyBoard();
            }

            FeverColor(Color.yellow); //뽑았다면 색을 바꾼다.
            Debug.Log(feverKeyBoardChar);
        }

        needFK = true;
        triggerFeverKey = false;
    }

    private void RandomFeverKeyBoard(){ //피버키 뽑는 메서드

        feverKeyBoardIndex = Random.Range(0, compareChar.parentkeyBoardls.Count);
        feverKeyBoardChar = compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0];  
    }

    public void FeverColor(Color color){ //피버키 색 바꾸는 메서드

        compareChar.childkeyBoardls[feverKeyBoardIndex].GetComponent<SpriteRenderer>().color = color;
    }

    public void FeverKeyTirgger(string curKeyName) { //피버키가 체크됐는지 확인하는 메서드

            if (feverKeyBoardChar.ToString() == curKeyName && !triggerFeverKey) {

                triggerFeverKey = true;
                feverCount--;
                FeverColor(Color.white);

                if (feverCount == 0) StartCoroutine(ColorRoutine());
            }           
    }

    IEnumerator ColorRoutine(){

        Debug.Log("피버타임 실행");
        feverTiming = true;

        compareChar.AllKeyBoardTrue(); //보상


        for (int j = 0; j < feverTimeColor.Count; j++) { //팔레트 수 만큼

            for (int i = 0; i < allChildKeyBoardList.Count; i++) { //키보드 수 만큼

                allChildKeyBoardList[i].GetComponent<SpriteRenderer>().color = feverTimeColor[j];
            }
            yield return new WaitForSeconds(0.1f); //몇 초 있다가 색 바뀌게 할건지
        }

        feverCount = 5;
    }
}
