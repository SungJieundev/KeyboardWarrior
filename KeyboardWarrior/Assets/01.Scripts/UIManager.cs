using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI maxScoreTxt;   

    private DoTweens doTweens;
    
    public GameObject escPanel;
    public int curScore = 0;

    public int addScore = 0;

    private int maxScore = 0;

    public bool isPressedESC = false;

    private void Awake() {


        scoreTxt.text = "Score : 0";
    }

    private void Update() {

        // if (curScore >= maxScore) maxScoreTxt.text = $"Max Score : {maxScore}";
        scoreTxt.text = $"Score : {curScore}";

        if(Input.GetKeyDown(KeyCode.Escape)){

            if(isPressedESC == true){

                doTweens.PanelUp(escPanel);
                isPressedESC = false;
            }

            if(isPressedESC == false){

                doTweens.PanelDown(escPanel);
                isPressedESC = true;
            }
        }
    }
}
