using UnityEngine;

public interface IField
{
    int Width { get; set; }
    int Height { get; set; }

    void Init(int width, int height, Vector3 startPosition, Vector2 spriteShift, GameObject prefab, GameObject prefabsParent);
    void CreateField();
    void UpdateField();
}