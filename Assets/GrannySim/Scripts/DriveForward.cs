using UnityEngine;

public class DriveForward : MonoBehaviour {
	public float speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		//float x = rb.rotation.eulerAngles.x;
		//float z = rb.rotation.eulerAngles.z;
		if (rb.position.y < -10f) {
			DestroyImmediate(gameObject);
			return;
		}
		//if ((rb.position.y < 2f) && (z > -45f && z < 45f)) { //&& (x > -10f && x < 5f )) {
			rb.AddForce(rb.transform.forward * speed, ForceMode.VelocityChange);
		//}
	}
}
