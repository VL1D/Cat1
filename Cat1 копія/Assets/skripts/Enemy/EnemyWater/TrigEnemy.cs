using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigEnemy : MonoBehaviour
{
    public PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            EnemyWaterRespawn.instance.EnemyWatResp();
            StartCoroutine(Delete());
            playerController.normalSpeed = 0;
            playerController.speed = 0;
            playerController.Run = false;
            playerController.jumpForce = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerController.speed = 0;
            playerController.Run = false;
            playerController.jumpForce = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            playerController.normalSpeed = 40f;
            playerController.jumpForce = 35f;
        }
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);

    }
}
