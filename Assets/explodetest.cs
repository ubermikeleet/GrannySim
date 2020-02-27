using UnityEngine;

public class explodetest : MonoBehaviour {

	public bool boom = false;

	public float force;
	public float up = .5f;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		if (boom) {
			rb.AddExplosionForce(force, rb.position, 2f, up, ForceMode.Impulse);
			boom = false;
		}
	}

	void OnCollisionEnter(Collision c) {
		if (c.gameObject.CompareTag("Respawn")) {
			rb.AddExplosionForce(force, (c.transform.position + rb.position) / 2f, 5f, up, ForceMode.Impulse);
			c.rigidbody.velocity = Vector3.zero;
		}
	}
}
