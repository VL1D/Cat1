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
            playerController.speed = 0;
            playerController.jumpForce = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            
            playerController.jumpForce = 35f;
        }
    }
    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}
