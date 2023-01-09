using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float playerPosX;
    private float playerPosY;
    private Vector3 targetPosition;


    private void Update() {
        
        Move1Unit();
    }
    public void Move1Unit(){

        playerPosX = gameObject.transform.position.x;
        playerPosY = gameObject.transform.position.y;

        if(Input.GetKeyDown(KeyCode.UpArrow)){

            targetPosition = new Vector2(playerPosX, playerPosY + 1);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){

            targetPosition = new Vector2(playerPosX, playerPosY - 1);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;
            
            gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){

            targetPosition = new Vector2(playerPosX - 1, playerPosY);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){

            targetPosition = new Vector2(playerPosX + 1, playerPosY);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);
        }
    }

    // private void ResetToInt(){

    //     targetPosition.x = (int)targetPosition.x; 
    //     targetPosition.y = (int)targetPosition.y;
    // }
}
