using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Controls the Enemy AI */

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;  // Detection range for player
    public float distance;
    public bool shouldMove;
    public bool shouldFight;

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent
    Animator animator;   
    public Vector2 velocity;
    

    // Use this for initialization
    void Start()
    {
        shouldFight = false;
        shouldMove = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // Distance to the target
        distance = Vector3.Distance(target.position, transform.position);

        // If inside the lookRadius
        if (distance <= lookRadius)
        {
            // Move towards the target
            agent.SetDestination(target.position);          
            velocity.y = 0.9f;  
            shouldMove = true; //velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;
            shouldFight = false;
            // Update animation parameters

            // If within attacking distance
            if (distance <= agent.stoppingDistance)
            {
                shouldFight = true;
                shouldMove = false;
                FaceTarget();   // Make sure to face towards the target
            }
            // Update animation parameters
            animator.SetBool("move", shouldMove);
            animator.SetBool("fight", shouldFight);
            animator.SetFloat("vx", velocity.x);
            animator.SetFloat("vy", velocity.y);


        }
        if(distance>lookRadius && shouldMove==true)
        {
            if (agent.hasPath)
                agent.ResetPath();
            shouldMove = false;
            animator.SetBool("move", shouldMove);
        }
    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}