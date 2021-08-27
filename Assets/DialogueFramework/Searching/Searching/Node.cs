using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem.Searching
{
    public class Node
    {
        public bool walkable;
        public Vector3 worldPosition;
        public int gridX;
        public int gridY;
        public int gCost;
        public int hCost;
        public Node parent;
        
        /// <summary>
        /// Base Node method that is inherited in pathfinding.
        /// </summary>
        /// <param name="_walkable">is it walkable?</param>
        /// <param name="_worldPos">world position of node</param>
        /// <param name="_gridX"> grid x position</param>
        /// <param name="_gridY">grid y position</param>
        public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
        {
            walkable = _walkable;
            worldPosition = _worldPos;
            gridX = _gridX;
            gridY = _gridY;
        }
        
        /// <summary>
        /// determines the cost of each node in relation to distance from target node.
        /// </summary>
        public int fCost
        {
            get { return gCost + hCost; }
        }
    }
}

