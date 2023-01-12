using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPushed : MonoBehaviour
{
    FeverTime feverTime;
    GameMain gameMain;
    public SpriteRenderer sr;

    public string curKeyName;

    private void Awake() {

        feverTime = FindObjectOfType<FeverTime>();
        gameMain = FindObjectOfType<GameMain>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) { //tirgger 충돌한다면

        if (other.CompareTag("Player")) { //충돌한 상대 오브젝트의 태그가 player라면
        
            transform.Find("c").gameObject.SetActive(false); //자식을 꺼준다 = 눌린 이미지보임
            curKeyName = gameObject.name;
            // if (feverTime.needFK) feverTime.FeverKeyTirgger(curKeyName);

            if (!sr.enabled) {

                Debug.Log("die");

                gameMain.isPlayer = false;
                Destroy(other.gameObject); //검정인 곳 밟는다면 디스트로이
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) { //tirgger 충돌이 끝난다면
    
        transform.Find("c").gameObject.SetActive(true); //자식을 켜준다
    }

    //이동 못 하는 곳에 비빌 때 현재 위치 꺼지는 거 고쳐야함
}
