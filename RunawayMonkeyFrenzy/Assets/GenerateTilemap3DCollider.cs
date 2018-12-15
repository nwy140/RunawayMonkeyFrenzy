using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class GenerateTilemap3DCollider : MonoBehaviour {



// Spawn cube on all tiles on tilemap
	public GameObject cube;
	private Tilemap tilemap;
	private GameObject playerTarget;
	public List<Vector3> tileWorldLocations;

// texture
	 Texture3D texture;

	void Awake() {
		tilemap = GetComponent<Tilemap>();
		playerTarget=GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);	
	}

	void Start () {

        texture = CreateTexture3D (256);
		
		tileWorldLocations = new List<Vector3>();

		foreach (var pos in tilemap.cellBounds.allPositionsWithin)
		{   	
			Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z) ;
			Vector3 place = tilemap.CellToWorld(localPlace);
			if (tilemap.HasTile(localPlace))
			{
				tileWorldLocations.Add(place);
				GameObject spawnedObject = Instantiate(cube, new Vector3(place.x,place.y,0.5f), Quaternion.identity);
				
				spawnedObject.GetComponent<MeshRenderer>().material.mainTexture = CreateTexture3D(1);
			}
		}

 		print(tileWorldLocations);   
	}
//
// texture swap https://stackoverflow.com/questions/33150369/how-to-change-the-texture-of-object-at-run-time-on-button-click-in-unity-by-usin
// public Texture[] textures;
// public int currentTexture;



// public void swapTexture() { currentTexture++;
//     currentTexture %= textures.Length;
//     GetComponent<Renderer>().material.mainTexture = textures[currentTexture]; 
// }
// //
//    

    Texture3D CreateTexture3D (int size)
    {
        Color[] colorArray = new Color[size * size * size];
        texture = new Texture3D (size, size, size, TextureFormat.RGBA32, true);
        float r = 1.0f / (size - 1.0f);
        for (int x = 0; x < size; x++) {
            for (int y = 0; y < size; y++) {
                for (int z = 0; z < size; z++) {
                    Color c = new Color (x * r, y * r, z * r, 1.0f);
                    colorArray[x + (y * size) + (z * size * size)] = c;
                }
            }
        }
        texture.SetPixels (colorArray);
        texture.Apply ();
        return texture;
    }

//
}


					// Instantiate(cube, new Vector3(x,y,0), Quaternion.identity);
