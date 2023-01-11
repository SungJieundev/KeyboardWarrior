using System.Threading.Tasks;
using System.Buffers;
using System.Security.Cryptography;
using System.Linq;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CompareChar : MonoBehaviour
{
    DoTweens doTweens;

    [SerializeField] private TextMeshProUGUI keyWordTxt; //키워드가 들어있는 TMP

    public string keyWord; //키워드 받아오는 변수

    public List<GameObject> parentkeyBoardls = new List<GameObject>(); //이동 가능한 부모 키보드를 담아둔 리스트
    public List<GameObject> childkeyBoardls = new List<GameObject>(); //이동 가능한 자식 키보드를 담아둔 리스트


    public List<GameObject> previousKeyBoard = new List<GameObject>(); //이전의 키보드를 담아둔다.

    private SpriteRenderer parentKeyBoard; //키보드 중 부모의 SpriteRenderer를 받아올 변수
    private SpriteRenderer childKeyBoard; //키보드 중 자식의 SpriteRenderer를 받아올 변수

    [SerializeField] private float duration; //다트윈 지속시간

    private void Start() {
        
        //자식 키보드 리스트를 채워주는 코드
        for (int i = 0; i < parentkeyBoardls.Count; i++)
            childkeyBoardls.Add(parentkeyBoardls[i].transform.GetChild(0).gameObject);
    }

    private void Awake() {
        doTweens = GetComponent<DoTweens>();
    }

    public void Compare(string keyWordType) {
        
        keyWord = keyWordTxt.text; //현재 키워드 받아오기

        PreviousSaveListClear(); //복구할 키보드 담아둔 리스트 클리어

        for (int i = 0; i < keyWord.Length; i++) { //제시어 글자 수 만큼 반복 

            for (int j = 0; j < parentkeyBoardls.Count; j++) { //키보드 수 만큼 반복

                if (keyWordType == "trueT") { //옳은 코딩이 호출됐다면(비영구) - 제시어를 제외한 모든 키보드를 삭제

                    if (!keyWord.Contains(parentkeyBoardls[j].name)) { //제시어에 현재 키보드 값이 들어가있지 않다면 = 제시어의 값이 아니라면
                        
                        parentKeyBoard = parentkeyBoardls[j].GetComponent<SpriteRenderer>(); //현재 부모 키보드 SpriteRenderer 받아오기
                        childKeyBoard = childkeyBoardls[j].GetComponent<SpriteRenderer>(); //현재 자식 키보드 SpriteRenderer 받아오기

                        if (parentKeyBoard.enabled || childKeyBoard.enabled)
                            TrueKeyBoardSave(); //옳은 키보드(비영구) 복구할 키보드 저장하기

                        TrueKeyBoardFalse(); //옳은 키보드(비영구) 끄기
                    }
                }

                else if (keyWordType == "falseT") { //옳지 않은 코딩이 호출됐다면(영구) - 제시어를 포함한 키보드를 삭제 - 정상

                    if (keyWord[i].ToString() == parentkeyBoardls[j].name) { //제시어의 n번째 글자와 키보드의 m번째 이름이 맞다면

                        parentKeyBoard = parentkeyBoardls[j].GetComponent<SpriteRenderer>(); //현재 부모 키보드 SpriteRenderer 받아오기
                        childKeyBoard = childkeyBoardls[j].GetComponent<SpriteRenderer>(); //현재 자식 키보드 SpriteRenderer 받아오기

                        FalseKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                    }
                }
                else { Debug.LogError("코딩이 옳지도 옳지 않지도 않음 == 오류");} //이거 뜨면 showkeyword의 확률 문제
            }
        }
    }

    public void TrueKeyBoardFalse() { //옳은 키워드 키보드 끄기 = 끄기 반전

        parentKeyBoard.enabled = false; //키보드의 부모의 SpriteRenderer를 꺼주고
        childKeyBoard.enabled = false; //자식의 SpriteRenderer도 꺼준다.
    }

    public void TrueKeyBoardTrue() { //옳은 키워드 키보드 복구 = 턴 지나면 살리기

        foreach (GameObject previousKBList in previousKeyBoard) { //복구해야할 키보드를 담아둔 리스트를 전부 반복

            previousKBList.GetComponent<SpriteRenderer>().enabled = true; //리스트 값 전부를 켜 준다.
        }

        KeyWordClear();
    }

    public void FalseKeyBoardFalse() { //옳지 않은 키워드 키보드 끄기 = 정상

        parentKeyBoard.enabled = false; //키보드의 부모의 SpriteRenderer를 꺼주고
        childKeyBoard.enabled = false; //자식의 SpriteRenderer도 꺼준다.

        Invoke("KeyWordClear", 1f);
    }
    
    public void AllKeyBoardTrue() { //모든 키보드 복구 = 피버타임 보상 (테스트 성공)

        //피버타임 문구 띄우기
        for (int i = 0; i < parentkeyBoardls.Count; i++) {

            parentkeyBoardls[i].GetComponent<SpriteRenderer>().enabled = true;
            childkeyBoardls[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void PreviousSaveListClear() { //이전의 키보드를 저장해둔 리스트 초기화

        previousKeyBoard.Clear();
    }

    public void TrueKeyBoardSave() { //옳은 코딩(비영구)라면 복구를 위해 삭제한 키보드를 담아둠 - 수정해야함.

        previousKeyBoard.Add(parentKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (부모)
        previousKeyBoard.Add(childKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (자식);

        Invoke("TrueKeyBoardTrue", 3f); //비영구 키워드의 키보드 복구 메서드
    }

    public void KeyWordClear() { //제시어 칸 청소 - 

        keyWordTxt.text = "";
    }
}