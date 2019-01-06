using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Manage when to spawn tiles
public class TileScript : MonoBehaviour {

    private float fallDelay = 1.5f;
    private float despawnDelay = 2;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// When something exits the tile
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "player")
		{
			Debug.Log("SpawnTile");
			// Can access SpawnTile because it is public
			TileManager.Instance.SpawnTile();
            // We start the coroutine script FallDown
            StartCoroutine(FallDown());
		}
     
	}

    // This runs as a seperate script. It waits a few seconds then it makes the cubes fall.
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(despawnDelay);
        switch (gameObject.name)
        {
            // We name these in the TileManager script
            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                break;

        }
    }
}
