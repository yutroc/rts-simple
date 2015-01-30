using UnityEngine;
using System.Collections;

public class Soldier : Unit {

	protected override void Awake() {
		base.Awake();
	}
	
	protected override void Start () {
		base.Start();
	}
	
	protected override void Update () {
		base.Update ();			
		if(_target.HasValue){
			if(Vector3.Distance(transform.position, _target.Value) < 1){
				_target = null;
			}
		}		
	}
}
