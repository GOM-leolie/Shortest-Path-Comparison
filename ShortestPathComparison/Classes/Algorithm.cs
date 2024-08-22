using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ShortestPathComparison.Classes
{
    class Algorithm
    {
        public LinkedList actualPath;
        public LinkedList pendingQueue;
        public LinkedList doneQueue;

        public Algorithm()
        {
            actualPath = new LinkedList();
            pendingQueue = new LinkedList();
            doneQueue = new LinkedList();
        }

        public void astarAlgorithm(LinkedList linkedList, String startNode, string goalNode)
        {
            Node currentNode;
            Node previousNode;
            Node tempNode;
            String currentNodeName;
            int? minimumCost;
            int smallestIndex;
            Boolean isExist;

            currentNodeName = startNode;
            previousNode = new Node(startNode,startNode,0,0,0,0);
            tempNode = new Node(startNode, startNode, 0, 0, 0, 0);
            currentNode = new Node();
            isExist = false;

            while (!String.Equals(currentNodeName,goalNode))
            {
                for (int i = 0 ; i < linkedList.getCount() ; i++)
                {
                    currentNode = linkedList.getNode(i + 1);

                    if ((String.Equals(currentNode.startNode, currentNodeName)) || (String.Equals(currentNode.endNode, currentNodeName)))
                    {                        
                        if (String.Equals(currentNode.endNode, currentNodeName))
                        {
                            String tempName;
                            tempName = currentNode.startNode;
                            currentNode.startNode = currentNode.endNode;
                            currentNode.endNode = tempName;
                        }

                        currentNode.heuristicCost = countHeuristicCost(currentNode.endNode, goalNode);
                        currentNode.astarCost = (tempNode.cummulativeActualCost + currentNode.actualCost) + currentNode.heuristicCost;
                        currentNode.cummulativeActualCost = currentNode.actualCost + tempNode.cummulativeActualCost;

                        Node node = new Node(currentNode);
                        pendingQueue.insertLast(node);
                    }
                }

                Node node2 = new Node(previousNode);
                doneQueue.insertLast(node2);

                minimumCost = pendingQueue.getNode(1).astarCost;
                smallestIndex = 0;
                isExist = true;

                while (isExist)
                {
                    isExist = false;
                    for (int i = 0; i < pendingQueue.getCount(); i++)
                    {
                        currentNode = pendingQueue.getNode(i + 1);
                        if (currentNode.astarCost < minimumCost)
                        {
                            minimumCost = currentNode.astarCost;
                            smallestIndex = i;
                        }

                        if (currentNode.astarCost == minimumCost)
                        {
                            if (currentNode.heuristicCost < pendingQueue.getNode(smallestIndex +1).heuristicCost)
                            {
                                minimumCost = currentNode.astarCost;
                                smallestIndex = i;
                            }
                        }
                    }

                    currentNode = pendingQueue.getNode(smallestIndex + 1);

                    for (int i = 0; i < doneQueue.getCount(); i++)
                    {
                        Node node;
                        node = doneQueue.getNode(i + 1);

                        if (String.Equals(node.endNode, currentNode.endNode))
                            isExist = true;
                    }

                    if (isExist)
                    {
                        minimumCost = pendingQueue.getNode(1).astarCost;
                        smallestIndex = 0;
                        pendingQueue.removeNode(currentNode);
                    }
                }
                currentNode = pendingQueue.getNode(smallestIndex + 1);

                previousNode = new Node(currentNode);
                pendingQueue.removeNode(currentNode);

                currentNodeName = currentNode.endNode;
                tempNode = new Node(currentNode);
                
            }

            Node node1 = new Node(previousNode);
            doneQueue.insertLast(node1);

            while (!String.Equals(currentNodeName, startNode))
            {
                for (int i = 0; i < doneQueue.getCount(); i++)
                {
                    Node node2 = doneQueue.getNode(i + 1);
                    if (String.Equals(node2.endNode, currentNodeName))
                        currentNode = new Node(node2);
                }

                Node node3 = new Node(currentNode);
                actualPath.insertFirst(node3);

                currentNodeName = currentNode.startNode;

            }
        }

        public void greedyAlgorithm(LinkedList linkedList, String startNode, String goalNode)
        {
            Node currentNode;
            String currentNodeName;
            int? minimumCost;
            int smallestIndex;
            String[] tempList = new String[30];
            Boolean isExist = false;
            int doneList = 0;

            currentNodeName = startNode;

            while (!String.Equals(currentNodeName,goalNode) )
            {
                smallestIndex = 0;
                minimumCost = null;
                Node node;

                for (int i = 0; i < linkedList.getCount(); i++)
                {
                    currentNode = linkedList.getNode(i + 1);

                    if ((String.Equals(currentNode.startNode, currentNodeName)) || (String.Equals(currentNode.endNode, currentNodeName)))
                    {
                        String tempString;
                        isExist = false;

                        if ((String.Equals(currentNode.startNode, currentNodeName)))
                        {
                            currentNode.heuristicCost = countHeuristicCost(currentNode.endNode, goalNode);
                            tempString = currentNode.endNode;
                        }
                        else
                        {
                            currentNode.heuristicCost = countHeuristicCost(currentNode.startNode, goalNode);
                            tempString = currentNode.startNode;
                        }

                        for (int j = 0; j < tempList.Length; j++)
                        {
                            if (tempString == tempList[j])
                                isExist = true;
                        }

                        if (isExist == false)
                        {
                            if (minimumCost == null)
                            {
                                minimumCost = currentNode.heuristicCost;
                                smallestIndex = i;
                            }

                            if ((currentNode.heuristicCost < minimumCost) && minimumCost != null)
                            {
                                minimumCost = currentNode.heuristicCost;
                                smallestIndex = i;
                            }
                        }
                    }   
                }

                tempList[doneList] = currentNodeName;
                doneList++;

                currentNode = linkedList.getNode(smallestIndex + 1);
                node = new Node(currentNode);
                actualPath.insertLast(node);

                if ((String.Equals(linkedList.getNode(smallestIndex + 1).startNode, currentNodeName)))
                     currentNodeName = linkedList.getNode(smallestIndex + 1).endNode;
                else
                     currentNodeName = linkedList.getNode(smallestIndex + 1).startNode;
            }

        }

        public List<KeyValuePair<int, ArrayList>> djikstraAlgorithm(LinkedList linkedList, String startNode, string goalNode)
        {
            Node currentNode;
            String currentNodeName;
            int? minimumCost;
            int smallestIndex;

            currentNodeName = startNode;
            currentNode = new Node();

            int tempInt = 0;
            int currentCost = 0;
            var list = new List<KeyValuePair<String, int[]>>();
            int[] previousList = new int[20];
            for (int i = 0; i < 20; i++)
                previousList[i] = -1; // -1 is infinity

            int[] initialList = new int[20];
            for (int i = 0; i < 20; i++)
                initialList[i] = -1; // -1 is infinity
            list.Add(new KeyValuePair<String, int[]>(currentNodeName, initialList)); //Tambah saat semua masi infinity

            while (!String.Equals(currentNodeName, goalNode))
            {
                int[] currentList = new int[20];
                for (int i = 0; i < 20; i++) 
                    currentList[i] = previousList[i]; //Initial current cost table

                currentList[getInt(currentNodeName)] = -2; //Uda di visit dikasi strip 

                for (int i = 0; i < linkedList.getCount(); i++) //Cek semua connected node
                {
                    currentNode = linkedList.getNode(i + 1);

                    if ((String.Equals(currentNode.startNode, currentNodeName)) || (String.Equals(currentNode.endNode, currentNodeName))) //Cek berhubungan ga
                    {
                        if (String.Equals(currentNode.endNode, currentNodeName)) //Cek arah node bener ga
                        {
                             String tempName;
                             tempName = currentNode.startNode;
                             currentNode.startNode = currentNode.endNode;
                             currentNode.endNode = tempName;
                        }

                        if (currentList[getInt(currentNode.endNode)] != -2)
                        {
                            tempInt = getInt(currentNode.endNode);

                            if (currentList[tempInt] == -1)
                                currentList[tempInt] = currentCost + currentNode.actualCost; //Simpan cost kalo dia infinity

                            if (currentList[tempInt] > (currentCost + currentNode.actualCost))
                                currentList[tempInt] = currentCost + currentNode.actualCost; //Simpan cost di cost table

                        }

                        
                    }
                }

                for (int i = 0; i < 20; i++) //Initiate the smallest index
                {
                    if (currentList[i] != -1)
                        if (currentList[i] != -2)
                            tempInt = i;
                }

                smallestIndex = tempInt;
                minimumCost = currentList[tempInt];

                for (int i = 0; i < 20; i ++) //Cari element terkecil
                {
                    if (currentList[i] != -1)
                        if (currentList[i] != -2) // or / and ? kalo bukan infinity dan bukan - 
                           if (currentList[i] < minimumCost)
                           {
                               smallestIndex = i;
                               minimumCost = currentList[i];
                           }
                }

                currentCost = currentList[smallestIndex];

                list.Add(new KeyValuePair<String,int[]>(currentNodeName, currentList));
                Array.Copy(currentList, previousList, 20);

                currentNodeName = getString(smallestIndex);

            }

            currentNodeName = goalNode; //Initiate goal node
            Boolean isChange = false;
            int index = list.Count - 1;
            int temp;
            int cost;
            int totalCost = list[index].Value[getInt(currentNodeName)];
            var result = new List<KeyValuePair<int, ArrayList>>();
            ArrayList path = new ArrayList();
            path.Add(currentNodeName); //Add the goal node

            while (!String.Equals(currentNodeName, startNode)) //Algoritma Backtrack
            {
                temp = getInt(currentNodeName);
                cost = list[index].Value[temp];

                while ((!isChange) && (index > 0))
                {
                    index--;
                    if (list[index].Value[temp] != cost)
                    {
                        isChange = true;
                        currentNodeName = list[index+1].Key;
                    }

                }
                isChange = false;
                path.Add(currentNodeName);
            }

            result.Add(new KeyValuePair<int, ArrayList>(totalCost, path));
            return result;
        }

        public static int countHeuristicCost(String currentNode, String goalNode)
        {
            int heuristic;
            int vertice1;
            int vertice2;
            int[] coordinateCurrentNode;
            int[] coordinateGoalNode;

            coordinateCurrentNode = getCoordinate(currentNode);
            coordinateGoalNode = getCoordinate(goalNode);

            vertice1 = coordinateGoalNode[0] - coordinateCurrentNode[0];
            vertice2 = coordinateGoalNode[1] - coordinateCurrentNode[1];

            heuristic = (int) ( (Math.Sqrt( (Math.Pow(vertice1,2) + Math.Pow(vertice2,2) ) ) ) * 1.885);
            return heuristic;        
        }

        public static int[] getCoordinate(String name)
        {
            int[] coordinate = new int[2];

            switch (name)
            {
                case "B":
                    coordinate[0] = 3;
                    coordinate[1] = 51;
                    break;
                case "U":
                    coordinate[0] = 10;
                    coordinate[1] = 49;
                    break;
                case "R":
                    coordinate[0] = 8;
                    coordinate[1] = 44;
                    break;
                case "I":
                    coordinate[0] = 23;
                    coordinate[1] = 50;
                    break;
                case "H":
                    coordinate[0] = 40;
                    coordinate[1] = 50;
                    break;
                case "P":
                    coordinate[0] = 84;
                    coordinate[1] = 43;
                    break;
                case "D":
                    coordinate[0] = 98;
                    coordinate[1] = 49;
                    break;
                case "N":
                    coordinate[0] = 141;
                    coordinate[1] = 61;
                    break;
                case "L":
                    coordinate[0] = 115;
                    coordinate[1] = 40;
                    break;
                case "S":
                    coordinate[0] = 121;
                    coordinate[1] = 16;
                    break;
                case "O":
                    coordinate[0] = 90;
                    coordinate[1] = 24;
                    break;
                case "A":
                    coordinate[0] = 95;
                    coordinate[1] = 11;
                    break;
                case "G":
                    coordinate[0] = 72;
                    coordinate[1] = 13;
                    break;
                case "T":
                    coordinate[0] = 68;
                    coordinate[1] = 21;
                    break;
                case "V":
                    coordinate[0] = 54;
                    coordinate[1] = 19;
                    break;
                case "J":
                    coordinate[0] = 22;
                    coordinate[1] = 18;
                    break;
                case "M":
                    coordinate[0] = 14;
                    coordinate[1] = 15;
                    break;
                case "C":
                    coordinate[0] = 0;
                    coordinate[1] = 0;
                    break;
                case "F":
                    coordinate[0] = 14;
                    coordinate[1] = 4;
                    break;
                case "E":
                    coordinate[0] = 40;
                    coordinate[1] = 1;
                    break;
            }

            return coordinate;
        }

        public static int getInt(String name)
        {
            int num = 0;

            switch (name)
            {
                case "A": num = 0; break;
                case "B": num = 1; break;
                case "C": num = 2; break;
                case "D": num = 3; break;
                case "E": num = 4; break;
                case "F": num = 5; break;
                case "G": num = 6; break;
                case "H": num = 7; break;
                case "I": num = 8; break;
                case "J": num = 9; break;
                case "L": num = 10; break;
                case "M": num = 11; break;
                case "N": num = 12; break;
                case "O": num = 13; break;
                case "P": num = 14; break;
                case "R": num = 15; break;
                case "S": num = 16; break;
                case "T": num = 17; break;
                case "U": num = 18; break;
                case "V": num = 19; break;
            }

            return num;
        }

        public static String getString(int num)
        {
            String node = "";

            switch (num)
            {
                case 0: node = "A"; break;
                case 1: node = "B"; break;
                case 2: node = "C"; break;
                case 3: node = "D"; break;
                case 4: node = "E"; break;
                case 5: node = "F"; break;
                case 6: node = "G"; break;
                case 7: node = "H"; break;
                case 8: node = "I"; break;
                case 9: node = "J"; break;
                case 10: node = "L"; break;
                case 11: node = "M"; break;
                case 12: node = "N"; break;
                case 13: node = "O"; break;
                case 14: node = "P"; break;
                case 15: node = "R"; break;
                case 16: node = "S"; break;
                case 17: node = "T"; break;
                case 18: node = "U"; break;
                case 19: node = "V"; break;
            }

            return node;
        }

        public static char getChar(String city)
        {
            char node = 'Z';

            switch(city)
            {
                case "Boyolali" : node = 'A'; break;
                case "Brebes" : node = 'B'; break;
                case "Cilacap" : node = 'C'; break;
                case "Demak" : node = 'D'; break;
                case "Kebumen" : node = 'E'; break;
                case "Kroya" : node = 'F'; break;
                case "Magelang" : node = 'G'; break;
                case "Pekalongan" : node = 'H'; break;
                case "Pemalang" : node = 'I'; break;
                case "Purbalingga" : node = 'J'; break;
                case "Purwodadi" : node = 'L'; break;
                case "Purwokerto" : node = 'M'; break;
                case "Rembang" : node = 'N'; break;
                case "Salatiga": node = 'O'; break;
                case "Semarang" : node = 'P'; break;
                case "Slawi" : node = 'R'; break;
                case "Sragen" : node = 'S'; break;
                case "Temanggung" : node = 'T'; break;
                case "Tegal" : node = 'U'; break;
                case "Wonosobo" : node = 'V'; break;
            }

            return node;
        }

        public static String getCity(char node)
        {
            String city = "";

            switch (node)
            {
                case 'A': city = "Boyolali"; break;
                case 'B': city = "Brebes"; break;
                case 'C': city = "Cilacap"; break;
                case 'D': city = "Demak"; break;
                case 'E': city = "Kebumen"; break;
                case 'F': city = "Kroya"; break;
                case 'G': city = "Magelang"; break;
                case 'H': city = "Pekalongan"; break;
                case 'I': city = "Pemalang"; break;
                case 'J': city = "Purbalingga"; break;
                case 'L': city = "Purwodadi"; break;
                case 'M': city = "Purwokerto"; break;
                case 'N': city = "Rembang"; break;
                case 'O': city = "Salatiga"; break;
                case 'P': city = "Semarang"; break;
                case 'R': city = "Slawi"; break;
                case 'S': city = "Sragen"; break;
                case 'T': city = "Temanggung"; break;
                case 'U': city = "Tegal"; break;
                case 'V': city = "Wonosobo"; break;
            }

            return city;
        }
    }
}