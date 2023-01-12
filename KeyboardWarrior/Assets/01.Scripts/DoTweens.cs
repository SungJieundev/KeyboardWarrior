using System.Net.Mime;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTweens : MonoBehaviour
{
    CompareChar compareChar;
    FeverTime feverTime;

    private void Awake() {

        compareChar = GetComponent<CompareChar>();
        feverTime = GetComponent<FeverTime>();
    }

    public void DoString(string msg, TextMeshProUGUI txt, float time) { //글자 타닥타닥 해주는 거        

        txt.DOText(msg, time);
    }

    public void DoTColor(GameObject obj, Color color, float time) {

        obj.GetComponent<Material>().DOColor(color, time);
    }

    public void LoopColor(GameObject obj, Color currentColor, Color endColor, float time, string keyWordType){


        SpriteRenderer objsr = obj.GetComponent<SpriteRenderer>();

        Sequence sequence = DOTween.Sequence();
        
        for (int i = 0; i < 2; i++) {

            if (!feverTime.feverTiming) {

                sequence.Append(objsr.DOColor(endColor, time));
                sequence.Append(objsr.DOColor(currentColor, time));

                sequence.OnComplete(() => {

                    compareChar.KeyBoardFalse(keyWordType);
                });
            }   
        }
    }

    private Vector3 originalTransform;

    public void PanelDown(GameObject panel){

        originalTransform = panel.transform.position;

        panel.transform.DOLocalMove(new Vector3(0, 26f, 0), 1f);

    }

    public void PanelUp(GameObject panel){

        panel.transform.DOMove(originalTransform, 0.5f);
    }
    
}
