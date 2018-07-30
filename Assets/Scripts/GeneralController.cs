using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour {
	[SerializeField] GameObject cubePrefab;
	System.DateTime time;
	System.DateTime lastTime;
	int lastSpawnTime;

	List<GameObject> cubeList;
	Vector3 spawnPos;
	int oldestCubeIndex;

	// Use this for initialization
	void Start () {
		lastSpawnTime = -1;
		spawnPos = new Vector3 (-6f, 0, 0);
		cubeList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		time = System.DateTime.UtcNow;

		if (time.Second % 2 == 0 && time.Second != lastSpawnTime) {
			SpawnCube ();
			lastSpawnTime = time.Second;
		}
	}

	void SpawnCube() {
		if (cubeList.Count == 10) {
			cubeList[oldestCubeIndex].transform.localScale = Vector3.one * Random.Range (0.3f, 1f);
			oldestCubeIndex = (oldestCubeIndex + 1) % 10;
		} else {
			spawnPos.x = -6f + cubeList.Count * 1.1f;
			GameObject v_cube = GameObject.Instantiate (cubePrefab, spawnPos, Quaternion.identity);
			v_cube.transform.localScale = Vector3.one * Random.Range (0.3f, 1f);
			cubeList.Add(v_cube);
		}
	}
}
