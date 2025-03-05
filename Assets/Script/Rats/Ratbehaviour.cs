using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Ratbehaviour : MonoBehaviour
{   
    public NavMeshAgent navMesh;
    [SerializeField] Transform goal;
     Animator animator;

     public bool isDead=false;
     private bool goal1,goal2, goal3;   
     public bool isGreen;

     public Transform[] goalPositions;

    private bool deathSoundPlayed = false;


    void Start()
    {   
        goal=GameObject.Find("Goal").GetComponent<Transform>();
        navMesh=GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
        goalPositions[0]= GameObject.Find("Goal1").GetComponent<Transform>();
        goalPositions[1]= GameObject.Find("Goal2").GetComponent<Transform>();
        goalPositions[2]= GameObject.Find("Goal3").GetComponent<Transform>();
        
        isGreen= gameObject.name=="RatVerdePrefab(Clone)" ;
        
          
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
            if (!deathSoundPlayed)
            {
                StartCoroutine(PlayDeathSoundWithDelay(0.3f));
                deathSoundPlayed = true;
            }
            
           gameObject.GetComponent<NavMeshAgent>().enabled=false;
           animator.SetBool("isDead",true);
           gameObject.GetComponent<Collider>().enabled=false;
           Destroy(this.gameObject,5);

        }

        
    }

    IEnumerator PlayDeathSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AudioManager.instance.PlaySound(AudioManager.instance.ratDeathSound);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {   
            GameManager.Instance.HumanParasiteLevel();
            if (isGreen)
            {
                 GameManager.Instance.HumanParasiteLevel();
                 GameManager.Instance.HumanParasiteLevel();
            }
            Destroy(this.gameObject);
            
          
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

     
    }




}
