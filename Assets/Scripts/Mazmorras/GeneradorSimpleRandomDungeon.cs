using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class GeneradorSimpleRandomDungeon : GeneradorAbstractoDungeon
{
    [SerializeField] protected Vector2Int startPos = Vector2Int.zero;

    [SerializeField] protected SimpleRandomWalkSO randomW�lkParameters;


    protected override void RunProceduralGeneration() 
    {
        HashSet<Vector2Int> floorPos = RunRandomWalk(randomW�lkParameters, startPos);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPos);
        GeneradorParedes.CreateWalls(floorPos, tilemapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position) 
    {
        var currentPos = position;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < randomW�lkParameters.iteratioins; i++) 
        {
            var path = AlgoritmoProceduralGeneral.SimpleRandomWalk(currentPos, randomW�lkParameters.walkLenght);
            floorPos.UnionWith(path);
            if (randomW�lkParameters.startRandomlyEachInteration)
                currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
        }
        return floorPos;
    }
}
