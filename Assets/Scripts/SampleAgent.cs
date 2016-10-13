using UnityEngine;
using System.Collections;

public class SampleAgent : MonoBehaviour
{
    public float speed;

    private Vector3 targetPosition;

    private NavMeshAgent agent;
    
    private Animator animator;
    private bool jumping;

    // Use this for initialization
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = agent.speed * speed;
        targetPosition = transform.position;

        jumping = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (agent.remainingDistance < 1.0F)
        {

            //Debug.Log("I love big butts and I cannot lie");
            agent.velocity = Vector3.zero;
            agent.ResetPath();
            animator.SetBool("isWalking", false);
        }
        else
        {
            if(agent.isOnOffMeshLink)
            {
                Debug.Log("Jump TIme");
                animator.SetBool("walkToJump", true);
                jumping = true;
            }
            else
            {
                if(jumping)
                {
                    Debug.Log("STOP");
                    animator.SetBool("walkToJump", false);
                    jumping = false;
                }
               
            }
           
           // agent.SetDestination(targetPosition);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                animator.SetBool("isWalking", true);
                targetPosition = hit.point;
                agent.SetDestination(targetPosition);

            }
        }
    }
   
}
