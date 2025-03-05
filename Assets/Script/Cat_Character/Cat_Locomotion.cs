using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat_Locomotion : MonoBehaviour
{   
    [SerializeField] Transform attackPoint;
    public LayerMask enemyMask;

    public int playerParasitelevel;
    Ratbehaviour rat;
    
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

    //float smoothTime = 0.2f;
    float smoothTimeHorizontal = 0.1f;
    float smoothTimeVertical = 0.1f;

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



        smoothInput.x = Mathf.SmoothDamp(smoothInput.x, input.x, ref inputVelocity.x, smoothTimeHorizontal);
        smoothInput.y = Mathf.SmoothDamp(smoothInput.y, input.y, ref inputVelocity.y, smoothTimeVertical);


        animator.SetFloat("InputX", smoothInput.x);
        animator.SetFloat("InputY", smoothInput.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (Input.GetMouseButtonDown(0) && cc.isGrounded)
        {
            CatAttack();
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
        float horizontalMultiplier = 1.2f; // Ajusta seg�n lo que necesites
        Vector3 modifiedRootMotion = new Vector3(rootMotion.x * horizontalMultiplier, rootMotion.y, rootMotion.z);

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


    public void CatAttack() // Metodo para el ataque del gato.
    {
        animator.SetTrigger("Attack"); 
        Collider[] enemies = Physics.OverlapSphere(attackPoint.position,0.3f, enemyMask);
        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<Ratbehaviour>().isDead=true;
            GameManager.Instance.PlayerParasiteLevel();
        }
        playerParasitelevel = GameManager.Instance.playerParasiteLevel;

    }


    private void SetInAir(float jumpVelocity)
    {
        isJumping = true;
        velocity = animator.velocity * jumpDamp * groundSpeed;
        velocity.y = jumpVelocity;
        animator.SetBool("IsJumping", true);
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.white;
        Gizmos.DrawSphere(attackPoint.position,0.3f);
    }
}






