using UnityEngine;

public class CollisionColor : MonoBehaviour {

	public Color defaultColor;
	public Color collisionColor;

	void Start () {
		GetComponent<Renderer>().material.color = defaultColor;
	}

	void OnTriggerEnter (Collider c) {
		if (c.GetComponent<Grab>() != null){
			GetComponent<Renderer>().material.color = collisionColor;
		}
	}

	void OnTriggerExit (Collider c) {
		if (c.GetComponent<Grab>() != null){
			GetComponent<Renderer>().material.color = defaultColor;
		}
	}
}
