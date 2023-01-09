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
        keyWord = keyWordTxt.text;
        Compare();
    }


    public void Compare() {
        for (int i = 0; i < keyWord.Length; i++) {

            GameObject.Find($"{keyWord[i]}").SetActive(false); //찾아서 펄스
            Debug.Log(keyWord);
        }
    }
}
