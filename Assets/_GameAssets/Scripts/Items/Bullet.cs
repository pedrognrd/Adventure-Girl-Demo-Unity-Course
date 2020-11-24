using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject collisionFind;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Animator>().SetTrigger("Dying");
            collision.GetComponent<Enemy>().dying = true;
            //StartCoroutine(MyFunction(false, 1f));
        }
        if (collision.CompareTag("Player") == false)
        {
            //Sólo se destruye si no "hacer trigger" contra el player
            Destroy(gameObject);
        }
    }

    IEnumerator MyFunction(bool status, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        // Now do your thing here
        collisionFind.GetComponent<Enemy>().dying = true;
    }
}
