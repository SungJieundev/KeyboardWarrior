using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPushed : MonoBehaviour
{
    CompareChar compareChar;
    FeverTime feverTime;
    GameMain gameMain;
    DoTweens doTweens;

    public SpriteRenderer sr;

    public string curKeyName;

    private void Awake() {

        compareChar = FindObjectOfType<CompareChar>();
        feverTime = FindObjectOfType<FeverTime>();
        gameMain = FindObjectOfType<GameMain>();
        doTweens = FindObjectOfType<DoTweens>();

        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) { //tirgger 충돌한다면

        if (other.CompareTag("Player")) { //충돌한 상대 오브젝트의 태그가 player라면
        
            transform.Find("c").gameObject.SetActive(false); //자식을 꺼준다 = 눌린 이미지보임
            curKeyName = gameObject.name;

            if (feverTime.needFK) feverTime.FeverKeyTirgger(curKeyName);

            if (!sr.enabled) {

                Debug.LogError("Player Die");

                doTweens.PanelDown(doTweens.panel);
                gameMain.isPlayer = false;
                Destroy(other.gameObject); //검정인 곳 밟는다면 디스트로이
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) { //tirgger 충돌이 끝난다면
    
        transform.Find("c").gameObject.SetActive(true); //자식을 켜준다
    }
}
