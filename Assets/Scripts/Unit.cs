using UnityEngine;
using System.Collections;
using RTS;

public class Unit : WorldObject {
	
	public float speedRotation = 1f;
	public float speedTranslation = 10f;
	public float variationTranslation = 50f;


	protected override void Awake() {
		base.Awake();
	}
	
	protected override void Start () {
		base.Start();
	}
	
	protected override void Update () {
		base.Update();
		if(ShouldMakeDecision()) DecideWhatToDo();
		if(movingIntoPosition)Move();
		if(attacking)Attack();
		if(aiming)Aim();
		
	}
	
	protected override void DecideWhatToDo() {
		switch (attackMode) {
		case AttackMode.None:
			if(target != null)	movingIntoPosition = true;
			break;
		case AttackMode.Ofensive:
			break;
		case AttackMode.Defensive:
			break;
		}
	}
	
	protected override void Move ()
	{
		if(target == null) return;
		NavMeshAgent controller = GetComponent<NavMeshAgent>();
		controller.SetDestination (target.transform.position);
		/*Vector3 targetDir = target.transform.position - transform.position;
		float stepr = speedRotation * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepr, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
		CharacterController controller = GetComponent<CharacterController>();
		controller.Move(newDir * Time.deltaTime * speedTranslation);
		*/
		
	}
	
	protected override void Attack ()
	{
	}
	
	protected override void Aim ()
	{
	}
}
