using UnityEngine;
using UnityEngine.Serialization;

public class Field : MonoBehaviour, IField
{
    private GameObject _fieldElementPrefab;
    private GameObject _fieldElementsParent;
    
    protected GameObject[,] ObjectsField;
    public int Width { get; set; }
    public int Height { get; set; }
    private Vector3 StartPosition { get; set; }
    private Vector2 SpriteShift { get; set; }

    public void FieldInit(int width, int height, Vector3 startPosition, Vector2 spriteShift, GameObject prefab, GameObject prefabsParent)
    {
        Width = width;
        Height = height;
        ObjectsField = new GameObject[width, height];

        StartPosition = startPosition;
        SpriteShift = spriteShift;
        this._fieldElementPrefab = prefab;
        this._fieldElementsParent = prefabsParent;
    }

    public void CreateField()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                GameObject newCell =  Instantiate(_fieldElementPrefab, _fieldElementsParent.transform);

                newCell.transform.position = new Vector3(
                    StartPosition.x + SpriteShift.x + x,
                    StartPosition.y + SpriteShift.y + y);

                ObjectsField[x, y] = newCell;
            }
        }
    }

    public void UpdateField()
    {
        throw new System.NotImplementedException();
    }
}
