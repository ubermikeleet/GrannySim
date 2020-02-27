using UnityEngine;

public class Walker : MonoBehaviour {

	public SteamVR_TrackedObject leftController;
	public SteamVR_TrackedObject rightController;
	public Rigidbody body;

	private Rigidbody walkerRB;
	private Transform left;
	private Transform right;

	private bool triggerHeld;
	private Vector3 prevPos;

	void Start () {
	 	walkerRB = GetComponent<Rigidbody>();
		left = leftController.transform;
		right = rightController.transform;
		prevPos =  (left.localPosition + right.localPosition) / 2f;
	}

	void Update () {
		var device = SteamVR_Controller.Input((int)rightController.index);
		triggerHeld = device.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
	}

	void FixedUpdate () {
		if (triggerHeld) {
			MoveBody();
		}
		else {
			MoveWalker();
		}
		prevPos =  (left.localPosition + right.localPosition) / 2f;
	}

	void MoveBody () {
		Vector3 newPos = prevPos - (left.localPosition + right.localPosition) / 2f;
		body.useGravity = false;
		body.MovePosition(body.position + newPos);
	}

	void MoveWalker () {
		body.useGravity = true;

	 	walkerRB.MovePosition((left.position + right.position) / 2f);
		Vector3 leftOffset = new Vector3();
		Vector3 rightOffset = new Vector3();

		leftOffset = left.position + (left.forward * 2f);
		rightOffset = right.position + (right.forward * 2f);
		
		Vector3 offset = (leftOffset + rightOffset)/2f;

		walkerRB.MoveRotation(Quaternion.LookRotation(offset - transform.position, left.position - right.position) * Quaternion.Euler(0f, 0f, -90f));
	}
}
