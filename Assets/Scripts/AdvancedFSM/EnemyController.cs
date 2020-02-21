using UnityEngine;
using System.Collections;

public class EnemyController : AdvancedFSM 
{
    public GameObject Bullet;
    public float attackDistance = 200;

    //Initialize the Finite state machine for the NPC tank
    protected override void Initialize()
    {
        elapsedTime = 0.0f;
        shootRate = 2.0f;

        //Get the target enemy(Player)
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        if (!objPlayer)
            print("Player doesn't exist.. Please add one with Tag named 'Player'");
        
        playerTransform = objPlayer.transform;

        if (!playerTransform)
            print("Player transform doesn't exist.. Please add one with Tag named 'Player'");

        bulletSpawnPoint = transform;

        //Start Doing the Finite State Machine
        ConstructFSM();
    }

    //Update each frame
    protected override void FSMUpdate()
    {
        //Check for health
        elapsedTime += Time.deltaTime;
    }

    protected override void FSMFixedUpdate()
    {
        CurrentState.Reason(playerTransform, transform);
        CurrentState.Act(playerTransform, transform);
    }

    public void SetTransition(Transition t) 
    { 
        PerformTransition(t); 
    }

    private void ConstructFSM()
    {
        PatrolState patrol = new PatrolState(this);
        patrol.AddTransition(Transition.SawPlayer, FSMStateID.Attacking);


        AttackState attack = new AttackState(this);
        attack.AddTransition(Transition.LostPlayer, FSMStateID.Patrolling);
        
        AddFSMState(patrol);
        AddFSMState(attack);
    }

    public void ShootBullet()
    {
        if (elapsedTime >= shootRate)
        {
            Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            elapsedTime = 0.0f;
        }
    }
}
