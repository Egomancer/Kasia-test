using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralController : MonoBehaviour {

	[SerializeField] Text timerText;

	[SerializeField] GameObject cubePrefab;
	System.DateTime time;
	int lastSpawnTime;

	List<GameObject> cubeList;

	Vector3 spawnPos;

	int oldestCubeIndex;

	// Use this for initialization
	void Start () {
		time = System.DateTime.UtcNow;
		lastSpawnTime = -1;
		spawnPos = new Vector3 (-6f, 0, 0);
		cubeList = new List<GameObject> ();
	}

	void SetTimer() {
		timerText.text = time.Hour + ":" + time.Minute + ":" + time.Second;
	}
	
	// Update is called once per frame
	void Update () {
		time = System.DateTime.UtcNow;
		SetTimer ();

		if (time.Second % 2 == 0 && time.Second != lastSpawnTime) {
			SpawnCube ();
			lastSpawnTime = time.Second;
		}
	}

	void SpawnCube() {
		if (cubeList.Count == 10) {
			Destroy (cubeList [oldestCubeIndex]); //REMOVE OLDEST CUBE
			spawnPos.x = -6f + oldestCubeIndex * 1.1f;
			GameObject v_cube = GameObject.Instantiate (cubePrefab, spawnPos, Quaternion.identity);
			v_cube.transform.localScale = Vector3.one * Random.Range (0.3f, 1f); //SET RANDOM SCALE JUST TO DIFFERENTIATE THE NEW CUBE FROM THE OLD CUBE
			cubeList [oldestCubeIndex] = v_cube;
			oldestCubeIndex = (oldestCubeIndex + 1) % 10;
		} else {
			spawnPos.x = -6f + cubeList.Count * 1.1f;
			GameObject v_cube = GameObject.Instantiate (cubePrefab, spawnPos, Quaternion.identity);
			v_cube.transform.localScale = Vector3.one * Random.Range (0.3f, 1f);
			cubeList.Add(v_cube);
		}
	}
}
