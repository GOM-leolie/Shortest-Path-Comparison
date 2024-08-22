using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPathComparison.Classes;

namespace ShortestPathComparison.Classes
{
    class InitComponent
    {
        public LinkedList linkedList;

        public InitComponent()
        {
            linkedList = new LinkedList();

            Node node1 = new Node("B", "R", 25, 0, 0, 0);
            Node node2 = new Node("B", "U", 14, 0, 0, 0);
            Node node3 = new Node("R", "U", 17, 0, 0, 0);
            Node node4 = new Node("U", "I", 39, 0, 0, 0);
            Node node5 = new Node("I", "H", 40, 0, 0, 0);
            Node node6 = new Node("H", "P", 98, 0, 0, 0);
            Node node7 = new Node("P", "D", 30, 0, 0, 0);
            Node node8 = new Node("D", "N", 91, 0, 0, 0);
            Node node9 = new Node("N", "L", 89, 0, 0, 0);
            Node node10 = new Node("D", "L", 40, 0, 0, 0);

            Node node11 = new Node("L", "S", 55, 0, 0, 0);
            Node node12 = new Node("S", "O", 66, 0, 0, 0);
            Node node13 = new Node("S", "A", 54, 0, 0, 0);
            Node node14 = new Node("O", "A", 29, 0, 0, 0);
            Node node15 = new Node("O", "P", 58, 0, 0, 0);
            Node node16 = new Node("O", "T", 43, 0, 0, 0);
            Node node17 = new Node("G", "A", 66, 0, 0, 0);
            Node node18 = new Node("A", "T", 22, 0, 0, 0);
            Node node19 = new Node("V", "T", 41, 0, 0, 0);
            Node node20 = new Node("V", "G", 60, 0, 0, 0);

            Node node21 = new Node("H", "T", 108, 0, 0, 0);
            Node node22 = new Node("J", "I", 67, 0, 0, 0);
            Node node23 = new Node("M", "R", 94, 0, 0, 0);
            Node node24 = new Node("V", "J", 77, 0, 0, 0);
            Node node25 = new Node("J", "M", 18, 0, 0, 0);
            Node node26 = new Node("E", "G", 85, 0, 0, 0);
            Node node27 = new Node("M", "C", 54, 0, 0, 0);
            Node node28 = new Node("C", "F", 33, 0, 0, 0);
            Node node29 = new Node("M", "F", 30, 0, 0, 0);
            Node node30 = new Node("M", "E", 71, 0, 0, 0);

            Node node31 = new Node("F", "E", 94, 0, 0, 0);

            linkedList.insertLast(node1);
            linkedList.insertLast(node2);
            linkedList.insertLast(node3);
            linkedList.insertLast(node4);
            linkedList.insertLast(node5);
            linkedList.insertLast(node6);
            linkedList.insertLast(node7);
            linkedList.insertLast(node8);
            linkedList.insertLast(node9);
            linkedList.insertLast(node10);

            linkedList.insertLast(node11);
            linkedList.insertLast(node12);
            linkedList.insertLast(node13);
            linkedList.insertLast(node14);
            linkedList.insertLast(node15);
            linkedList.insertLast(node16);
            linkedList.insertLast(node17);
            linkedList.insertLast(node18);
            linkedList.insertLast(node19);
            linkedList.insertLast(node20);

            linkedList.insertLast(node21);
            linkedList.insertLast(node22);
            linkedList.insertLast(node23);
            linkedList.insertLast(node24);
            linkedList.insertLast(node25);
            linkedList.insertLast(node26);
            linkedList.insertLast(node27);
            linkedList.insertLast(node28);
            linkedList.insertLast(node29);
            linkedList.insertLast(node30);

            linkedList.insertLast(node31);
        }
    }
}