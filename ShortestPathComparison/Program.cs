using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShortestPathComparison.Classes;
using ShortestPathComparison.Forms;

namespace ShortestPathComparison
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formMain());
            

            /*
            LinkedList linkedList = new LinkedList();
            LinkedList actualPath = new LinkedList();
            InitComponent init = new InitComponent();
            Algorithm algorithm = new Algorithm();

            linkedList = init.linkedList;

            //ASTAR
            algorithm.astarAlgorithm(linkedList, "I", "M");
            actualPath = algorithm.actualPath;
            //Console.Out.WriteLine(actualPath.getNode(1).startNode);
            for (int i = 0 ; i < actualPath.getCount() ; i++)
            {
                Node node = actualPath.getNode(i + 1);
                Console.Out.WriteLine(node.endNode);
            }
            
            
            
            
            algorithm.greedyAlgorithm(linkedList, "S", "L");
            actualPath = algorithm.actualPath;
            
            String name = "A";
            Console.Out.WriteLine(name);
            for (int i = 0; i < actualPath.getCount(); i++)
            {
                Node node;
                node = actualPath.getNode(i + 1);
                if (String.Equals(node.startNode, name))
                {
                    Console.Out.WriteLine(node.endNode);
                    name = node.endNode;
                }
                else
                {
                    Console.Out.WriteLine(node.startNode);
                    name = node.startNode;
                }
            }
             */
                     
        }
    }
}
