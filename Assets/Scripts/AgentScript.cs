using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour
{

    private Vector3 targetPosition;
    public GameObject agent1;
    public GameObject agent2;
    private GameObject[] agents;
    private NavMeshAgent[] agentMesh = new NavMeshAgent[2];
    private int selected;

    public Material selectionMaterial;
    public Material basicMaterial;

    // Use this for initialization
    void Start()
    {
        agents = new GameObject[2];
        agents[0] = agent1;
        agents[1] = agent2;
        selected = -1;
        int numberOfAgents = 2;
        for (int i = 0; i < numberOfAgents; i++)
        {
            agentMesh[i] = agents[i].GetComponent<NavMeshAgent>();
        }
        //GetComponent<Renderer>().material.SetColor("SelectedAgent", Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Agent")
                {
                    selected = 0;
                    agents[0].GetComponent<Renderer>().material = selectionMaterial;
                    agents[1].GetComponent<Renderer>().material = basicMaterial;
                    return;
                }
                if (hit.collider.tag == "Agent1")
                {
                    selected = 1;
                    agents[1].GetComponent<Renderer>().material = selectionMaterial;
                    agents[0].GetComponent<Renderer>().material = basicMaterial;
                    return;
                }
                targetPosition = hit.point;
                agentMesh[selected].SetDestination(targetPosition);
            }
        }
    }
}
