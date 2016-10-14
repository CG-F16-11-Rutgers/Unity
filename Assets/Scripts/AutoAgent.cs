using UnityEngine;
using System.Collections;

public class AutoAgent : MonoBehaviour {

    private float speed= 0.1F;

    public GameObject goal;
    public GameObject finalGoal;

    private Vector3 targetPosition;

    private NavMeshAgent agent;

    private Animator animator;
    private bool jumping;
    private bool moving;
    private bool firstGoal;

    private float rD;

    private bool firstTime;
    // Use this for initialization
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.speed = agent.speed * speed;

        rD = float.MaxValue;
        firstGoal = true;
        targetPosition = goal.transform.position;

        firstTime = true;
        jumping = false;
        moving = false;
        //walking = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.remainingDistance);
        if (rD < 2.0)
        {
            if (firstGoal == true)
            {
                targetPosition = finalGoal.transform.position;
                agent.SetDestination(targetPosition);
                firstGoal = false;


            }
            else
            {
                agent.velocity = Vector3.zero;
                agent.ResetPath();
                animator.SetBool("isWalking", false);
                animator.SetBool("jump", false);
                moving = false;
            }
        }
        else
        {
            if(firstTime)
            {
                if(agent.remainingDistance> 1.0)
                {
                    rD = agent.remainingDistance;
                    firstTime = false;
                }
            }

            if (agent.isOnOffMeshLink)
            {
                animator.SetBool("jump", true);
                jumping = true;
            }
            else
            {
                if (jumping)
                {
                    animator.SetBool("jump", false);
                    jumping = false;
                }
                animator.SetBool("isWalking", true);
                animator.SetFloat("Speed", 1.0f);

            }
            Debug.Log("fhfhfhffj0");
            agent.SetDestination(targetPosition);
        }
        if(firstTime==false)
        {
            rD  = agent.remainingDistance;
        }
        
    }
}
