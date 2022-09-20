using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisualizarTileMap : MonoBehaviour
{
    [SerializeField ]Tilemap floorTileMap, wallTileMap;
    [SerializeField] TileBase floorTile, wallTop, wallSideRight, wallsSideLeft, wallBottom, wallFull, wallInnerCornerDownLeft, wallInnerCornerDownRight, wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft;


    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPos) 
    {
        PaintTiles(floorPos, floorTileMap, floorTile);
    }

    public void PaintTiles(IEnumerable<Vector2Int> pos, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in pos) 
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType) 
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (WallByTypes.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if (WallByTypes.wallSideRight.Contains(typeAsInt)) 
        {
            tile = wallSideRight;
        }
        else if (WallByTypes.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallsSideLeft;
        }
        else if (WallByTypes.wallBottm.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if (WallByTypes.wallFull.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        if (tile!=null)
            PaintSingleTile(wallTileMap, tile, position);
    }

    public void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePos = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePos, tile);
    }

    public void Clear() 
    {
        floorTileMap.ClearAllTiles();
        wallTileMap.ClearAllTiles();
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType) 
    {
        int typeAsInt = Convert.ToInt32(binaryType);
        TileBase tile = null;

        if (WallByTypes.wallInnerCornerDownLeft.Contains(typeAsInt)) 
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallByTypes.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if (WallByTypes.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if (WallByTypes.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if (WallByTypes.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if (WallByTypes.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if (WallByTypes.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        else if (WallByTypes.wallBottmEightDirections.Contains(typeAsInt))
        {
            tile = wallBottom;
        }

        if (tile != null)
            PaintSingleTile(wallTileMap, tile, position);
    }

}
