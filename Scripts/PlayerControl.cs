using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator Animator;
    private float horizontal;
    private bool crouch = false;
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Animator.SetBool("IsJump", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }
    public void onLanding() {
        Animator.SetBool("IsJump", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        Animator.SetBool("Crouch", isCrouching);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime * 40, crouch, jump);
        jump = false;
    }
}
