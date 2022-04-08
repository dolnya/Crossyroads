using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static List<Transform> GetChildren(this Transform transform)
    {
        var children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        return children;
    }
}
