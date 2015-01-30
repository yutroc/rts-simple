using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
	
	public static List<Unit> units;
	public static List<Building> buildings;
	public static List<Mineral> minerals;
	public static List<Headquarter> headquarters;
	
	
	private static bool created = false;
	
	void Awake() {
		if(!created) {
			DontDestroyOnLoad(transform.gameObject);
			created = true;
		} else {
			Destroy(this.gameObject);
		}
	}
	
	void Start(){
		units = new List<Unit>(GameObject.FindObjectsOfType<Unit>());
		buildings = new List<Building>(GameObject.FindObjectsOfType<Building>());
		minerals = new List<Mineral>(GameObject.FindObjectsOfType<Mineral>());
		headquarters = new List<Headquarter>(GameObject.FindObjectsOfType<Headquarter>());
	}

	public static List<WorldObject> GetUnitsArea (Rect selectionRect, Player player)
	{
		var list = new List<WorldObject>();
		foreach(var unit in units){
			var camPos = Camera.main.WorldToScreenPoint(unit.transform.position);
			camPos.y = Screen.height - camPos.y;
			if(unit.Player == player && selectionRect.Contains(camPos)){
				list.Add(unit);
			}
		}		
		print ("selection " + list.Count);
		return list;
	}
	
	public static Mineral GetMineralEarly(Vector3 position){
		float distance = float.MaxValue;
		Mineral target = null;
		
		foreach(var mineral in minerals){
			if(mineral.amount > 0 && 
			   mineral.currentCollectors < mineral.capacityCollectors && 
			   Vector3.Distance(mineral.transform.position, position) < distance){
				target = mineral;
				distance = Vector3.Distance(mineral.transform.position, position);
			}
		}
		if(target == null){
			foreach(var mineral in minerals){
				if(mineral.amount > 0 &&  
				   Vector3.Distance(mineral.transform.position, position) < distance){
					target = mineral;
					distance = Vector3.Distance(mineral.transform.position, position);
				}
			}	
		}
		target.currentCollectors++;
		return target;
	}
	
	public static Headquarter GetHeadquarterEarly(Vector3 position, Player player){
		float distance = float.MaxValue;
		Headquarter target = null;
		
		foreach(var headquarter in headquarters){
			if(player == headquarter.Player && Vector3.Distance(headquarter.transform.position, position) < distance){
				target = headquarter;
				distance = Vector3.Distance(headquarter.transform.position, position);
			}
		}
		
		return target;
	}
	
}
