using UnityEngine;
using System.Collections;

public class SampleAgent : MonoBehaviour
{
    public float speed;

    private Vector3 targetPosition;

    private NavMeshAgent agent;
    
    private Animator animator;
    private bool jumping;
    private bool moving;
   // private bool walking;

    // Use this for initialization
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.speed = agent.speed * speed;
        targetPosition = transform.position;

        jumping = false;
        moving = false;
        //walking = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (agent.remainingDistance < 1.0F)
        {
            agent.velocity = Vector3.zero;
            agent.ResetPath();
            animator.SetBool("isWalking", false);
            animator.SetBool("jump", false);
            moving = false;
        }
        else
        {
            if(agent.isOnOffMeshLink)
            {
                animator.SetBool("jump", true);
                jumping = true;
            }
            else
            {
                if(jumping)
                {
                    animator.SetBool("jump", false);
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
                animator.SetFloat("Speed", 1.0f);

                //  walking = true;
                targetPosition = hit.point;
                agent.SetDestination(targetPosition);
                moving = true;

            }
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(moving)
            {
                animator.SetBool("shiftPressed", true);

               // walking = false;
            }
        }
        else
        {
            animator.SetBool("shiftPressed", false);
          //  walking = true;
        }
    }

}
