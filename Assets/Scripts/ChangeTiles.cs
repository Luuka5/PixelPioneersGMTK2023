using UnityEngine;
using UnityEngine.Tilemaps;

public class ExampleClass : MonoBehaviour
{
    public TileBase tileA;
    public TileBase tileB;

    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        tilemap.SwapTile(tileA, tileB);
    }
}