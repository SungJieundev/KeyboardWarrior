using System.Net.Mime;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DoTweens : MonoBehaviour
{
    public void DoString(string msg, TextMeshProUGUI txt, float time) { //글자 타닥타닥 해주는 거        

        txt.DOText(msg, time);
    }

    public void DoTColor(GameObject obj, Color color, float time) {

        obj.GetComponent<Material>().DOColor(color, time);
    }

    public void LoopColor(List<GameObject> obj, Color currentColor, Color endColor, float time){

        for (int i = 0; i < obj.Count; i++) {

            Material objMaterial = obj[i].GetComponent<Material>();

            Sequence sequence = DOTween.Sequence();
            
            sequence.Append(objMaterial.DOColor(endColor, time));
            sequence.Append(objMaterial.DOColor(currentColor, time));
        }
    }
}
