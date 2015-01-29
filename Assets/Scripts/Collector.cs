using UnityEngine;
using System.Collections;
using RTS;

public class Collector : Unit {

	public bool collecting = false;
	public float collected = 0;
	public float capacity = 100;
	public float speedCollector = 1f;
	public Mineral mineral;

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
				if(Vector3.Distance(transform.position, target.transform.position) < target.contactRatio){
					Collect ();
				}
			}else{
				if(Vector3.Distance(transform.position, target.transform.position) < target.contactRatio){
					Decollect ();
				}
			}
		}else{
			if(collected < capacity){
				target = ObjectManager.go.GetMineralEarly(transform.position);
				if(target == null){
					target = ObjectManager.go.GetHeadquarterEarly(transform.position, this.player);
				}
			}else{
				mineral.currentCollectors--;
				target = ObjectManager.go.GetHeadquarterEarly(transform.position, this.player);
			}
		}
	}
	
	private void Collect(){
		mineral = target.GetComponent<Mineral> ();
		if (mineral.amount > 0) {
			var amounttocollect = speedCollector * Time.deltaTime;
			if (amounttocollect + collected <= capacity) {
				collected += mineral.Extract (amounttocollect);
			} else {			
				collected += mineral.Extract (capacity - collected);
			}
			//print (collected + " - " + capacity + " - " + float.Equals(collected, capacity) + " - " + (collected >= capacity));
			if (float.Equals(collected, capacity) || collected >= capacity){
				target = null;
			}
		} else {
			target = null;
		}
	}
	
	private void Decollect(){
		player.mineals += collected;
		collected = 0;
		target = null;
	}
}
