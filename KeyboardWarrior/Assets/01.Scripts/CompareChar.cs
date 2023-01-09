using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompareChar : MonoBehaviour
{
    public static CompareChar instance;
    [SerializeField] private TextMeshProUGUI keyWordTxt;

    private string keyWord;

    [SerializeField] private float duration;

    private void Awake() {

        if (!instance) instance = this;
        else { Destroy(gameObject); }
    }


    public void Compare() {

        keyWord = keyWordTxt.text;

        for (int i = 0; i < keyWord.Length; i++) {

            GameObject dd = GameObject.Find($"{keyWord[i]}");
            DoTweens.instance.DoTColor(dd, Color.red, duration); //이거 자체에서 시간 보내줌ㅎㅎ
            dd.SetActive(false); //찾아서 펄스
        }
    }
}
