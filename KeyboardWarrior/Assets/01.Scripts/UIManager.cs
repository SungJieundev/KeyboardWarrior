using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI maxScoreTxt;   
    public int curScore = 0;

    public int addScore = 0;

    private int maxScore = 0;

    private void Awake() {

        scoreTxt.text = "Score : 0";
    }

    private void Update() {

        // if (curScore >= maxScore) maxScoreTxt.text = $"Max Score : {maxScore}";
        scoreTxt.text = $"Score : {curScore}";

    }
}
