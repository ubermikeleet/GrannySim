using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] carPrefab = new GameObject[3];
	public Transform[] spawnPoints = new Transform[3];
	public float spawnInterval = 2f;

	//private int last = -1;

	void Start () {
		InvokeRepeating("Spawn", 0f, spawnInterval);
	}

	void Spawn () {
		int i;
		//do {
			i = Random.Range(0, spawnPoints.Length);
		//} while (i == last);
		//if (i == 3) return;
		Rigidbody rb = Instantiate(carPrefab[Random.Range(0, carPrefab.Length)], spawnPoints[i].position, spawnPoints[i].rotation).GetComponent<Rigidbody>();
		rb.velocity = rb.transform.forward * 2f;
		//last = i;
	}
}