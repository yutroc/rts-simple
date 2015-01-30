using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;

public class Player : MonoBehaviour {

	public string username;
	public bool human;
	public HUD hud;
	public List<WorldObject> SelectedObjects;
	public int startMoney, startMoneyLimit, startPower, startPowerLimit;
	public float mineals, mineralsLimit;
	public Material notAllowedMaterial, allowedMaterial;
	public Color teamColor;
	
	private Dictionary<ResourceType,int> resources, resourceLimits;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
