using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgoritmoProceduralGeneral;

public static class GeneradorParedes 
{
    public static void CreateWalls(HashSet<Vector2Int> floorPos, VisualizarTileMap visualizarTileMap) 
    {
        var basicWallPos = FindWallsInDirection(floorPos, Direction2D.cardinalDirList);
        var cornerWallPos = FindWallsInDirection(floorPos, Direction2D.diagonalDirList);
        CreateBasicWall(visualizarTileMap, basicWallPos, floorPos);
        CreateCornerWalls(visualizarTileMap, basicWallPos, floorPos);
    }

    private static void CreateCornerWalls(VisualizarTileMap visualizarTileMap, HashSet<Vector2Int> cornerWallPos, HashSet<Vector2Int> floorPos)
    {
        foreach (var position in cornerWallPos) 
        {
            string nreigboursBineryType = "";
            foreach (var direction in Direction2D.eightDirectionsList)
            {
                var neighboursPOsition = position + direction;
                if (floorPos.Contains(neighboursPOsition))
                {
                    nreigboursBineryType += "1";
                }
                else 
                {
                    nreigboursBineryType += "0";
                }
            }
            visualizarTileMap.PaintSingleCornerWall(position, nreigboursBineryType);
        }
    }

    private static void CreateBasicWall(VisualizarTileMap visualizarTileMap, HashSet<Vector2Int> basicWallPos, HashSet<Vector2Int> floorPositions)
    {
        foreach (var position in basicWallPos) 
        {
            string neighboursBinaryType = "";
            foreach (var direction in Direction2D.cardinalDirList) 
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else 
                {
                    neighboursBinaryType += "0";
                }
            }
            visualizarTileMap.PaintSingleBasicWall(position, neighboursBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirection(HashSet<Vector2Int> floorPos, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();
        foreach (var position in floorPos)
        {
            foreach (var direction in directionList)
            {
                var neighbourPos = position + direction;
                if (floorPos.Contains(neighbourPos) == false)
                    wallPos.Add(neighbourPos);
            }
        }
        return wallPos;
    }
}
