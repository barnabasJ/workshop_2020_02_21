using UnityEngine;
using System.Collections;

public class AttackState : FSMState
{

    private EnemyController enemyController;
    public AttackState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
        stateID = FSMStateID.Attacking;
    }

    public override void Reason(Transform player, Transform npc)
    {
        //Check the distance with the player tank
        float dist = Vector3.Distance(npc.position, player.position);
        //Transition to patrol is the tank become too far
        if (dist >= enemyController.attackDistance)
        {
            Debug.Log("Switch to Patrol State");
            enemyController.SetTransition(Transition.LostPlayer);
        }  
    }

    public override void Act(Transform player, Transform npc)
    {
        //Set the target position as the player position
        destPos = player.position;

        //Always Turn the turret towards the player
        Transform turret = enemyController.transform;
        Quaternion turretRotation = Quaternion.LookRotation(destPos - turret.position);
        turret.rotation = Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * 10.0f);

        //Shoot bullet towards the player
        enemyController.ShootBullet();
    }
}
