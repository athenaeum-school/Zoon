﻿using UnityEngine;
using System.Collections;

namespace zoon {
public class PatrolMode : EnemyFSMState
{
	public PatrolMode(Transform[] wp) 
	{ 
		waypoints = wp;
		stateID = FSMStateID.Patrolling;
		
		curRotSpeed = 1.0f;
		curSpeed = 100.0f;
	}
	
	public override void Reason(Transform player, Transform npc)
	{
		
		if (Vector3.Distance(npc.position, player.position) <= 300.0f)
		{
			Debug.Log("Switch to Chase State");
			npc.GetComponent<EnemyCatController>().SetTransition(Transition.SawPlayer);
		}
	}
	
	public override void Act(Transform player, Transform npc)
	{
		//Find another random patrol point if the current point is reached
		//ターゲット地点に到着した場合に、パトロール地点を再度策定
		if (Vector3.Distance(npc.position, destPos) <= 100.0f)
		{
			Debug.Log("Reached to the destination point\ncalculating the next point");
			FindNextPoint();
		}
		
		//ターゲットに回転
		Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
		npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);
		
		//前進
		npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);
	}
}
}
