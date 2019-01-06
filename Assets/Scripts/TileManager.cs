using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	// The prefab for tiles
	public GameObject[] tilePrefabs;
	// The current tile object in game
	public GameObject currentTile;

	// Use this for initialization
	void Start () {
		for (int i = 1; i < 10; i++)
		{
			SpawnTile();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void SpawnTile()
	{
		// Upper number not included in the range.
		int randomIndex = Random.Range(0, 2);
		// Instantiate takes a prefab and adds it to the game world
		currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
		// The below code does not work because instantiate creates an Object and currentTile is a GameObject
		// Hence that is why we need to change the type of Object at the start with (GameObject)
		//currentTile = Instantiate(tilePrefab[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
	}
}
