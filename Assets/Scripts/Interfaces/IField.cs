﻿using UnityEngine;

public interface IField
{
    int Width { get; set; }
    int Height { get; set; }

    void FieldInit(int width, int height, Vector2Int startPosition, Vector2 spriteShift, GameObject prefab, GameObject prefabsParent);
    void CreateField();
    void UpdateField();
}