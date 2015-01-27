using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
	
	public List<Unit> units;
	public List<Building> buildings;
	public List<Mineral> minerals;
	public List<Headquarter> headquarters;
	
	public static ObjectManager go;
	
	private static bool created = false;
	
	void Awake() {
		if(!created) {
			go = this;
			DontDestroyOnLoad(transform.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}
	}
	
	public Mineral GetMineralEarly(Vector3 position){
		float distance = float.MaxValue;
		Mineral target = null;
		
		foreach(var mineral in minerals){
			if(mineral.amount > 0 && Vector3.Distance(mineral.transform.position, position) < distance){
				target = mineral;
				distance = Vector3.Distance(mineral.transform.position, position);
			}
		}
		
		return target;
	}
	
	public Headquarter GetHeadquarterEarly(Vector3 position){
		float distance = float.MaxValue;
		Headquarter target = null;
		
		foreach(var headquarter in headquarters){
			if(Vector3.Distance(headquarter.transform.position, position) < distance){
				target = headquarter;
				distance = Vector3.Distance(headquarter.transform.position, position);
			}
		}
		
		return target;
	}
	
}
