using UnityEngine;
using System.Collections;

public class AutoAgent : MonoBehaviour {

    private float speed= 0.1F;

    public GameObject goal;

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


        targetPosition = goal.transform.position;

        jumping = false;
        moving = false;
        //walking = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (agent.remainingDistance < 1.0)
        {
            Debug.Log("YOYOYO");

            agent.velocity = Vector3.zero;
            agent.ResetPath();
            animator.SetBool("isWalking", false);
            animator.SetBool("jump", false);
            moving = false;
        }
        else
        {
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

            }
            Debug.Log("fhfhfhffj0");
            agent.SetDestination(targetPosition);
        }
    }
}
