using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneradorAbstractoDungeon : MonoBehaviour
{
    [SerializeField] protected VisualizarTileMap tilemapVisualizer = null;
    [SerializeField] protected Vector2Int starpos = Vector2Int.zero;

    public void GenerateDungeon() 
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
