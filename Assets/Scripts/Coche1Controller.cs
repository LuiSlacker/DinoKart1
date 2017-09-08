using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche1Controller : MonoBehaviour {

	public WheelCollider LDI, LDD, LTI, LTD;
	public float FuerzaDeMotor;
	public float chancleta;
	public float cabrilla;
	public float frenoDeMano;
	public float rotacionMaximaDeLlantas;
	public float FuerzaDeFrenoDeMano;
	public GameObject gameControllerObject;
	public GameObject secondVueltaPanel;
	public GameObject barrera0;
	public GameObject barrera1;
	public GameObject barrera2;
	public GameObject barrera3;

	public int barreraCount = -1;
	public Rigidbody rb;
	public Text firstVuelta;
	public Text secondVuelta;
	public float distanceToNextBarrera;
	public Transform path;


	private float startTime;
	private GameController gameController;

	private List<Transform> nodes = new List<Transform> ();
	private int currentNode = 0;


	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = new Vector3 (0,-0.8f, 0);

		gameController = gameControllerObject.GetComponent<GameController>();
		startTime = Time.time;

		Transform[] pathTransforms = path.GetComponentsInChildren<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms[i] != path.transform) {
				nodes.Add (pathTransforms[i]);
			}
		}
	}
		
	void Update () {
		chancleta = Input.GetAxis("Vertical");
		cabrilla = Input.GetAxis("Horizontal");
		frenoDeMano = Input.GetAxisRaw("Jump");

		float newSteer;
		float motorSpeed;
		if (BtnComenzarController.isAI) {
			Vector3 realtiveVector = transform.InverseTransformPoint (nodes [currentNode].position);
			newSteer = (realtiveVector.x / realtiveVector.magnitude) * rotacionMaximaDeLlantas;
			motorSpeed = 0.8f * FuerzaDeMotor * Time.deltaTime;
		} else {
			newSteer = cabrilla * rotacionMaximaDeLlantas;
			motorSpeed = chancleta * FuerzaDeMotor * Time.deltaTime;
		}

		LDI.steerAngle = newSteer;
		LDD.steerAngle = newSteer;

		LDI.motorTorque = motorSpeed;
		LDD.motorTorque = motorSpeed;


		if (frenoDeMano > 0f)
		{
			LTI.brakeTorque = FuerzaDeFrenoDeMano;
			LTD.brakeTorque = FuerzaDeFrenoDeMano;
		}
		else {
			LTI.brakeTorque = 0f;
			LTD.brakeTorque = 0f;
		}

		updateTime ();
		updateDistanceToNextBarrera ();
		checkDistanceToAINode ();
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

	void checkDistanceToAINode() {
		if (Vector3.Distance(transform.position, nodes[currentNode].transform.position) < 20.0f) {
			if (currentNode == nodes.Count - 1) {
				currentNode = 0;
			} else {
				currentNode++;
			}
		}
	}

	void updateDistanceToNextBarrera() {
		int nextBarrera = barreraCount + 1;
		Vector3 nextBarreraPosition = new Vector3(0, 0, 0);
		switch (nextBarrera) {
		case 0:
			nextBarreraPosition = barrera0.transform.position;
			break;
		case 1:
			nextBarreraPosition = barrera1.transform.position;
			break;
		case 2:
			nextBarreraPosition = barrera2.transform.position;
			break;
		case 3:
			nextBarreraPosition = barrera3.transform.position;
			break;
		}

		distanceToNextBarrera = Vector3.Distance(nextBarreraPosition, transform.position);
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
