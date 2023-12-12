using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMobement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private float croughHeight = 0.5f;
    [SerializeField] private float fallingDrag = 40f;

    private bool isGrounded = false;
    private bool isJumped = false;


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);
        #region JUMPING
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            Jump();
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            ChangeDragWhileFalling();
        }
        else
        {
            rb.drag = 7f;
        }



        #endregion

        #region CROUCHING
        if (isGrounded && Input.GetButton("Crough"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, croughHeight, GFX.localScale.z);
        }

        if(isJumped && Input.GetButton("Crough"))     
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        }



        if (Input.GetButtonUp("Crough"))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        }

        #endregion

    }

    void ChangeDragWhileFalling()
    {

        if (Input.GetButton("Jump"))
        {
            rb.drag = fallingDrag;
        }
        else
        {
            rb.drag = 0f; 
        }
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

}
