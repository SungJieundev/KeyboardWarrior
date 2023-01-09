using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPushed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) { //tirgger 충돌한다면
        if (other.CompareTag("Player")) { //충돌한 상대 오브젝트의 태그가 player라면
            transform.Find("c").gameObject.SetActive(false); //자식을 꺼준다 = 눌린 이미지보임
        }
    }
}
