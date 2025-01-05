using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class FindPathStar : MonoBehaviour
{
    public Maze maze;
    public Material closedMaterial;
    public Material openMaterial;
    List<PathMarker> open = new List<PathMarker>();
    List<PathMarker> closed = new List<PathMarker>();
    public GameObject start;
    public GameObject end;
    public GameObject pathP;

    PathMarker goalNode; // The goal node in the maze.
    PathMarker startNode; // The start node in the maze.
    PathMarker lastPos; // The most recently processed node.
    bool done = false; // Flag to indicate if the search is complete.

    // Removes all markers from the maze.
    void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
            Destroy(m); // Destroy each marker object.
    }

    // Begins the A* search process by initializing start and goal nodes.
    void BeginSearch()
    {
        done = false;
        RemoveAllMarkers(); // Clear existing markers.
        List<MapLocation> locations = new List<MapLocation>(); // List of available locations in the maze.
        for (int z = 1; z < maze.depth - 1; z++)
        {
            for (int x = 1; x < maze.depth - 1; x++)
            {
                if (maze.map[x, z] != 1) // Check if the location is not a wall.
                    locations.Add(new MapLocation(x, z));
            }

            locations.Shuffle(); // Randomize the locations.

            // Set up the start node.
            Vector3 startLocation = new Vector3(locations[0].x * maze.scale, 0, locations[0].z * maze.scale);
            startNode = new PathMarker(new MapLocation(locations[0].x, locations[0].z), 0, 0, 0,
            Instantiate(start, startLocation, Quaternion.identity), null);

            // Set up the goal node.
            Vector3 goalLocation = new Vector3(locations[1].x * maze.scale, 0, locations[1].z * maze.scale);
            goalNode = new PathMarker(new MapLocation(locations[1].x, locations[1].z), 0, 0, 0,
            Instantiate(end, goalLocation, Quaternion.identity), null);

            // Clear open and closed lists, and initialize with the start node.
            open.Clear();
            closed.Clear();
            open.Add(startNode);
            lastPos = startNode;
        }
    }

    // Performs the A* search logic for the current node.
    void Search(PathMarker thisNode)
    {
        if (thisNode == null) return; // Ensure the current node is not null.

        if (thisNode.Equals(goalNode)) { done = true; return; } // End search if goal is reached.

        // Evaluate all possible neighboring nodes.
        foreach (MapLocation dir in maze.directions)
        {
            MapLocation neighbor = dir + thisNode.location; // Calculate neighbor location.
            if (maze.map[neighbor.x, neighbor.z] == 1) continue; // Skip walls.
            if (neighbor.x < 1 || neighbor.x >= maze.width || neighbor.z < 1 || neighbor.z >= maze.depth) continue; // Skip out-of-bounds locations.
            if (IsClosed(neighbor)) continue; // Skip if the neighbor is already in the closed list.

            // Calculate G, H, and F values for the neighbor.
            float G = Vector2.Distance(thisNode.location.ToVector(), neighbor.ToVector()) + thisNode.G;
            float H = Vector2.Distance(neighbor.ToVector(), goalNode.location.ToVector());
            float F = G + H;

            // Instantiate a marker for the neighbor.
            GameObject pathBlock = Instantiate(pathP, new Vector3(neighbor.x * maze.scale, 0, neighbor.z * maze.scale), Quaternion.identity);
            TextMesh[] values = pathBlock.GetComponentsInChildren<TextMesh>();
            // Assign G, H, and F values to the marker for visualization.
            values[0].text = "G: " + G.ToString("0.00");
            values[1].text = "H: " + H.ToString("0.00");
            values[2].text = "F: " + F.ToString("0.00");

            // Add the neighbor to the open list if it’s not already there or update its values.
            if (!UpdateMarker(neighbor, G, H, F, thisNode))
                open.Add(new PathMarker(neighbor, G, H, F, pathBlock, thisNode));
        }

        // Select the node with the smallest F value, and if tied, the smallest H value.
        open = open.OrderBy(p => p.F).ThenBy(n => n.H).ToList<PathMarker>();
        PathMarker pm = (PathMarker)open.ElementAt(0);
        closed.Add(pm); // Move the node from open to closed list.
        open.RemoveAt(0);
        pm.marker.GetComponent<Renderer>().material = closedMaterial; // Update material to indicate closed status.
        lastPos = pm; // Update the last processed node.
    }

    // Checks if a location is in the closed list.
    bool IsClosed(MapLocation marker)
    {
        foreach (PathMarker p in closed)
        {
            if (p.location.Equals(marker)) return true;
        }
        return false;
    }

    // Updates the marker in the open list if it already exists.
    bool UpdateMarker(MapLocation pos, float g, float h, float f, PathMarker prt)
    {
        foreach (PathMarker p in open)
        {
            if (p.location.Equals(pos))
            {
                p.G = g; // Update G value.
                p.H = h; // Update H value.
                p.F = f; // Update F value.
                p.parent = prt; // Update parent.
                return true;
            }
        }
        return false;
    }

    // Retrieves the path from the goal to the start by following parent links.
    void GetPath()
    {
        RemoveAllMarkers(); // Clear existing markers.
        PathMarker begin = lastPos; // Start from the last processed node.
        while (!startNode.Equals(begin) && begin != null)
        {
            // Instantiate a path marker for each node in the path.
            Instantiate(pathP, new Vector3(begin.location.x * maze.scale, 0, begin.location.z * maze.scale), Quaternion.identity);
            begin = begin.parent; // Move to the parent node.
        }
        // Instantiate a marker for the start node.
        Instantiate(pathP, new Vector3(startNode.location.x * maze.scale, 0, startNode.location.z * maze.scale), Quaternion.identity);
    }

    // Handles user input to control the search and path visualization.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) BeginSearch(); // Start a new search.
        if (Input.GetKeyDown(KeyCode.C) && !done) Search(lastPos); // Continue the search step-by-step.
        if (Input.GetKeyDown(KeyCode.M)) GetPath(); // Visualize the complete path.
    }

}
