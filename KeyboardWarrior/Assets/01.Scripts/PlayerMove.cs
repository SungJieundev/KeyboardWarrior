using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float playerPosX;
    private float playerPosY;
    private Vector2 targetPosition;
    private Vector2 originPosition;


    private void Update() {
        
        Move1Unit();
    }
    public void Move1Unit(){
        
        if(Input.GetKeyDown(KeyCode.UpArrow)){

            Debug.Log(targetPosition);
            ResetPos();

            targetPosition = new Vector2(playerPosX, playerPosY + 1);
            PositionSetInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            gameObject.transform.position = targetPosition;

            //gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){

            Debug.Log(targetPosition);
            ResetPos();

            targetPosition = new Vector2(playerPosX, playerPosY - 1);
            PositionSetInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            gameObject.transform.position = targetPosition;
            
            //gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            Debug.Log(targetPosition);
            ResetPos();

            targetPosition = new Vector2(playerPosX - 1, playerPosY);
            PositionSetInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            gameObject.transform.position = targetPosition;

            //gameObject.transform.Translate(targetPosition);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
Debug.Log(targetPosition);
            ResetPos();

            targetPosition = new Vector2(playerPosX + 1, playerPosY);
            PositionSetInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            gameObject.transform.position = targetPosition;

            //gameObject.transform.Translate(targetPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        gameObject.transform.position = originPosition;
    }

    private void ResetPos(){

        originPosition = gameObject.transform.position;
        playerPosX = originPosition.x;
        playerPosY = originPosition.y;
    }

    public void PositionSetInt(){

        targetPosition.x = (int)targetPosition.x;
        targetPosition.y = (int)targetPosition.y;
    }
}
