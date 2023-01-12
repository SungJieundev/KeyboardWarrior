using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI maxScoreTxt;   
    [SerializeField] private TextMeshProUGUI curScoreTxt;   

    private DoTweens doTweens;
    
    public GameObject escPanel;
    public int curScore = -30;

    public int addScore = 0;

    private int maxScore = 0;

    public bool isPressedESC = true;

    private void Awake() {

        doTweens = GetComponent<DoTweens>();
        scoreTxt.text = "Score : 0";
    }

    private void Update() {

        maxScore = PlayerPrefs.GetInt("MaxScore");

        scoreTxt.text = $"Score : {curScore}";

        if (curScore >= maxScore) {

            maxScore = curScore;
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }

        maxScoreTxt.text = maxScore.ToString();
        curScoreTxt.text = curScore.ToString();

        if(Input.GetKeyDown(KeyCode.Escape)){

            if (isPressedESC == true) {

                doTweens.PanelDown(escPanel);
                isPressedESC = !isPressedESC;
            }
            else {

                doTweens.PanelUp(escPanel);
                isPressedESC = !isPressedESC;
            }
        }
    }
}
