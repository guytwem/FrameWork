using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.Searching;
using Grid = DialogueSystem.Searching.Grid;

public class Pathfinding : MonoBehaviour
{
   private Grid grid; //grid script reference
   public Transform seeker; // seeker transform
   public Transform target; //target transform
   private void Awake()
   {
      grid = GetComponent<Grid>(); // get the grid script on awake
   }

   private void Update()
   {
      FindPath(seeker.position,target.position);
   }

   /// <summary>
   /// Gets the start pos and end pos.
   /// while not at target pos find out the cost of neighbouring nodes. Choose the node that has lower fCost than current.
   /// </summary>
   /// <param name="startPos">start node(seeker Pos)</param>
   /// <param name="targetPos">target pos (end node)</param>
   void FindPath(Vector3 startPos, Vector3 targetPos)
   {
      Node startNode = grid.NodeFromWorldPoint(startPos);
      Node targetNode = grid.NodeFromWorldPoint(targetPos);

      List<Node> openSet = new List<Node>();
      HashSet<Node> closedSet = new HashSet<Node>();
      openSet.Add(startNode);
      while (openSet.Count > 0)
      {
         Node currentNode = openSet[0];
         for (int i = 1; i < openSet.Count; i++)
         {
            if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
            {
               currentNode = openSet[i];
            }
         }

         openSet.Remove(currentNode);
         closedSet.Add(currentNode);
         //if the current node is the target node then retrace path and stop looping.
         if (currentNode == targetNode)
         {
            RetracePath(startNode,targetNode);
            return;
         }
         //if neighbouring node is walkable then keep looping
         foreach (Node neighbour in grid.GetNeighbours(currentNode))
         {
            if (!neighbour.walkable || closedSet.Contains(neighbour))
            {
               continue;
            }
            //figuring out the cost to neighbouring node
            int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
            if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
            {
               neighbour.gCost = newMovementCostToNeighbour;
               neighbour.hCost = GetDistance(neighbour, targetNode);
               neighbour.parent = currentNode;

               if (!openSet.Contains(neighbour))
               {
                  openSet.Add(neighbour);
               }
            }
         }
      }
   }
/// <summary>
/// reverses the path taking from start node to end node.
/// </summary>
/// <param name="startNode"></param>
/// <param name="endNode"></param>
   void RetracePath(Node startNode, Node endNode)
   {
      List<Node> path = new List<Node>();
      Node currentNode = endNode;

      while (currentNode != startNode)
      {
         path.Add(currentNode);
         currentNode = currentNode.parent;
      }
      path.Reverse();
      grid.path = path; // this is what is drawn in gizmos.
   }

/// <summary>
/// finds out the distance between 2 nodes
/// </summary>
/// <param name="nodeA"></param>
/// <param name="nodeB"></param>
/// <returns></returns>
   int GetDistance(Node nodeA, Node nodeB)
   {
      int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
      int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
      if (dstX > dstY)
      {
         return 14 * dstY + 10 * (dstX - dstY);
      }

      return 14 * dstX + 10 * (dstY - dstX);
   }
}
