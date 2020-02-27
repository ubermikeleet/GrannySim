using UnityEngine;

public class Grab : MonoBehaviour {

	public SteamVR_TrackedObject controller;

	private GameObject collisionObj;
	private FixedJoint joint;

	void Update() {
		var device = SteamVR_Controller.Input((int)controller.index);
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip)) {
			MakeJoint();
		}
		else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Grip)) {
			UnmakeJoint();
		}
	}

	void OnTriggerEnter (Collider c) {
		collisionObj = c.gameObject;
	}

	void OnTriggerExit () {
		collisionObj = null;
	}

	void MakeJoint () {
		if (collisionObj != null) {
			joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = collisionObj.GetComponentInParent<Rigidbody>();
		}
	}

	void UnmakeJoint () {
		Destroy(joint);
	}
}
