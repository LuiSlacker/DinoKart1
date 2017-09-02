using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche2Controller : MonoBehaviour {

	public WheelCollider LDI, LDD, LTI, LTD;
	public float FuerzaDeMotor;
	public float chancleta;
	public float cabrilla;
	public float frenoDeMano;
	public float rotacionMaximaDeLlantas;
	public float FuerzaDeFrenoDeMano;
	public GameObject gameControllerObject;
	public GameObject secondVueltaPanel;

	public int barreraCount = -1;
	public Rigidbody rb;
	public Text firstVuelta;
	public Text secondVuelta;

	private float startTime;
	private GameController gameController;

	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = new Vector3 (0,-0.8f, 0);

		gameController = gameControllerObject.GetComponent<GameController>();
		startTime = Time.time;
	}


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

		updateTime();
	}

	void updateTime() {
		float guiTime = Time.time - startTime;

		float minutes = Mathf.Floor(guiTime / 60);
		float seconds = guiTime % 60;
		float fraction = (guiTime * 1000) % 1000;

		if (!gameController.isFinished) {
			if (barreraCount < 3) {
				firstVuelta.text = string.Format ("1st vuelta: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
			} else {
				secondVuelta.text = string.Format ("2nd vuelta: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		int expectedBarrera = (barreraCount + 1) % 4;
		if (other.gameObject.CompareTag (expectedBarrera + "")) {
			barreraCount++;
			Debug.Log (barreraCount);
		}
		if (barreraCount == 3) {
			secondVueltaPanel.SetActive (true);
			startTime = Time.time; // reset Timer for second vuelta
		}
	}
}
