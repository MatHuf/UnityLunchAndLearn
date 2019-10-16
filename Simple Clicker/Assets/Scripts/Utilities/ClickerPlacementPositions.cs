using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerPlacementPositions
{
    List<Vector3> positions;

    public ClickerPlacementPositions()
    {
        positions = new List<Vector3>{
            Vector3.zero,               // Center
            new Vector3(-2f, 0f, 0f),   // 1st Row Front left
            new Vector3(0f, 0f, -2f),   // 1st Row Front right
            new Vector3(0f, 0f, 2f),    // 2nd Row Back left
            new Vector3(2f, 0f, 0f) ,   // 2nd Row Back right
            new Vector3(-2f, 0f, -2f),  // 3rd Row Near Center
            new Vector3(2f, 0f, 2f),    // 3rd Row Far Center
            new Vector3(-2f, 0f, 2f),   // 4th Row Far left
            new Vector3(2f, 0f, -2f)    // 4th Row Far right
        };
    }

    public Vector3? GetNextPosition()
    {
        if (positions.Count < 1) return null;
        Vector3 next = positions[0];
        positions.RemoveAt(0);
        return next;
    }
}
