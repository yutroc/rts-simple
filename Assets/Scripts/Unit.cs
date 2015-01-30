using UnityEngine;
using System.Collections;
using RTS;

public class Unit : WorldObject {
	
	public float speedRotation = 1f;
	public float speedTranslation = 10f;
	public float variationTranslation = 50f;
	public NavMeshAgent motor;
	public Vector3? _target = null;


	protected override void Awake() {
		base.Awake();
	}
	
	protected override void Start () {
		base.Start();
		motor = GetComponent<NavMeshAgent>();
	}
	
	protected override void Update () {
		base.Update();
		if(ShouldMakeDecision()) DecideWhatToDo();
		if (movingIntoPosition) Move ();
		if(attacking)Attack();
		if(aiming)Aim();
		
	}
	
	protected override void DecideWhatToDo() {
		switch (attackMode) {
		case AttackMode.None:
			if(target != null)	movingIntoPosition = true;
			break;
		case AttackMode.Ofensive:
			if(target != null || _target.HasValue)	movingIntoPosition = true;
			break;
		case AttackMode.Defensive:
			break;
		}
	}
	
	protected override void Move ()
	{
		if(target == null && !_target.HasValue){
			return;
		}else{
			motor = GetComponent<NavMeshAgent>();
			if(target != null){
				motor.SetDestination (target.transform.position);
			}else if(_target.HasValue){
				motor.SetDestination (_target.Value);				
			}
		}
		
	}
	
	protected override void Attack ()
	{
	}
	
	protected override void Aim ()
	{
	}
}
