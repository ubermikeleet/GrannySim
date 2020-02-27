using UnityEngine;

public class Destroyer : MonoBehaviour {

	private Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (rb.position.y <= -10f) {
			DestroyImmediate(this.gameObject);
		}
	}
}
