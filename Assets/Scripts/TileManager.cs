using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	// The prefab for tiles
	public GameObject[] tilePrefabs;
	// The current tile object in game
	public GameObject currentTile;


	private static TileManager instance;
	public static TileManager Instance
	{
		get
		{
			if (instance == null)
			{

				instance = GameObject.FindObjectOfType<TileManager>();
			}
			return instance;
		}
	}

    // name variables and thenassign memory to them using new
    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    public Stack<GameObject> LeftTiles
    {
        get
        {
            return leftTiles;
        }
        set
        {
            leftTiles = value;
        }
    }

 
    private Stack<GameObject> topTiles = new Stack<GameObject>();
    public Stack<GameObject> TopTiles
    {
        get
        {
            return topTiles;
        }
        set
        {
            topTiles = value;
        }
    }


    // Use this for initialization
    void Start () {
        /*
        GameObject second = null;
        leftTiles.Push(currentTile);
        leftTiles.Push(second)
        // This would look at the top tile which = second
        GameObject tileOnTop = leftTiles.Peek();
        // This would takes second out of the stack
        GameObject lastRemoved = leftTiles.Pop();
        */
        CreateTiles(100);
        for (int j = 0; j < 50;  j++)
        {
            SpawnTile();
        }


    }

	// Update is called once per frame
	void Update () {

	}

	public void SpawnTile()
	{

        // See if we have enough tiles
        if (LeftTiles.Count == 0 || TopTiles.Count == 0)
        {
            CreateTiles(10);
        }

		// Upper number not included in the range.
		int randomIndex = Random.Range(0, 2);


        if (randomIndex == 0)
        {
            // Removes the top of the leftTiles stack and sets it = tmp
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {
            // Removes the top of the leftTiles stack and sets it = tmp
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        // Instantiate takes a prefab and adds it to the game world
		// The below code does not work because instantiate creates an Object and currentTile is a GameObject
		// Hence that is why we need to change the type of Object at the start with (GameObject)
		//currentTile = Instantiate(tilePrefab[0], currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
	}

    public void CreateTiles(int amount)
    {
        for (int i = 1; i < amount; i++)
        {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));
            // We name the tiles here and refer to this in the TileScript 
            TopTiles.Peek().name = "TopTile";
            LeftTiles.Peek().name = "LeftTile";
            TopTiles.Peek().SetActive(false);
            LeftTiles.Peek().SetActive(false);


        }
    }
}
