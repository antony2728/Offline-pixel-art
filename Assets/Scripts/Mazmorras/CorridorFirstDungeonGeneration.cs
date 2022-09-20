using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static AlgoritmoProceduralGeneral;

public class CorridorFirstDungeonGeneration : GeneradorSimpleRandomDungeon
{
    [SerializeField] int corridorLenght = 14, corridorCount = 5;
    [SerializeField][Range(0.1f, 1)] float roomPercent = 0.8f;

    Dictionary<Vector2Int, HashSet<Vector2Int>> roomsDictoniary = new Dictionary<Vector2Int, HashSet<Vector2Int>>();
    HashSet<Vector2Int> floorPositions, corridorPositions;

    protected override void RunProceduralGeneration()
    {
        CorridoFirstGeneration();
    }

    void CorridoFirstGeneration() 
    {
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPos = new HashSet<Vector2Int>();

        CreateCorridos(floorPos, potentialRoomPos);

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPos);
        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPos);
        CreateRoomAtDeadEnd(deadEnds, roomPositions);
        floorPos.UnionWith(roomPositions);
        tilemapVisualizer.PaintFloorTiles(floorPos);
        GeneradorParedes.CreateWalls(floorPos, tilemapVisualizer);
    }

    private void CreateRoomAtDeadEnd(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors)
    {
        foreach (var position in deadEnds) 
        {
            if (roomFloors.Contains(position) == false) 
            {
                var room = RunRandomWalk(randomWälkParameters, position);
                roomFloors.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>();
        foreach (var position in floorPositions)
        {
            int neighboursCount = 0;
            foreach (var direction in Direction2D.cardinalDirList)
            {
                if (floorPositions.Contains(position + direction))
                    neighboursCount++;
            }
            if (neighboursCount == 1)
                deadEnds.Add(position);
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomtoCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);
        List<Vector2Int> roomToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomtoCreateCount).ToList();
        ClearRoomData();
        foreach (var roomPosition in roomToCreate) 
        {
            var roomsFloor = RunRandomWalk(randomWälkParameters, roomPosition);
            SaveRoomData(roomPosition, roomsFloor);
            roomPositions.UnionWith(roomsFloor);
        }
        return roomPositions;
    }

    private void SaveRoomData(Vector2Int roomPosition, HashSet<Vector2Int> roomsFloor)
    {
        roomsDictoniary[roomPosition] = roomsFloor;
    }

    private void ClearRoomData()
    {
        roomsDictoniary.Clear();
    }



    private void CreateCorridos(HashSet<Vector2Int> floorPos, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPos = startPos;
        potentialRoomPositions.Add(currentPos);
        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = AlgoritmoProceduralGeneral.RandomWalkCorridor(currentPos, corridorLenght);
            currentPos = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPos);
            floorPos.UnionWith(corridor);
        }
        corridorPositions = new HashSet<Vector2Int>(floorPos);
    }
}
