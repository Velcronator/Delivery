using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision a " + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Alien")
        {
            Debug.Log("Trigger a " + collision.gameObject);
            if (!hasPackage)
            {
                SceneManager.LoadScene(0);
            }
            hasPackage = false;
        }

        if (collision.tag == "Package")
        {
            hasPackage = true;
            Debug.Log("Trigger a " + collision.gameObject);
        }

    }
}
