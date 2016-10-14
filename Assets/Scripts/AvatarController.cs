using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class AvatarController : MonoBehaviour {

    //public int movingSpeed = 100;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        float d = Input.GetAxis("Horizontal");
        
        

        float s = Input.GetAxis("Vertical");
        animator.SetBool("isWalking", false);
        if (s != 0)
        {
            animator.SetBool("isWalking", true);
            //transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
        animator.SetFloat("Direction", d);
        animator.SetFloat("Speed", s);
        
        animator.SetBool("turnRight", false);
        animator.SetBool("turnLeft", false);
        animator.SetBool("jump", false);
        animator.SetBool("isWalkingBack", false);
        animator.SetBool("shiftPressed", false);
        /*if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            //transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(Vector3.back * movingSpeed * Time.deltaTime);
            animator.SetBool("isWalkingBack", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("turnRight", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("turnLeft", true);
        }*/
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("shiftPressed", true);
        }


    }
}
