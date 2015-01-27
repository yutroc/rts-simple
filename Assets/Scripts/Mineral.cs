using UnityEngine;
using System.Collections;
using RTS;

public class Mineral : WorldObject {
	public float amount = 1000;
	
	public float Extract(float f){
		amount -= f;
		return f;
	}
}
