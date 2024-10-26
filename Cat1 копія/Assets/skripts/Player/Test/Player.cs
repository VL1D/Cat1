using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController play;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            play.OnRightButtonDown();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                play.OnJumpButtonDown();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            play.OnLeftButtonDown();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                play.OnJumpButtonDown();
            }
        }
        else if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D))
        {
            play.OnButtonUp();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            play.OnJumpButtonDown();
        }
    }
}
