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
    private bool[] selectArray = new bool[5];

    public Material selectionMaterial;
    public Material basicMaterial;

    private int numberOfAgents;
    private bool multipleAgents;

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
        multipleAgents = false;
        for (int i = 0; i < numberOfAgents; i++)
        {
            agentMesh[i] = agents[i].GetComponent<NavMeshAgent>();
        }
        //GetComponent<Renderer>().material.SetColor("SelectedAgent", Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.tag == "Agent")
                {
                    selected = 0;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                        selectArray[i] = false;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    multipleAgents = false;
                    return;
                }
                if (hit.collider.tag == "Agent1")
                {
                    selected = 1;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                        selectArray[i] = false;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    multipleAgents = false;
                    return;
                }
                if (hit.collider.tag == "Agent2")
                {
                    selected = 2;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                        selectArray[i] = false;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    multipleAgents = false;
                    return;
                }
                if (hit.collider.tag == "Agent3")
                {
                    selected = 3;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                        selectArray[i] = false;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    multipleAgents = false;
                    return;
                }
                if (hit.collider.tag == "Agent4")
                {
                    selected = 4;
                    for(int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                        selectArray[i] = false;
                    }
                    agents[selected].GetComponent<Renderer>().material = selectionMaterial;
                    multipleAgents = false;
                    return;
                }

                if (multipleAgents == true)
                {
                    multipleAgents = false;
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        if (selectArray[i] == true)
                        {
                            targetPosition = hit.point;
                            agentMesh[i].SetDestination(targetPosition);
                        }
                    }
                    return;
                }

                if (selected < 0)
                {
                    return;
                }

                targetPosition = hit.point;
                agentMesh[selected].SetDestination(targetPosition);
                
                
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (selected >= 0)
                {
                    for (int i = 0; i < numberOfAgents; i++)
                    {
                        agents[i].GetComponent<Renderer>().material = basicMaterial;
                    }
                    selected = -1;
                }
                if (hit.collider.tag == "Agent")
                {
                    selectArray[0] = true;
                    agents[0].GetComponent<Renderer>().material = selectionMaterial;
                }
                if (hit.collider.tag == "Agent1")
                {
                    selectArray[1] = true;
                    agents[1].GetComponent<Renderer>().material = selectionMaterial;
                }
                if (hit.collider.tag == "Agent2")
                {
                    selectArray[2] = true;
                    agents[2].GetComponent<Renderer>().material = selectionMaterial;
                }
                if (hit.collider.tag == "Agent3")
                {
                    selectArray[3] = true;
                    agents[3].GetComponent<Renderer>().material = selectionMaterial;
                }
                if (hit.collider.tag == "Agent4")
                {
                    selectArray[4] = true;
                    agents[4].GetComponent<Renderer>().material = selectionMaterial;
                }
                multipleAgents = true;
            }
        }



    }
}
