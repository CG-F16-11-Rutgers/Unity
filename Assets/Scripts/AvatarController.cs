using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

    public int movingSpeed = 100;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("isWalking", false);
        animator.SetBool("turnRight", false);
        animator.SetBool("jump", false);
        animator.SetBool("isWalkingBack", false);
	    if (Input.GetKey(KeyCode.I))
        {
            animator.SetBool("isWalking", true);
            //transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.L))
        {
            animator.SetBool("turnRight", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        if (Input.GetKey(KeyCode.K))
        {
            //transform.Translate(Vector3.back * movingSpeed * Time.deltaTime);
            animator.SetBool("isWalkingBack", true);
        }
	}
}
