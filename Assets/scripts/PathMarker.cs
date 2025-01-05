using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarker
{
    public MapLocation location;
    public float G;
    public float H;
    public float F;
    public GameObject marker;
    public PathMarker parent;

    // Constructor to initialize a PathMarker with its properties.
    public PathMarker(MapLocation l, float g, float h, float f, GameObject marker, PathMarker p)
    {
        location = l;
        G = g;
        H = h;
        F = f;
        this.marker = marker;
        parent = p;
    }

    // Overrides the Equals method to compare two PathMarkers by their location.
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) // Check if the object is null or of a different type.
        {
            return false;
        }
        else
        {
            return location.Equals(((PathMarker)obj).location); // Compare based on location.
        }
    }

    // Overrides the GetHashCode method (not optimized for hash-based collections).
    public override int GetHashCode()
    {
        return 0; // Simplistic hash code; may need improvement for advanced use cases.
    }

}
