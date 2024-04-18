using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AgentBasic : MonoBehaviour
{
    public GameObject currentAgent, shatterredAgent;
    float distance;
    GameObject player;
    Animator animator;
    NavMeshAgent navMeshAgent;

    GameObject cam;

    Vector3 agentToPlayerDirection;
    float dotProduct;

    Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        cam = GameObject.FindGameObjectWithTag("MainCamera");

    }

    void FixedUpdate()
    {

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.isStopped =true;

            direction = player.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);

            agentToPlayerDirection = cam.transform.position - transform.position;
            dotProduct = Vector3.Dot(cam.transform.forward, agentToPlayerDirection);

            if (dotProduct < -.6)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            }

            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", false);
            }

        }
        else
        {
            animator.SetBool("isWalking", true);
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = player.transform.position;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) //make sure to add a tag to the bullet
        {
            //Destroy the current Agent mesh
            //Set a shattered Agent Active

            this.transform.GetChild(0).gameObject.SetActive(false);
            shatterredAgent.SetActive(true);
        }
    }
}