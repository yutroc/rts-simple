using UnityEngine;
using System.Collections;
using RTS;

public class Unit : WorldObject {
	
	public float speedRotation = 1f;
	public float speedTranslation = 10f;


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
		Vector3 targetDir = target.transform.position - transform.position;
		float stepr = speedRotation * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepr, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
		CharacterController controller = GetComponent<CharacterController>();
		controller.Move(newDir * Time.deltaTime * speedTranslation);
		//float stept = speedTranslation * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, stept);
		
		
	}
	
	protected override void Attack ()
	{
	}
	
	protected override void Aim ()
	{
	}
}
