using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase tileBase;
    Camera cam;
    float height;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        width = 6.0f * camHalfWidth;
        height = 6.0f * camHalfHeight;

        tileMap.ClearAllTiles();
        RenderMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderMap()
    {
        tileMap.ClearAllTiles();
        for(int x = (int)-width; x < width; x++) /*temos de ter em conta a posição do jogador, somar posição do jogador com
                                                width*/
        {
            for(int y = (int)-height; y < height; y++)
            {
                tileMap.SetTile(new Vector3Int(x, y, 1), tileBase);
            }
        }
    }

    //TODO UpdateMap
    public void UpdateMap()
    {
        
    }
}
