using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DObsticalController : MonoBehaviour {

    public Transform target;
    //NavMeshAgent agent;
    private bool clicked = false;
    private Rigidbody rb;
    public Material my, mn;
    public float speed;

    
    
    // Use this for initialization
    void Start()
    {
        clicked = false;
        //agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    public void move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0.0f, v);
        rb.AddForce(movement * speed);
    }
    public void select()
    {
        clicked = true;
        rb.GetComponent<Renderer>().material = my;
    }
    public void deSelect()
    {
        clicked = false;
        rb.GetComponent<Renderer>().material = mn;
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

            move(moveHorizontal, moveVertical);
                

           
        }
        
        
    }

}
