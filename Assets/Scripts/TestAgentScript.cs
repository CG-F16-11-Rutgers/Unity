using UnityEngine;
using System.Collections;

public class TestAgentScript : MonoBehaviour
{

    public Material basic;

    public Material highlight;

    Vector3 target;
    NavMeshAgent agent;
    bool selected;
    bool moving;
   
  
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        selected = false;
        moving = false;
       
      
    }

    void FixedUpdate()
    {
        if (selected == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.CompareTag("Agent")==false)
                    {
                        target = hit.point;
                        moving = true;
                       
                        agent.Resume();
                        agent.Resume();
                        Debug.Log("Resume");
                    }
                }
            }
        }

    }
    void OnMouseDown()
    {
        if (selected == true)
        {
            selected = false;

            GetComponent<Renderer>().material = basic;
        }
        else
        {
            selected = true;
            GetComponent<Renderer>().material = highlight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moving == true)
        { 
            agent.SetDestination(target);

          
        }
        else
        {
            Rigidbody b = GetComponent<Rigidbody>();
            b.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Agent"))
        {
            float radiusOfAgent = GetComponent<NavMeshAgent>().radius;

            // Debug.Log("remain is " + agent.remainingDistance);
            if (agent.remainingDistance <= (radiusOfAgent *2))
            {

                agent.Stop();
                Debug.Log("Stopped");
                Rigidbody b = GetComponent<Rigidbody>();
                b.velocity = Vector3.zero;
                moving = false;

               
            }
        }
    }
    
}
