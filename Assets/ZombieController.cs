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
    public float delayToAttack;

    float distToPlayer;
    Vector3 dirToMove;

    float attackCounter;

    Health zombieHP;
    
    void Start()
    {
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
        // dirToMove.y = 0;

        zombieRB.AddForce(dirToMove * moveSpeed, ForceMode.VelocityChange);

        attackCounter = 0f;

    }

    void AttackPlayer() {

        zombieAnimator.SetBool("isWalking", false);
        zombieAnimator.SetBool("isAttacking", true);
        
        if (distToPlayer <= minDist && attackCounter >= delayToAttack) {
            Player.GetComponent<Health>().TakeDamage(0.05f, this.gameObject);
        }

        attackCounter += 0.05f;

    }

    void DeathAnimation() {

        Destroy(zombieRB);
        Destroy(this.GetComponentInChildren<CapsuleCollider>());
        zombieAnimator.SetBool("isDead", true);

    }
}
