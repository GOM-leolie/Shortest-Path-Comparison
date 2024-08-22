using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortestPathComparison.Classes
{
    class Node
    {
        public String startNode;
        public String endNode;
        public int actualCost;
        public int heuristicCost;
        public int astarCost;
        public int cummulativeActualCost;
        public Node next;

        public Node()
        {
            startNode = "";
            endNode = "";
            actualCost = 0;
            heuristicCost = 0;
            astarCost = 0;
            cummulativeActualCost = 0;
            next = null;
        }

        public Node(String newStartNode, String newEndNode, int newActualCost, int newHeuristicCost, int newastarCost, int newCummulativeActualCost)
        {
            setNode(newStartNode, newEndNode, newActualCost, newHeuristicCost, newastarCost, newCummulativeActualCost);
        }

        public Node(Node newNode)
        {
            startNode = newNode.startNode;
            endNode = newNode.endNode;
            actualCost = newNode.actualCost;
            heuristicCost = newNode.heuristicCost;
            astarCost = newNode.astarCost;
            cummulativeActualCost = newNode.cummulativeActualCost;
        }

        public void setNode(String newStartNode, String newEndNode, int newActualCost, int newHeuristicCost, int newastarCost, int newCummulativeActualCost)
        {
            startNode = newStartNode;
            endNode = newEndNode;
            actualCost = newActualCost;
            heuristicCost = newHeuristicCost;
            astarCost = newastarCost;
            cummulativeActualCost = newCummulativeActualCost;
        }
    }
}