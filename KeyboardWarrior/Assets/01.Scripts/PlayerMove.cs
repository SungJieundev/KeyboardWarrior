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

            originPosition = gameObject.transform.position;

            targetPosition = new Vector2(playerPosX, playerPosY + 1);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);

            playerPosX = gameObject.transform.position.x;
            playerPosY = gameObject.transform.position.y;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){

            originPosition = gameObject.transform.position;

            targetPosition = new Vector2(playerPosX, playerPosY - 1);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;
            
            gameObject.transform.Translate(targetPosition);

            playerPosX = gameObject.transform.position.x;
            playerPosY = gameObject.transform.position.y;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            
            originPosition = gameObject.transform.position;

            targetPosition = new Vector2(playerPosX - 1, playerPosY);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);

            playerPosX = gameObject.transform.position.x;
            playerPosY = gameObject.transform.position.y;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){

            originPosition = gameObject.transform.position;

            targetPosition = new Vector2(playerPosX + 1, playerPosY);
            //ResetToInt();
            //gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, targetPosition, 0.5f);
            //gameObject.transform.position = targetPosition;

            gameObject.transform.Translate(targetPosition);

            playerPosX = gameObject.transform.position.x;
            playerPosY = gameObject.transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        gameObject.transform.position = originPosition;
    }

    // private void ResetToInt(){

    //     targetPosition.x = (int)targetPosition.x; 
    //     targetPosition.y = (int)targetPosition.y;
    // }
}
