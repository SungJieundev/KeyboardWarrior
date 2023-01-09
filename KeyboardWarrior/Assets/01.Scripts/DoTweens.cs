// using System.Net.Mime;
// using System.ComponentModel;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;
// using TMPro;

// public class DoTweens : MonoBehaviour
// {
//     public static DoTweens instance;

//     private void Awake() {
//         if (!instance) instance = this;
//         else { Destroy(gameObject); }
//     }


//     // private string myString;
//     public void DoString(string msg, TextMeshProUGUI txt, float time) { //글자 타닥타닥 해주는 거
//         // txt.GetComponent<text>().d);
//         // DOTween.To(() => "", str => myString = str, "tlqkf", 3);
//     }

//     public void DoTColor(GameObject obj, Color color, float time) {

//         obj.GetComponent<Material>().DOColor(color, time);
//     }
// }
