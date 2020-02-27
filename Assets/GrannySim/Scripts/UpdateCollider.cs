using UnityEngine;

public class UpdateCollider : MonoBehaviour {

	public Transform head;

	private CapsuleCollider body;

	void Start () {
		body = GetComponent<CapsuleCollider>();
	}

	void FixedUpdate () {
		body.height = head.localPosition.y;
		body.center = new Vector3(head.localPosition.x, body.height / 2f, head.localPosition.z);
	}
}
