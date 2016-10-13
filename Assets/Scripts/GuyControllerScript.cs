using UnityEngine;
using System.Collections;

public class GuyControllerScript : MonoBehaviour {

    private Animator animator;
	
	// Use this for initialization
	void Start () {
	
        animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        animator.SetBool("isWalking", false);
        
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            //transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
	}
}
