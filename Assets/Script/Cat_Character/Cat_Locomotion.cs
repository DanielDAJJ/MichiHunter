using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Locomotion : MonoBehaviour
{
    Animator animator;
    CharacterController cc;
    Vector2 input;
    Vector2 smoothInput;
    Vector2 inputVelocity;
    float smoothTime = 0.2f;

    Vector3 rootMotion;

    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        // Suavizamos la transición de valores
        smoothInput.x = Mathf.SmoothDamp(smoothInput.x, input.x, ref inputVelocity.x, smoothTime);
        smoothInput.y = Mathf.SmoothDamp(smoothInput.y, input.y, ref inputVelocity.y, smoothTime);

        // Pasamos los valores al Animator
        animator.SetFloat("InputX", smoothInput.x);
        animator.SetFloat("InputY", smoothInput.y);
        
    }

    private void OnAnimatorMover()
    {
        rootMotion += animator.deltaPosition;

    }

    private void FixedUpdate()
    {
        cc.Move(rootMotion);
        rootMotion = Vector3.zero;
    }
}






