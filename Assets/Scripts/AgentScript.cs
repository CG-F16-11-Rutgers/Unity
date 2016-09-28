using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour
{

    private Vector3 targetPosition;
    public GameObject agent1;
    public GameObject agent2;
    public GameObject agent3;
    public GameObject agent4;
    public GameObject agent5;
    private GameObject[] agents;
    private NavMeshAgent[] agentMesh = new NavMeshAgent[5];
    private int selected;

    public Material selectionMaterial;
    public Material basicMaterial;

    private int numberOfAgents;

    // Use this for initialization
    void Start()
    {
        numberOfAgents = 5;
        agents = new GameObject[numberOfAgents];
        agents[0] = agent1;
        agents[1] = agent2;
        agents[2] = agent3;
        agents[3] = agent4;
        agents[4] = agent5;
        selected = -1;
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
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    return;
                }
                if (hit.collider.tag == "Agent1")
                {
                    selected = 1;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    return;
                }
                if (hit.collider.tag == "Agent2")
                {
                    selected = 2;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    return;
                }
                if (hit.collider.tag == "Agent3")
                {
                    selected = 3;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    return;
                }
                if (hit.collider.tag == "Agent4")
                {
                    selected = 4;
                    for(int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    return;
                }
                targetPosition = hit.point;
                agentMesh[selected].SetDestination(targetPosition);
            }
        }
    }
}
