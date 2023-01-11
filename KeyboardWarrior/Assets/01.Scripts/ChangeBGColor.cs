
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{
    [SerializeField] private List<Color> backGroundColorList = new List<Color>();
    [SerializeField] private Camera mainCamera;
    private int ran;
    public void Change() {

        ran = Random.Range(0, backGroundColorList.Count);

        mainCamera.backgroundColor = backGroundColorList[ran];
    }
}
