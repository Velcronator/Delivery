using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 3f;
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 35, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    private SpriteRenderer spriteRenderer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision a " + collision.gameObject);
    }

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Alien")
        {
            if (!hasPackage)
            {
                SceneManager.LoadScene(0);
            }

            Animator anim = collision.gameObject.GetComponentInChildren<Animator>();
            anim.SetTrigger("Die");
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }

        if (collision.tag == "Package" && !hasPackage)
        {
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
        }

    }
}
