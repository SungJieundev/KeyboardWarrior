using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTween : MonoBehaviour
{
    public static DoTween instance;

    private void Awake() {
        if (!instance) instance = this;
        else { Destroy(gameObject); }
    }

    public void DoString(string msg, TextMeshProUGUI txt, float time) { //글자 타닥타닥 해주는 거
        
    }

    public void DoTColor(GameObject d, Color color, float time) {
        
    }
}
