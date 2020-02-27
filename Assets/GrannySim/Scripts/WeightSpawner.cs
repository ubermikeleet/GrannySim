using UnityEngine;

public class WeightSpawner : MonoBehaviour {

	public GameObject weightPrefab;
	public Transform spawnOrigin;
	public float radius;
	public float timeBetweenSpawns;

	private float time = 0f;

	private void Start () {
		time = timeBetweenSpawns;
	}

	private void Update () {
		time -= Time.deltaTime;
		if (time <= 0f) {
			Spawn();
			time += timeBetweenSpawns;
		}
	}

	private void Spawn() {
		float x, z;
		x = Random.Range(-radius, radius);
		z = Random.Range(-radius, radius);

		Vector3 v = new Vector3(spawnOrigin.position.x + x, spawnOrigin.position.y, spawnOrigin.position.z + z);

		Instantiate(weightPrefab, v, Quaternion.identity);
	}
}
