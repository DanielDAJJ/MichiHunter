using UnityEngine;
using UnityEngine.AI;

public class Ratbehaviour : MonoBehaviour
{   
    public NavMeshAgent navMesh;
    [SerializeField] Transform goal;
     Animator animator;
    void Start()
    {   
        goal=GameObject.Find("Goal").GetComponent<Transform>();
        navMesh=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
    }

    
    void Update()
    {
        navMesh.SetDestination(goal.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            //Destroy(this.gameObject);
            animator.SetBool("isDead",true);

        }        
    }




}
