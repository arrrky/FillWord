using UnityEngine;
using UnityEngine.Serialization;

public class Field : MonoBehaviour, IField
{
    private GameObject fieldElementPrefab;
    private GameObject fieldElementsParent;
    
    protected GameObject[,] field;
    public int Width { get; set; }
    public int Height { get; set; }
    public Vector2Int StartPosition { get; set; }
    public Vector2 SpriteShift { get; set; }

    public void FieldInit(int width, int height, Vector2Int startPosition, Vector2 spriteShift, GameObject prefab, GameObject prefabsParent)
    {
        Width = width;
        Height = height;
        field = new GameObject[width, height];

        StartPosition = startPosition;
        SpriteShift = spriteShift;
        this.fieldElementPrefab = prefab;
        this.fieldElementsParent = prefabsParent;
        
        CreateField();
    }

    public void CreateField()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                GameObject newCell =  Instantiate(fieldElementPrefab, fieldElementsParent.transform);

                newCell.transform.position = new Vector3(
                    StartPosition.x + SpriteShift.x + x,
                    StartPosition.y + SpriteShift.y + y);

                field[x, y] = newCell;
            }
        }
    }

    public void UpdateField()
    {
        throw new System.NotImplementedException();
    }
}
