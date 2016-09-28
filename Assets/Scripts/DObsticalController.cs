using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DObsticalController : MonoBehaviour {

    //public Transform target;
    //NavMeshAgent agent;
    public float speed;
    private bool clicked = false;
    private Rigidbody rb;
    
    // Use this for initialization
    void Start()
    {
        clicked = false;
        //agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //agent.SetDestination(target.position);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit(); ;
            if (Physics.Raycast(ray, out hit))
            {
                
                    if (hit.transform.position.x == rb.transform.position.x)
                    {
                        clicked = !clicked;
                    }
                
            }
        }
    }
    void FixedUpdate()
    {
        
        if(clicked == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
        
        
    }

}
