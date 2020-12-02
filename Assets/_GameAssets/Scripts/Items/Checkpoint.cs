using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        // When player collides with a checkpoint, flag is open and game data saved
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Checked", true);
            GameObject.Find("GameManager").GetComponent<GameManager>().StateSave();
        }
    }
}
