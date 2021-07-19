using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.FPS.Game;

public class ZombieController : MonoBehaviour
{

    public Transform Player;
    public Animator zombieAnimator;
    Rigidbody zombieRB;

    public float moveSpeed;
    public float maxDist;
    public float minDist;

    float distToPlayer;
    Vector3 dirToMove;

    float attackCounter;

    Health zombieHP;
    
    void Start()
    {
        moveSpeed = 2f;
        maxDist = 10f;
        minDist = 1.5f;
        distToPlayer = float.PositiveInfinity;
        zombieRB = this.GetComponent<Rigidbody>();
        dirToMove = Vector3.zero;

        zombieHP = this.GetComponent<Health>();

        zombieAnimator.SetBool("isDead", false);

        attackCounter = 0f;
    }

    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, Player.position);

        if (zombieHP.checkDeath()) DeathAnimation();

        else {

            if (distToPlayer > maxDist) { 
                zombieAnimator.SetBool("isWalking", false);
                zombieAnimator.SetBool("isAttacking", false);
            }

            else if (distToPlayer >= minDist) MoveToPlayer();

            else AttackPlayer();

        }

    }

    void MoveToPlayer() {

        transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));

        zombieAnimator.SetBool("isWalking", true);
        zombieAnimator.SetBool("isAttacking", false);
 
        dirToMove = (Player.position - transform.position).normalized;
        dirToMove.y = 0;

        zombieRB.AddForce(dirToMove * moveSpeed, ForceMode.VelocityChange);

        attackCounter = 0f;

    }

    void AttackPlayer() {

        zombieAnimator.SetBool("isWalking", false);
        zombieAnimator.SetBool("isAttacking", true);
        
        if (distToPlayer <= minDist && attackCounter >= 3f) {
            Player.GetComponent<Health>().TakeDamage(0.05f, this.gameObject);
        }

        attackCounter += 0.5f;

    }

    void DeathAnimation() {

        Destroy(zombieRB);
        Destroy(this.GetComponent<NavMeshAgent>());
        zombieAnimator.SetBool("isDead", true);

    }
}
