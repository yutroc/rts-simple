using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;

public class WorldObject : MonoBehaviour {

	protected Player player;
	protected string[] actions = {};
	protected bool currentlySelected = false;
	protected Bounds selectionBounds;

	public TypeObject tipo;
	public string objectName = "WorldObject";
	public Texture2D buildImage;
	public int cost = 100, sellValue = 10, hitPoints = 100, maxHitPoints = 100;
	public float weaponRange = 10.0f, weaponRechargeTime = 1.0f, weaponAimSpeed = 1.0f, detectionRange = 20.0f;
	public float contactRatio = 1;

	protected float healthPercentage = 1.0f;
	protected WorldObject target = null;
	protected bool attacking = false, movingIntoPosition = false, aiming = false;
	protected bool loadedSavedValues = false;
	protected List<WorldObject> nearbyObjects;
	public AttackMode attackMode = AttackMode.None;
	
	private float timeSinceLastDecision = 0.0f, timeBetweenDecisions = 0.1f;

	protected virtual void Awake() {
	}
	
	protected virtual void Start () {
		player = transform.root.GetComponentInChildren< Player >();
	}
	
	protected virtual void Update () {
		if(ShouldMakeDecision()) DecideWhatToDo();
		
	}

	protected virtual bool ShouldMakeDecision() {
		if(!attacking && !movingIntoPosition && !aiming) {
			//we are not doing anything at the moment
			if(timeSinceLastDecision > timeBetweenDecisions) {
				timeSinceLastDecision = 0.0f;
				return true;
			}
			timeSinceLastDecision += Time.deltaTime;
		}
		return false;
	}

	protected virtual void DecideWhatToDo() {
		
	}

	protected virtual void Move ()
	{
	}
	
	protected virtual void Attack ()
	{
	}
	
	protected virtual void Aim ()
	{
	}

	public void SetSelection(bool selected) {
		currentlySelected = selected;
	}

	public string[] GetActions() {
		return actions;
	}
	
	public virtual void PerformAction(string actionToPerform) {
		//it is up to children with specific actions to determine what to do with each of those actions
	}
}
