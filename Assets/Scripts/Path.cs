using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
	public Color lineColor;
	private List<Transform> nodes = new List<Transform> ();

	// Ths function simply visualizes the nodes of the path for AI-Steering
	void OnDrawGizmosSelected() {
		Gizmos.color = lineColor;
		Transform[] pathTransforms = GetComponentsInChildren<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms[i] != transform) {
				nodes.Add (pathTransforms[i]);
			}
		}

		for (int i = 0; i < nodes.Count; i++) {
			Vector3 currentNode = nodes [i].position;
			Vector3 previousNode = (i > 0)? nodes [i - 1].position : nodes [nodes.Count-1].position;

			Gizmos.DrawLine (previousNode, currentNode);
			Gizmos.DrawWireSphere (currentNode, 0.6f);
		}
	}
}
