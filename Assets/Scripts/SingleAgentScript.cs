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

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.gameObject.CompareTag("Player")) {
            if(agent.remainingDistance < 3) {
                agent.Stop();
            }
        }
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
        agent.Resume();
        agent.SetDestination(targetPosition);
    }


}
