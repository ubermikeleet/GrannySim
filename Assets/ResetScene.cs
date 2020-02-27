using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

	public SteamVR_TrackedObject controller;

	void Update() {
		var device = SteamVR_Controller.Input((int)controller.index);
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
