using System.Net.Mime;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTweens : MonoBehaviour
{
    [SerializeField] private int dotCount;

    public void DoString(string msg, TextMeshProUGUI txt, float time) { //글자 타닥타닥 해주는 거        

        txt.DOText(msg, time);
    }

    public void DoTColor(GameObject obj, Color color, float time) {

        obj.GetComponent<Material>().DOColor(color, time);
    }

    public void LoopColor(List<GameObject> obj, Color currentColor, Color endColor, float time){

        for (int i = 0; i < dotCount; i++) {

            for (int j = 0; j < obj.Count; j++) {

                Material objMaterial = obj[j].GetComponent<Material>();

                Sequence sequence = DOTween.Sequence();
                
                Debug.Log("loopColor");
                sequence.Append(objMaterial.DOColor(endColor, time));
                sequence.Append(objMaterial.DOColor(currentColor, time));

            }
        }
    }

    public void PanelDown(){


    }
}
