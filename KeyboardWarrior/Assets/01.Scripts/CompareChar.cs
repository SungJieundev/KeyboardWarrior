using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompareChar : MonoBehaviour
{
    public static CompareChar instance;
    [SerializeField] private TextMeshProUGUI keyWordTxt;

    private string keyWord;

    private void Awake() {

        if (!instance) instance = this;
        else { Destroy(gameObject); }
    }


    public void Compare() {

        keyWord = keyWordTxt.text;

        for (int i = 0; i < keyWord.Length; i++) {

            GameObject dd = GameObject.Find($"{keyWord[i]}");
            dd.SetActive(false); //찾아서 펄스
            Debug.Log(dd);
        }
    }
}
