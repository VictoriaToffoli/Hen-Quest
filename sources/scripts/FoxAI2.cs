using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxAI2 : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask playerLayer, groundLayer;

    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float range;

    //bool isChassing;
    private float timer;
    public int maxTimeTryingToGoSomewhere = 10;

    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    public GameObject image;
    public int foxIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Chicken");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        //playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

         timer += Time.deltaTime;

        if (!playerInSightRange) Patrol();
        if (playerInSightRange) Chase();

    }

    void Patrol()
    {
        if (!walkPointSet) SearchForDest();

        if(walkPointSet) agent.SetDestination(destPoint);

        if(walkPointSet && timer > 10)
        {
            SearchForDest();
        }

        if(Vector3.Distance(transform.position, destPoint) < maxTimeTryingToGoSomewhere) walkPointSet = false;

        StaticData.foxIsClose[foxIndex] = false; 
        //isChassing = false;
        if(!StaticData.shouldAlertBeVisible())
        {
            image.SetActive(false);
        }
    }

    void Chase()
    {
        destPoint = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        agent.SetDestination(destPoint);

        StaticData.foxIsClose[foxIndex] = true; 
        //isChassing = true;
         image.SetActive(true);

    }

    void SearchForDest()
    {
        timer = 0;

        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
