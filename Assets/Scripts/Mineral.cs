using UnityEngine;
using System.Collections;
using RTS;

public class Mineral : WorldObject {
	public float amount = 1000;
	
	public float Extract(float f){
		var _amount = amount - f;
		if (_amount >= 0) {
			amount = _amount;
			return f;
		} else {
			amount = 0;
			return f + _amount;
		}
	}
}
