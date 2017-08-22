using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : MonoBehaviour {

	public WheelCollider wheelCollider;
	
	// Update is called once per frame
	void Update () {
		Vector3 localPosition = this.transform.localPosition;
		this.transform.localPosition = localPosition;
		this.transform.localRotation = Quaternion.Euler(0, wheelCollider.steerAngle, 90);
	}
}
