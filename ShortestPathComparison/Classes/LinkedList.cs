using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPathComparison.Classes;

namespace ShortestPathComparison
{
    class LinkedList
    {

        private int count;
        private float timer;
        private Node head;

        public LinkedList()
        {
            head = new Node();
            count = 0;
            timer = 0;
        }

        public LinkedList(Node newNode, int newCount, int newTimer)
        {
            head = newNode;
            count = newCount;
            timer = newTimer;
        }

        public void insertFirst(Node newNode)
        {
            if (count == 0)
            {
                head.next = newNode;
                count++;
            }
            else
            {
                newNode.next = head.next;
                head.next = newNode;
                count++;
            }
        }

        public void insertLast(Node newNode)
        {

            if (count == 0)
            {
                head.next = newNode;
                count++;
            }
            else
            {
                Node currentNode = new Node();
                currentNode = head;

                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = newNode;
                count++;
            }
        }

        public Node getNode(int index)
        {
            Node currentNode = new Node();
            currentNode = head;

            for (int i = 0; i < index; i++)
                currentNode = currentNode.next;

            return currentNode;
        }

        public void removeNode(Node newNode)
        {
            Boolean isEqual = false;
            Node currentNode = new Node();
            Node previousNode = new Node();
            currentNode = head;

            while (!isEqual)
            {
                if (String.Equals(newNode.startNode,currentNode.startNode))
                    if (String.Equals(newNode.endNode,currentNode.endNode))
                        if (currentNode.actualCost == newNode.actualCost)
                            if (currentNode.heuristicCost == newNode.heuristicCost)
                                if (currentNode.astarCost == newNode.astarCost)
                                    isEqual = true;

                if (isEqual == false)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }
                else
                {
                    if (count <= 1)
                        head.next = null;
                    else
                    {
                        previousNode.next = currentNode.next;
                        currentNode.next = null;
                        currentNode = null;
                        count--;
                    }
                }
            }
        }

        public int getCount()
        {
            return count;
        }

        public float getTimer()
        {
            return timer;
        }

        public void setTimer(float newTimer)
        {
            timer = newTimer;
        }
    }
}
