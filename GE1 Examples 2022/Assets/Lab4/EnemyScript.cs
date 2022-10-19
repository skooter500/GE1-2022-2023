using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    
    private bool playerinrange = false;
 
 

   
    public float maxspeed;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private bool foundplayer;
    [SerializeField]
    private float searchtimer = 2;
    [SerializeField]
    private Transform[] points;
    private int destPoint = 0;
    private bool patrolling = true;

    private float checkforsurvivor = 2;



    void Start()
    {


        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
       
        GoToNextPoint();
    }


    void Update()
    {

        checkforsurvivor -= 1 * Time.deltaTime;
       
       
            if (agent.isOnNavMesh)
            {
                if (checkforsurvivor < 0)
                {
                    RaycastHit hit;
                    Debug.DrawRay(agent.transform.position + new Vector3(0, 3, 0), Player.transform.position - agent.transform.position + new Vector3(0, -3, 0), Color.red, 0.1f);


                    checkforsurvivor = 0.5f;
                    if (Physics.Raycast(agent.transform.position + new Vector3(0, 3, 0), Player.transform.position - agent.transform.position + new Vector3(0, -3, 0), out hit))
                    {



                        if (hit.transform.gameObject.CompareTag("Player"))
                        {

                         
                            
                                agent.speed = 6f;
                          
                            searchtimer = 5;
                            patrolling = false;
                        }



                    }
                }


                if (searchtimer > 0)
                {

                    agent.SetDestination(Player.transform.position);
                    searchtimer -= 1 * Time.deltaTime;
                }
                else
                {

                    if (searchtimer <= 0)
                    {

                    
                        if (patrolling == false)
                        {
                          
                          
                       
                                agent.speed = 2.5f;
                            
                            patrolling = true;
                         
                            GoToNextPoint();
                        }
                        if (!agent.pathPending && agent.remainingDistance < 2f)
                        {
                            
                            GoToNextPoint();
                        }
                    }


                }

            }

        }
       
   

    void GoToNextPoint()
    {
        patrolling = true;
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        destPoint = (Random.Range(0, points.Length + 1)) % points.Length;
    }







}
