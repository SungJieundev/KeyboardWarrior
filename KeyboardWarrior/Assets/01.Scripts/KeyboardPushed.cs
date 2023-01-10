using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPushed : MonoBehaviour
{
    public SpriteRenderer sr;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) { //tirgger 충돌한다면

        if (other.CompareTag("Player")) { //충돌한 상대 오브젝트의 태그가 player라면
        
            transform.Find("c").gameObject.SetActive(false); //자식을 꺼준다 = 눌린 이미지보임
        }
    }

    private void OnTriggerExit2D(Collider2D other) { //tirgger 충돌이 끝난다면
        transform.Find("c").gameObject.SetActive(true); //자식을 꺼준다 = 눌린 이미지보임
    }

    //이동 못 하는 곳에 비빌 때 현재 위치 꺼지는 거 고쳐야함
}
