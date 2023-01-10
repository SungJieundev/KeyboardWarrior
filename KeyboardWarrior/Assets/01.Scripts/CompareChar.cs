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

    public void Compare(string keyWordType) {

        keyWord = keyWordTxt.text;

        for (int i = 0; i < keyWord.Length; i++) { //제시어 글자 수 만큼 반복

            for (int j = 0; j < keyBoard.Count; j++) { //키보드 수 만큼 반복

                if (keyWord[i].ToString() == keyBoard[j].name) { //제시어의 n번째 글자와 키보드의 m번째 이름이 맞다면

                    parentKeyBoard = keyBoard[j].GetComponent<SpriteRenderer>();
                    childKeyBoard = keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();

                    DoTweens.instance.DoTColor(childKeyBoard.gameObject,
                        Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                    //다트윈 시간이 끝나면 아래의 .enabled 실행

                    TrueKeyBoardFalse(); // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문
                    
                    KeyWordTypeCompare(keyWordType); //키워드 타입 비교 / 영구, 비영구 / 매개변수 = 키워드 타입
                }
            }
        }
    }

    private void TrueKeyBoardFalse() { //옳은 키워드 키보드 끄기 = 끄기 반전

        parentKeyBoard.enabled =false; //키보드의 부모의 SpriteRenderer를 꺼주고
        childKeyBoard.enabled = false; //자식의 SpriteRenderer도 꺼준다.
    }

    private void TrueKeyBoardTrue() { //옳은 키워드의 키보드 복구 = 턴 지나면 살리기

    }

    private void FalseKeyBoardFalse() { //옳지 않은 키워드 키보드 끄기 = 정상

    }
    
    public void AllKeyBoardTrue() { //모든 키보드 복구 = 피버타임 보상

    }

    private void PreviousSaveListClear() { //이전의 키보드를 저장해둔 리스트 초기화
        previousKeyBoard.Clear();
    }

    private void KeyWordTypeCompare(string keyWordType) { //키워드 타입 비교 / 옳, 옳 않
        if (keyWordType == "long") { //비영구라면

            Debug.Log("옳은 코딩");

            previousKeyBoard.Add(parentKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (부모)
            previousKeyBoard.Add(childKeyBoard.gameObject); //리스트에 이전의 키보드를 담아준다. (자식);

            Invoke("KeyBoardTrue", 5f); //비영구 키워드의 키보드 복구 메서드
        }
        else if (keyWordType == "short") { Debug.Log("옳지 않은 코딩"); }
        else { Debug.LogError("코딩이 옳지도 옳지 않지도 않음 == 오류");}
    }

}