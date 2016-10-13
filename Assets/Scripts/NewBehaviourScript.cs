using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("velx", 0.0f);
        animator.SetBool("locomotion", false);
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("locomotion", true);
            animator.SetFloat("velx", 1.0f);
            //transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        }
    }
}
