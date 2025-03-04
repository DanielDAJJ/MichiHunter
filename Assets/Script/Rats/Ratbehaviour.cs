using UnityEngine;
using UnityEngine.AI;

public class Ratbehaviour : MonoBehaviour
{   
    public NavMeshAgent navMesh;
    [SerializeField] Transform goal;
     Animator animator;

     private bool isDead=false;
     private bool goal1,goal2, goal3;   

     public Transform[] goalPositions;


    void Start()
    {   
        goal=GameObject.Find("Goal").GetComponent<Transform>();
        navMesh=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        goalPositions[0]= GameObject.Find("Goal1").GetComponent<Transform>();
        goalPositions[1]= GameObject.Find("Goal2").GetComponent<Transform>();
        goalPositions[2]= GameObject.Find("Goal3").GetComponent<Transform>();

    }

    
    void Update()
    {
         
        if (!goal1 && !isDead)
        {
          navMesh.SetDestination(goalPositions[0].position); 
        }

        else if(!goal2 && !isDead)
        {

          navMesh.SetDestination(goalPositions[1].position); 
        }
         else if(!goal3 && !isDead)
        {

          navMesh.SetDestination(goalPositions[2].position); 
        }

        else if(!isDead)
        {
          navMesh.SetDestination(goal.position); 

        }

        if (isDead)
        {
            navMesh.isStopped=true;
            
            gameObject.GetComponent<Collider>().enabled=false;

        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Destroy(this.gameObject);
            animator.SetBool("isDead",true);

        }    

           if (other.CompareTag("Trash1"))
        {
            goal1=true;

        }  
           if (other.CompareTag("Trash2"))
        {
          
           goal2=true;

        }  
           if (other.CompareTag("Trash3"))
        {
          
            goal3=true;
        }      

           if (other.CompareTag("Player"))
        {
    
            animator.SetBool("isDead",true);
            isDead=true;

        }     
    }




}
