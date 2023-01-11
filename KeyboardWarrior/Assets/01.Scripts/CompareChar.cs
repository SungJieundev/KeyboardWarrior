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
    public static CompareChar instance;
    

    [SerializeField] private TextMeshProUGUI keyWordTxt; //키워드가 들어있는 TMP

    public string keyWord; //키워드 받아오는 변수

    public List<GameObject> keyBoard = new List<GameObject>(); //이동 가능한 키보드를 담아둔 리스트


    private List<GameObject> previousKeyBoard = new List<GameObject>(); //이전의 키보드를 담아둔다.

    private SpriteRenderer parentKeyBoard; //키보드 중 부모의 SpriteRenderer를 받아올 변수
    private SpriteRenderer childKeyBoard; //키보드 중 자식의 SpriteRenderer를 받아올 변수

    [SerializeField] private float duration; //다트윈 지속시간

    private void Awake() {

        if (!instance) instance = this;
        else { Destroy(gameObject); }
    }

    public List<string> testt = new List<string>();
    public void Compare(string keyWordType) {
        
        keyWord = keyWordTxt.text;

        for (int i = 0; i < keyWord.Length; i++) { //제시어 글자 수 만큼 반복 
            testt.Add(keyWord[i].ToString());

            for (int j = 0; j < keyBoard.Count; j++) { //키보드 수 만큼 반복

                if (keyWordType == "trueT") { //옳은 코딩이 호출됐다면(비영구) - 제시어를 제외한 모든 키보드를 삭제 - 문제

                    // testt[i] += keyWord[i].ToString(); //인덱스 0 자리부터 키워드 0번째 글자 하나씩 넣어줌

                        if (!keyWord.Contains(keyBoard[j].name)) { //bnm 일 때 변하는건 j값만,,
                            
                            // Debug.Log($"{testt[k]} - {j} + {i}");
                            parentKeyBoard = keyBoard[j].GetComponent<SpriteRenderer>();
                            childKeyBoard = keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

                            DoTweens.instance.DoTColor(childKeyBoard.gameObject,
                                Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                            //다트윈 시간이 끝나면 아래의 .enabled 실행

                            TrueKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                            
                            KeyWordTypeCompare(keyWordType); //키워드 타입 비교 / 영구, 비영구 / 매개변수 = 키워드 타입
                        }
                        else { Debug.Log("현재 j번은 키워드에 들어감 ㅇㅇ");}
                }

                // if (keyWordType == "trueT") { //옳은 코딩이 호출됐다면(비영구) - 제시어를 제외한 모든 키보드를 삭제 - 문제

                //     // testt[i] += keyWord[i].ToString(); //인덱스 0 자리부터 키워드 0번째 글자 하나씩 넣어줌
                //     for (int k = 0; k < testt.Count; k++) {

                //         if (!keyBoard[j].name.Contains(testt[k])) { //j가 n일 때 k는 n m o p 다 돌아감 & 비교됨
                            
                //             Debug.Log($"{testt[k]} - {j} + {i}");
                //             parentKeyBoard = keyBoard[j].GetComponent<SpriteRenderer>();
                //             childKeyBoard = keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

                //             DoTweens.instance.DoTColor(childKeyBoard.gameObject,
                //                 Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                //             //다트윈 시간이 끝나면 아래의 .enabled 실행

                //             TrueKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                            
                //             KeyWordTypeCompare(keyWordType); //키워드 타입 비교 / 영구, 비영구 / 매개변수 = 키워드 타입
                //         }
                //         else { Debug.Log("현재 j번은 키워드에 들어감 ㅇㅇ");}
                //     }
                // }
                // if (keyWordType == "trueT") { //옳은 코딩이 호출됐다면(비영구) - 제시어를 제외한 모든 키보드를 삭제 - 문제
                //     //오류 터짐, 다 꺼짐 ㅇㅇ;
                //     if (keyWord[i].ToString() != keyBoard[j].name) { //제시어의 n번째 글자와 키보드의 m번째 이름이 맞지 않다면
                //         if (keyBoard[j].name.Contains()) {
                //             Debug.Log("A");
                //         }
                //         parentKeyBoard = keyBoard[j].GetComponent<SpriteRenderer>();
                //         childKeyBoard = keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

                //         DoTweens.instance.DoTColor(childKeyBoard.gameObject,
                //             Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                //         //다트윈 시간이 끝나면 아래의 .enabled 실행

                //         TrueKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                        
                //         KeyWordTypeCompare(keyWordType); //키워드 타입 비교 / 영구, 비영구 / 매개변수 = 키워드 타입
                //     }

                // }
                else if (keyWordType == "falseT") { //옳지 않은 코딩이 호출됐다면(영구) - 제시어를 포함한 키보드를 삭제 - 정상

                    if (keyWord[i].ToString() == keyBoard[j].name) { //제시어의 n번째 글자와 키보드의 m번째 이름이 맞다면

                        parentKeyBoard = keyBoard[j].GetComponent<SpriteRenderer>();
                        childKeyBoard = keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

                        DoTweens.instance.DoTColor(childKeyBoard.gameObject,
                            Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                        //다트윈 시간이 끝나면 아래의 .enabled 실행

                        FalseKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                    }
                }
                else { Debug.LogError("코딩이 옳지도 옳지 않지도 않음 == 오류");} //이거 뜨면 showkeyword의 확률 문제
            }
        }
    }

    private void TrueKeyBoardFalse() { //옳은 키워드 키보드 끄기 = 끄기 반전

        parentKeyBoard.enabled = false; //키보드의 부모의 SpriteRenderer를 꺼주고
        childKeyBoard.enabled = false; //자식의 SpriteRenderer도 꺼준다.

        // Invoke("TrueKeyBoardTrue", 2f);
    }

    private void TrueKeyBoardTrue() { //옳은 키워드 키보드 복구 = 턴 지나면 살리기

        foreach (GameObject aa in previousKeyBoard) {

            aa.GetComponent<SpriteRenderer>().enabled = true;
            aa.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true; //- 오류가 많이 뜸
        }
    }

    private void FalseKeyBoardFalse() { //옳지 않은 키워드 키보드 끄기 = 정상
        parentKeyBoard.enabled = false; //키보드의 부모의 SpriteRenderer를 꺼주고
        childKeyBoard.enabled = false; //자식의 SpriteRenderer도 꺼준다.
    }
    
    public void AllKeyBoardTrue() { //모든 키보드 복구 = 피버타임 보상 (테스트 성공)
    
        foreach (GameObject dd in keyBoard) {

            dd.GetComponent<SpriteRenderer>().enabled = true;
            dd.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }

    private void PreviousSaveListClear() { //이전의 키보드를 저장해둔 리스트 초기화
        previousKeyBoard.Clear();
    }

    private void KeyWordTypeCompare(string keyWordType) { //옳은 코딩(비영구)라면 복구를 위해 삭제한 키보드를 담아둠

        // Debug.Log("옳은 코딩");

        previousKeyBoard.Add(parentKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (부모)
        previousKeyBoard.Add(childKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (자식);

        Invoke("TrueKeyBoardTrue", 3f); //비영구 키워드의 키보드 복구 메서드
    }

}