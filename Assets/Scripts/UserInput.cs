using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserInput : MonoBehaviour {

	public Vector3 startPoint = - Vector3.one;
	public float startTime = 0;
	public Rect selectionRect = new Rect(0,0,0,0);
	public List<WorldObject> selected;
	public Player player;
	
	void Start () {
		player = transform.root.GetComponentInChildren< Player >();
	}
	
	// Update is called once per frame
	void Update () {
		CheckTouch();
	}
	
	private void CheckTouch(){
		if(Input.GetMouseButtonDown(0)){
			startPoint = Input.mousePosition;
		}else if(Input.GetMouseButtonUp(0)){
			if(Vector3.Distance(Input.mousePosition, startPoint) > 10){
				if(selectionRect.width < 0){
					selectionRect.x += selectionRect.width;
					selectionRect.width = -selectionRect.width;
				}
				if(selectionRect.height < 0){
					selectionRect.y += selectionRect.width;
					selectionRect.height = -selectionRect.height;
				}
				startPoint = -Vector3.one;
				player.SelectedObjects = ObjectManager.GetUnitsArea(selectionRect, player);
			}else{				
				startPoint = -Vector3.one;				
				foreach(var obj in player.SelectedObjects){
					print (obj);
					if(obj.GetType() == typeof(Unit)){	
						Unit unit = obj.GetComponent<Unit>();	
						var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						var plane = new Plane(new Vector3(0,1,0), Vector3.up);
						float distance;
						if (plane.Raycast(ray, out distance)){
							var hitPoint = ray.GetPoint(distance);
							unit._target = hitPoint;
						}
					}
				}
			}
		}
		if(Input.GetMouseButton(0)){
			selectionRect = new Rect(startPoint.x, Screen.height - startPoint.y, Input.mousePosition.x - startPoint.x, -Input.mousePosition.y + startPoint.y);
		}
		
	}
	
	void OnGUI(){
		if(startPoint != -Vector3.one){
			GUI.color = new Color(1,1,1,0.5f);
			GUI.DrawTexture(selectionRect,new Texture2D(10,10));
		}
	}
}
