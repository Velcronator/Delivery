using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float steerSpeed = 150f;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveAmount);

        if (Mathf.Abs(steerAmount) > 0)
        {
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, 0.005f, 0);
            animator.SetFloat("Speed", 0.1f);
        }
        else
        {
            transform.Translate(0, moveAmount, 0);
        }

    }
}
