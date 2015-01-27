using UnityEngine;
using System.Collections;
using RTS;

public class Collector : Unit {

	public float collected = 0;
	public float capacity = 100;
	public float speedCollector = 1f;

	protected override void Awake() {
		base.Awake();
	}
	
	protected override void Start () {
		base.Start();
	}
	
	protected override void Update () {
		base.Update();
		if(target != null){
			if(target.tipo == TypeObject.Minerals){
				if(Vector3.Distance(transform.position, target.transform.position) < 2.53f){
					Collect ();
				}
			}else{
				if(Vector3.Distance(transform.position, target.transform.position) < 2.53f){
					Decollect ();
				}
			}
		}else{
			if(collected <= capacity){
				target = ObjectManager.go.GetMineralEarly(transform.position);
			}else{
				target = ObjectManager.go.GetHeadquarterEarly(transform.position);
			}
		}
	}
	
	private void Collect(){
		collected+= target.GetComponent<Mineral>().Extract(speedCollector*Time.deltaTime);
		if(collected >= capacity)
			target = null;
	}
	
	private void Decollect(){
		player.mineals += collected;
		collected = 0;
		target = null;
	}
}
