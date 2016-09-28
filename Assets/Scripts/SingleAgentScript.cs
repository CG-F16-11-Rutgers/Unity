using UnityEngine;
using System.Collections;

public class SingleAgentScript : MonoBehaviour {

    private NavMeshAgent agent;
    public Material selectionMaterial;
    public Material basicMaterial;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();    

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void select()
    {
        agent.GetComponent<Renderer>().material = selectionMaterial;
    }

    public void deselect()
    {
        agent.GetComponent<Renderer>().material = basicMaterial;
    }

    public void moveToTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }


}
