using UnityEngine;
using UnityEngine.AI;

public class Ratbehaviour : MonoBehaviour
{   
    public NavMeshAgent navMesh;
    [SerializeField] Transform goal;
     Animator animator;

    public bool goal0,goal1,goal2,finalGoal;
    public Transform[] goalPositions;
    void Start()
    {   
        finalGoal=false;
        goal0=false;
        goal=GameObject.Find("Goal").GetComponent<Transform>();
        navMesh=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        goalPositions[0]=GameObject.Find("TrashBag01").transform;
        goalPositions[1]=GameObject.Find("TrashBag02").transform;
        goalPositions[2]=GameObject.Find("TrashBag03").transform;
    }

    
    void Update()
    {   
        if (!goal0)
        {
            navMesh.SetDestination(goalPositions[0].position);
        }

        else if(!goal1)
        {
            navMesh.SetDestination(goalPositions[1].position);

        }

        else if(!goal2)
        {
           navMesh.SetDestination(goalPositions[2].position);
        }
        
        else if (!finalGoal)
        {   
           print("llego al final");
            navMesh.SetDestination(goal.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            finalGoal=!finalGoal;
            animator.SetBool("isDead",true);

        }        
          
        if (other.CompareTag("Trash1"))
        {   
         
            goal0=true;
        }  
        
        if (other.CompareTag("Trash2"))
        {
             goal1=true;
        }  
        
        if (other.CompareTag("Trash3"))
        {
             goal2=true;
        }  
    }




}
