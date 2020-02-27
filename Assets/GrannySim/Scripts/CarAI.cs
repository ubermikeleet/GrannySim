using UnityEngine;

[RequireComponent(typeof (UnityStandardAssets.Vehicles.Car.CarController))]
public class CarAI : MonoBehaviour {

	public enum DriverType {
		Red,
		Blue,
		Green,
	}

	public DriverType driver = DriverType.Red;

	[SerializeField]
	private float speed;
	[SerializeField]
	private float revs;

	private UnityStandardAssets.Vehicles.Car.CarController controller;

	[SerializeField]
	private bool playerDetected = false;
	
	private bool avoiding = false;
	private float steering;

	private void Awake () {
		controller = GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
	}

	private void FixedUpdate () {
		if (controller == null) return;

		DoAI();

		speed = controller.CurrentSpeed;
		revs = controller.Revs;

	}

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			playerDetected = true;
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			playerDetected = false;
			avoiding = false;
		}
	}

	private void DoAI () {
		if (!playerDetected) {
			controller.Move(0, 1f, 0, 0);
		}
		else {
			if (driver == DriverType.Red) {
				controller.Move(0, 1f, 0, 0);
			}
			else if (driver == DriverType.Green) {
				if (!avoiding) {
					steering = Mathf.Sign(Random.Range(-1f, 1f));
					avoiding = true;
				}
				controller.Move(steering, 0, 1f, 0);
			}
			else if (driver == DriverType.Blue) {
				controller.Move(0, 0, 1f, 1f);
			}
		}
	}
}
