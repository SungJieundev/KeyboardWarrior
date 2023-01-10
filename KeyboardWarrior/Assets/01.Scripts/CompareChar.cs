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

    KeyboardPushed keyboardPushed;

    [SerializeField] private TextMeshProUGUI keyWordTxt;

    [SerializeField] private List<GameObject> keyBoard = new List<GameObject>();

    private string keyWord;

    [SerializeField] private float duration;

    private GameObject[] rreviousKeyBoard;

    private void Awake() {

        if (!instance) instance = this;
        else { Destroy(gameObject); }

        keyboardPushed = FindObjectOfType<KeyboardPushed>();
    }


    public void Compare() {

        keyWord = keyWordTxt.text;

        for (int i = 0; i < keyWord.Length; i++) { //제시어 글자 수 만큼 반복

            for (int j = 0; j < keyBoard.Count; j++) { //키보드 수 만큼 반복

                if (keyWord[i].ToString() == keyBoard[j].name) { //제시어의 n번째 글자와 키보드의 m번째 이름이 맞다면

                    DoTweens.instance.DoTColor(keyBoard[j].transform.GetChild(0).gameObject,
                        Color.red, duration); //키보드의 자식(레이어가 더 위)의 색으로 경고를 표시한다.
                    //다트윈 시간이 끝나면 아래의 .enabled 실행

                    keyBoard[j].GetComponent<SpriteRenderer>().enabled =false; //키보드의 부모의 sr을 꺼주고
                    keyBoard[j].transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false; //자식도 꺼준다.
                    // = 구멍이 뚫린 거 처럼 보임 / SetActive 안 하는 이유는 충돌 감지를 계속 해야하기 때문

                    // if () { //영구인지 비영구인지 / 영구라면

                    // }
                }
            }
        }
    }
}
