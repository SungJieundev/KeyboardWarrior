using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    
    public int curScore = 0;

    public int addScore = 0;

    private void Awake() {
        scoreTxt.text = "Score : 0";
    }

    private void Update() {
        scoreTxt.text = $"Score : {curScore}";
    }
}
