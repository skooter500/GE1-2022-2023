using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour {
    public GameObject tilePrefab;
    public Transform player;
    public int quadsPerTile;

    public int halfTile = 5;

    // Use this for initialization
    void Start()
    {

        TerrainTile tt = tilePrefab.GetComponent<TerrainTile>();
        if (tt != null)
        {
            quadsPerTile = tt.quadsPerTile;
        }
        
        if (player == null)
        {
            player = Camera.main.transform;
        }

        StartCoroutine(GenerateWorldAroundPlayer());

    }

    // Update is called once per frame
    void Update()
    {

    }

    Queue<GameObject> oldGameObjects = new Queue<GameObject>();
    Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();

    private IEnumerator GenerateWorldAroundPlayer()
    {        
        // Make sure this happens at once at the start
        int xMove = int.MaxValue;
        int zMove = int.MaxValue;

        // Adapted from https://www.youtube.com/watch?v=dycHQFEz8VI

        while (true)
        {
            if (oldGameObjects.Count > 0)
            {
                GameObject.Destroy(oldGameObjects.Dequeue());
            }
            if (Mathf.Abs(xMove) >= quadsPerTile|| Mathf.Abs(zMove) >= quadsPerTile)
            {
                float updateTime = Time.realtimeSinceStartup;

                //force integer position and round to nearest tilesize
                int playerX = (int)(Mathf.Floor((player.transform.position.x) / (quadsPerTile)) * quadsPerTile);
                int playerZ = (int)(Mathf.Floor((player.transform.position.z) / (quadsPerTile)) * quadsPerTile);
                List<Vector3> newTiles = new List<Vector3>();
                for (int x = -halfTile; x < halfTile; x++)
                {
                    for (int z = -halfTile; z < halfTile; z++)
                    {
                        Vector3 pos = new Vector3((x * quadsPerTile + playerX),
                            0,
                            (z * quadsPerTile + playerZ));
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        if (!tiles.ContainsKey(tilename))
                        {
                            newTiles.Add(pos);
                        }
                        else
                        {
                            (tiles[tilename] as Tile).creationTime = updateTime;
                        }
                    }
                }
                // Sort in order of distance from the player
                newTiles.Sort((a, b) => (int)Vector3.SqrMagnitude(player.transform.position - a) - (int)Vector3.SqrMagnitude(player.transform.position - b));
                foreach (Vector3 pos in newTiles)
                {
                    GameObject t = GameObject.Instantiate<GameObject>(tilePrefab, pos, Quaternion.identity);
                    t.transform.parent = this.transform;
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                    t.name = tilename;
                    Tile tile = new Tile(t, updateTime);
                    tiles[tilename] = tile;
                    yield return null;
                }

                //destroy all tiles not just created or with time updated
                //and put new tiles and tiles to be kepts in a new hashtable
                Dictionary<string, Tile> newTerrain = new Dictionary<string, Tile>();
                foreach (Tile tile in tiles.Values)
                {
                    if (tile.creationTime != updateTime)
                    {
                        oldGameObjects.Enqueue(tile.theTile);
                    }
                    else
                    {
                        newTerrain[tile.theTile.name] = tile;
                    }
                }
                //copy new hashtable contents to the working hashtable
                tiles = newTerrain;
                startPos = player.transform.position;
            }
            yield return null;
            //determine how far the player has moved since last terrain update
            xMove = (int)(player.transform.position.x - startPos.x);
            zMove = (int)(player.transform.position.z - startPos.z);
        }
    }

    Vector3 startPos;

    class Tile
    {
        public GameObject theTile;
        public float creationTime;


        public Tile(GameObject t, float ct)
        {
            theTile = t;
            creationTime = ct;
        }
    }


}
