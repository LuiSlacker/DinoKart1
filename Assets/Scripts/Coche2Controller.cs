using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche2Controller : MonoBehaviour {

	public WheelCollider LDI, LDD, LTI, LTD;
	public float FuerzaDeMotor;
	public float chancleta;
	public float cabrilla;
	public float frenoDeMano;
	public float rotacionMaximaDeLlantas;
	public float FuerzaDeFrenoDeMano;

	public int barreaCount = 0;


	// Update is called once per frame
	void Update () {
		chancleta = Input.GetAxis("Player2Vertical");
		cabrilla = Input.GetAxis("Player2Horizontal");
		frenoDeMano = Input.GetAxisRaw("Player2Jump");
		LDI.motorTorque = chancleta * FuerzaDeMotor * Time.deltaTime;
		LDD.motorTorque = chancleta * FuerzaDeMotor * Time.deltaTime;
		LDD.steerAngle = cabrilla * rotacionMaximaDeLlantas;
		LDI.steerAngle = cabrilla * rotacionMaximaDeLlantas;

		if (frenoDeMano > 0f)
		{
			LTI.brakeTorque = FuerzaDeFrenoDeMano;
			LTD.brakeTorque = FuerzaDeFrenoDeMano;
		}
		else {
			LTI.brakeTorque = 0f;
			LTD.brakeTorque = 0f;
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag (barreaCount+1+"")) {
			barreaCount++;
			Debug.Log (barreaCount);
		}
	}
}
