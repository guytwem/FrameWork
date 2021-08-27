using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.Searching
{
    public class Grid : MonoBehaviour
    {
        
        public LayerMask unwalkableMask; //what is unwalkable
        public Vector2 gridWorldSize; // world size of grid
        public float nodeRadius; // radius of each node
        private Node[,] grid;

        private float nodeDiameter; // node diameter
        private int gridSizeX; //grid x size
        private int gridSizeY; //grid y size

        private void Start()
        {
            //getting the size of the grid and creating it
            nodeDiameter = nodeRadius * 2; 
            gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
            CreateGrid();
        }
        
        /// <summary>
        /// Creates a grid
        /// </summary>
        private void CreateGrid()
        {
            grid = new Node[gridSizeX, gridSizeY]; // grid with x and y
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 -
                                      Vector3.forward * gridWorldSize.y / 2; //getting bottom left position
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++) //loop while x and y are less than the grid size.
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) +
                                         Vector3.forward * (y * nodeDiameter + nodeRadius);
                    bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask)); //checking what is walkable
                    grid[x, y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }
        
        /// <summary>
        /// Finds out what nodes are nearby
        /// </summary>
        /// <param name="node">what the current node is</param>
        /// <returns>neighbouring nodes</returns>
        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;
                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add(grid[checkX,checkY]);
                    }
                }
            }

            return neighbours;
        }
        
       
        public Node NodeFromWorldPoint(Vector3 worldPosition)
        {
            float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);

            int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
            return grid[x, y];
        }

        public List<Node> path; // List of Nodes that is the path from current to target node.
        
        /// <summary>
        /// Draws the grid and path in the scene to visualise what is happening.
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y)); //draws the grid

            if (grid != null)
            {
                
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.red; //walkable grid is white /unwalkable is red.
                    if (path != null)
                    {
                        if (path.Contains(n))
                        {
                            Gizmos.color = Color.black; //draws a path in black
                        }
                    }
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
                }
            }
        }
    }
}

