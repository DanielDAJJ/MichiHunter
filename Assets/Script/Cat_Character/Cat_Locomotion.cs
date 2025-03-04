using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Locomotion : MonoBehaviour
{
    public float jumpHeight;
    public float gravity;
    public float stepDown;
    public float airControl;
    public float jumpDamp;
    public float groundSpeed;
    

    Animator animator;
    CharacterController cc;

    Vector2 input;
    Vector2 smoothInput;
    Vector2 inputVelocity;

    float smoothTime = 0.2f;

    Vector3 rootMotion;
    Vector3 velocity;
    bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");


        
        smoothInput.x = Mathf.SmoothDamp(smoothInput.x, input.x, ref inputVelocity.x, smoothTime);
        smoothInput.y = Mathf.SmoothDamp(smoothInput.y, input.y, ref inputVelocity.y, smoothTime);

        
        animator.SetFloat("InputX", smoothInput.x);
        animator.SetFloat("InputY", smoothInput.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        
    }

    private void OnAnimatorMover()
    {
        rootMotion += animator.deltaPosition;

    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            UpdateInAir();

        }
        else
        {
            UpdateOnGround();

        }

        /*cc.Move(rootMotion);
        rootMotion = Vector3.zero;*/
    }

    private void UpdateOnGround()
    {
        Vector3 stepForwardAmount = rootMotion * groundSpeed;
        Vector3 stepDownAmount = Vector3.down * stepDown;
        
        cc.Move(stepForwardAmount + stepDownAmount);
        rootMotion = Vector3.zero;

        if (!cc.isGrounded)
        {
            SetInAir(0);
            
        }
    }

    private void UpdateInAir()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        Vector3 displacement = velocity * Time.fixedDeltaTime;
        displacement += CalculateAirContol();
        cc.Move(displacement);
        isJumping = !cc.isGrounded;
        rootMotion = Vector3.zero;
        animator.SetBool("IsJumping", isJumping);
    }

    Vector3 CalculateAirContol()
    {
        return((transform.forward * input.y) + (transform.right * input.x)) * (airControl / 100);

    }

    void Jump()
    {
        if(!isJumping)
        {
            float jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);
            SetInAir(jumpVelocity);

        }

    }

    private void SetInAir(float jumpVelocity)
    {
        isJumping = true;
        velocity = animator.velocity * jumpDamp * groundSpeed;
        velocity.y = jumpVelocity;
        animator.SetBool("IsJumping", true);
    }

    
}






