using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTime : MonoBehaviour
{
    [SerializeField] private List<GameObject> allChildKeyBoardList = new List<GameObject>();
    [SerializeField] private int feverCount;
    private CompareChar compareChar;
    private int currentTriggerCount = 0; // 현재 피버키보드 밟은 횟수
    private int triggerCount = 0; // 피버타임을 발동하기 위한 목표 횟수

    private int feverKeyBoardIndex;
    private char feverKeyBoardChar;
    
    [SerializeField] private List<Color> testColor = new List<Color>(); 

    private void Awake() {
        
        compareChar = GetComponent<CompareChar>();
    }

    // private void Update() {
        
    //     if(Input.GetKeyDown(KeyCode.S)){
            
    //         StartCoroutine(ColorRoutine());

    //         Debug.Log(feverKeyBoardChar);
    //     }

    //     if(Input.GetKeyDown(KeyCode.A)){

    //         RandomFeverKeyBoardRoutine();
    //     }
    // }

    public void RandomFeverKeyBoardRoutine(){

        RandomFeverKeyBoard(); // 피버키보드 뽑기

        // 만약 피버키보드가 사라질 예정이라면 다시 뽑기

        while(compareChar.keyWord.Contains(feverKeyBoardChar) && 
            GameObject.Find(feverKeyBoardChar.ToString()).GetComponent<SpriteRenderer>().enabled == false &&
            feverKeyBoardChar ==  compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0]){ //- 얘가 문제임, 안 멈춰서 터졌던 거

            RandomFeverKeyBoard();
        }

        FeverColor(Color.yellow);
    }

    private void RandomFeverKeyBoard(){

        feverKeyBoardIndex = Random.Range(0, compareChar.parentkeyBoardls.Count);
        feverKeyBoardChar = compareChar.parentkeyBoardls[feverKeyBoardIndex].name[0];    
    }

    public void FeverColor(Color color){

        compareChar.childkeyBoardls[feverKeyBoardIndex].GetComponent<SpriteRenderer>().color = color;
    }

    public void FeverKeyTirgger() { //플레이어 이동할 때 마다 돌리면서 검사하면 됨

        if (!allChildKeyBoardList[feverKeyBoardIndex].GetComponent<SpriteRenderer>().enabled) {

            feverCount--;
            FeverColor(Color.white);
            if (feverCount == 0) StartCoroutine(ColorRoutine());
        }
    }

    IEnumerator ColorRoutine(){
        
        for (int j = 0; j < testColor.Count; j++) { //팔레트 수 만큼

            for (int i = 0; i < allChildKeyBoardList.Count; i++) { //키보드 수 만큼

                allChildKeyBoardList[i].GetComponent<SpriteRenderer>().color = testColor[j];
            }
            yield return new WaitForSeconds(0.1f); //몇 초 있다가 색 바뀌게 할건지
        }

        compareChar.AllKeyBoardTrue(); //보상
    }
}
