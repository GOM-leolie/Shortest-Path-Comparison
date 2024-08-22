using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using ShortestPathComparison.Classes;

namespace ShortestPathComparison.Forms
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "NONE";
            label8.Text = "NONE";
            label9.Text = "NONE";
            label10.Text = "NONE";


            for (char i = 'A'; i < 'W'; i++)
            {
                if ((i != 'K') && (i != 'Q'))
                {
                    comboBox1.Items.Add(Algorithm.getCity(i));
                    comboBox2.Items.Add(Algorithm.getCity(i));
                }
            }

            button3.Enabled = false;
            button2.Enabled = false;

            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            pictureBox2.Visible = false;

        }

        private void pictureBox1_Paint(Object sender, System.Windows.Forms.PaintEventArgs e) //default
        {
            System.Drawing.SolidBrush color;
            System.Drawing.Pen myPen;
            System.Drawing.Graphics graphic = e.Graphics;
            LinkedList linkedList;
            InitComponent init;

            init = new InitComponent();
            linkedList = init.linkedList;
            color = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            float[] dashValue = { 5, 2, 5, 2 };
            myPen.DashPattern = dashValue;

            for (int i = 0; i < linkedList.getCount(); i++)
            {
                Node node;
                int[] coordinate1;
                int[] coordinate2;
                Boolean line = false;

                node = linkedList.getNode(i + 1);
                coordinate1 = Algorithm.getCoordinate(node.startNode);
                coordinate2 = Algorithm.getCoordinate(node.endNode);

                graphic.DrawLine(myPen, (int)(30.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(658.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(30.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(658.0 - ((float)coordinate2[1] / 61.0) * 568.0));
                
                if (node.startNode.Equals("B") && node.endNode.Equals("U"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 25 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((640.0 - (coordinate1[1] / 61.0 * 568.0)) + (640.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("B") && node.endNode.Equals("R"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 10 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((655.0 - (coordinate1[1] / 61.0 * 568.0)) + (655.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("R") && node.endNode.Equals("U"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((655.0 - (coordinate1[1] / 61.0 * 568.0)) + (655.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("U") && node.endNode.Equals("I"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("I") && node.endNode.Equals("H"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((640.0 - (coordinate1[1] / 61.0 * 568.0)) + (640.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("P") && node.endNode.Equals("D"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((660.0 - (coordinate1[1] / 61.0 * 568.0)) + (660.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("D") && node.endNode.Equals("N"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((624.0 - (coordinate1[1] / 61.0 * 568.0)) + (624.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("R"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("C"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 2 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((650.0 - (coordinate1[1] / 61.0 * 568.0)) + (650.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("F"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("C") && node.endNode.Equals("F"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("F") && node.endNode.Equals("E"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 10 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("J") && node.endNode.Equals("M"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("J"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("T"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((630.0 - (coordinate1[1] / 61.0 * 568.0)) + (630.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("G"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("E") && node.endNode.Equals("G"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("G") && node.endNode.Equals("A"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("O") && node.endNode.Equals("T"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((630.0 - (coordinate1[1] / 61.0 * 568.0)) + (630.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("S") && node.endNode.Equals("A"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 45 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((643.0 - (coordinate1[1] / 61.0 * 568.0)) + (643.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
            }

            for (char i = 'A'; i < 'W'; i++)
            {
                int[] coordinate;

                coordinate = Algorithm.getCoordinate(i.ToString());

                if ((i != 'K') && (i != 'Q'))
                {
                    graphic.FillEllipse(color, new Rectangle((int)(20.0 + ((float)coordinate[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate[1] / 61.0) * 568.0), 23, 23));
                    graphic.DrawString(i.ToString(), new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate[1] / 61.0) * 568.0));
                }
            }
        }

        private void pictureBox2_Paint(Object sender, System.Windows.Forms.PaintEventArgs e)
        {
            drawDefault(e);

            //INIT
            LinkedList linkedList = new LinkedList();
            LinkedList actualPath1 = new LinkedList();
            LinkedList actualPath2 = new LinkedList();
            InitComponent init = new InitComponent();
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts1;
            TimeSpan ts2;
            TimeSpan ts3;
            string[] done1;
            string[] done2;
            string[] done3;

            linkedList = init.linkedList;
            //END

            stopWatch.Reset();

            //ASTAR
            stopWatch.Start();

            Algorithm algorithm1 = new Algorithm();
            int actualCost1 = 0;

            algorithm1.astarAlgorithm(linkedList, Algorithm.getChar(comboBox1.SelectedItem.ToString()).ToString(), Algorithm.getChar(comboBox2.SelectedItem.ToString()).ToString());
            actualPath1 = algorithm1.actualPath;

            done1 = new string[actualPath1.getCount() + 1];
            done1[0] = actualPath1.getNode(1).startNode;

            for (int i = 0; i < actualPath1.getCount(); i++)
            {
                int[] coordinate1;
                int[] coordinate2;
                Boolean line = false;

                Node node = actualPath1.getNode(i + 1);
                coordinate1 = Algorithm.getCoordinate(node.startNode);
                coordinate2 = Algorithm.getCoordinate(node.endNode);

                System.Drawing.Pen color = new Pen(System.Drawing.Color.Blue,2);
                System.Drawing.Graphics graphic = e.Graphics;
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                if (!node.startNode.Equals("C") || !node.endNode.Equals("M"))
                    if (!node.startNode.Equals("M") || !node.endNode.Equals("J"))
                        if (!node.startNode.Equals("U") || !node.endNode.Equals("I"))
                            if (!node.startNode.Equals("R") || !node.endNode.Equals("U"))
                                if (!node.startNode.Equals("J") || !node.endNode.Equals("V"))
                                    if (!node.startNode.Equals("V") || !node.endNode.Equals("T"))
                                        if (!node.startNode.Equals("E") || !node.endNode.Equals("G"))
                                            if (!node.startNode.Equals("A") || !node.endNode.Equals("S"))
                                                if (!node.startNode.Equals("L") || !node.endNode.Equals("N"))
                                                    if (!node.startNode.Equals("D") || !node.endNode.Equals("N"))
                                                        if (!node.startNode.Equals("P") || !node.endNode.Equals("D"))

                                                    if (!node.startNode.Equals("M") || !node.endNode.Equals("C"))
                                                        if (!node.startNode.Equals("J") || !node.endNode.Equals("M"))
                                                            if (!node.startNode.Equals("I") || !node.endNode.Equals("U"))
                                                                if (!node.startNode.Equals("U") || !node.endNode.Equals("R"))
                                                                    if (!node.startNode.Equals("V") || !node.endNode.Equals("J"))
                                                                        if (!node.startNode.Equals("T") || !node.endNode.Equals("V"))
                                                                            if (!node.startNode.Equals("G") || !node.endNode.Equals("E"))
                                                                                if (!node.startNode.Equals("S") || !node.endNode.Equals("A"))
                                                                                    if (!node.startNode.Equals("N") || !node.endNode.Equals("L"))
                                                                                        if (!node.startNode.Equals("N") || !node.endNode.Equals("D"))
                                                                                            if (!node.startNode.Equals("D") || !node.endNode.Equals("P"))
                                                                                        line = true;

                if (line)
                {
                    graphic.DrawLine(color, (int)(25.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(661.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(25.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(661.0 - ((float)coordinate2[1] / 61.0) * 568.0));
                }
                else
                {
                    graphic.DrawLine(color, (int)(25.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(655.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(25.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(655.0 - ((float)coordinate2[1] / 61.0) * 568.0));
                }

                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate1[1] / 61.0) * 568.0), 23, 23));
                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate2[1] / 61.0) * 568.0), 23, 23));
                graphic.DrawString(node.startNode, new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate1[1] / 61.0) * 568.0));
                graphic.DrawString(node.endNode, new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate2[1] / 61.0) * 568.0));

                actualCost1 = actualCost1 + node.actualCost;
                done1[i + 1] = node.endNode;
            }

            stopWatch.Stop();
            ts1 = stopWatch.Elapsed;
            label8.Text = actualCost1.ToString();
            //END

            stopWatch.Reset();

            //GREEDY
            stopWatch.Start();

            Algorithm algorithm2 = new Algorithm();
            int actualCost2 = 0;

            algorithm2.greedyAlgorithm(linkedList, Algorithm.getChar(comboBox1.SelectedItem.ToString()).ToString(), Algorithm.getChar(comboBox2.SelectedItem.ToString()).ToString());
            actualPath2 = algorithm2.actualPath;

            String name = comboBox1.SelectedItem.ToString();

            done2 = new string[actualPath2.getCount() + 1];
            done2[0] = name;

            for (int i = 0; i < actualPath2.getCount(); i++)
            {
                int[] coordinate1;
                int[] coordinate2;
                Boolean line = false;

                Node node = actualPath2.getNode(i + 1);
                coordinate1 = Algorithm.getCoordinate(node.startNode);
                coordinate2 = Algorithm.getCoordinate(node.endNode);

                System.Drawing.Pen color = new Pen(System.Drawing.Color.Red,2);
                System.Drawing.Graphics graphic = e.Graphics;
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                if (!node.startNode.Equals("C") || !node.endNode.Equals("M"))
                    if (!node.startNode.Equals("M") || !node.endNode.Equals("J"))
                        if (!node.startNode.Equals("U") || !node.endNode.Equals("I"))
                            if (!node.startNode.Equals("R") || !node.endNode.Equals("U"))
                                if (!node.startNode.Equals("J") || !node.endNode.Equals("V"))
                                    if (!node.startNode.Equals("V") || !node.endNode.Equals("T"))
                                        if (!node.startNode.Equals("E") || !node.endNode.Equals("G"))
                                            if (!node.startNode.Equals("A") || !node.endNode.Equals("S"))
                                                if (!node.startNode.Equals("L") || !node.endNode.Equals("N"))
                                                    if (!node.startNode.Equals("D") || !node.endNode.Equals("N"))
                                                        if (!node.startNode.Equals("P") || !node.endNode.Equals("D"))

                                                            if (!node.startNode.Equals("M") || !node.endNode.Equals("C"))
                                                                if (!node.startNode.Equals("J") || !node.endNode.Equals("M"))
                                                                    if (!node.startNode.Equals("I") || !node.endNode.Equals("U"))
                                                                        if (!node.startNode.Equals("U") || !node.endNode.Equals("R"))
                                                                            if (!node.startNode.Equals("V") || !node.endNode.Equals("J"))
                                                                                if (!node.startNode.Equals("T") || !node.endNode.Equals("V"))
                                                                                    if (!node.startNode.Equals("G") || !node.endNode.Equals("E"))
                                                                                        if (!node.startNode.Equals("S") || !node.endNode.Equals("A"))
                                                                                            if (!node.startNode.Equals("N") || !node.endNode.Equals("L"))
                                                                                                if (!node.startNode.Equals("N") || !node.endNode.Equals("D"))
                                                                                                    if (!node.startNode.Equals("D") || !node.endNode.Equals("P"))
                                                                                                        line = true;

                if (line)
                {
                    graphic.DrawLine(color, (int)(35.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(655.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(35.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(655.0 - ((float)coordinate2[1] / 61.0) * 568.0));
                }
                else
                {
                    graphic.DrawLine(color, (int)(35.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(661.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(35.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(661.0 - ((float)coordinate2[1] / 61.0) * 568.0));
                }
                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate1[1] / 61.0) * 568.0), 23, 23));
                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate2[1] / 61.0) * 568.0), 23, 23));
                graphic.DrawString(node.startNode, new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate1[1] / 61.0) * 568.0));
                graphic.DrawString(node.endNode, new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate2[1] / 61.0) * 568.0));

                if (String.Equals(node.startNode, name))
                {
                    name = node.endNode;
                    done2[i + 1] = name;
                }
                else
                {
                    name = node.startNode;
                    done2[i + 1] = name;
                }

                actualCost2 += node.actualCost;
            }

            stopWatch.Stop();
            ts2 = stopWatch.Elapsed;
            label3.Text = actualCost2.ToString();
            //END

            stopWatch.Reset();
            
            /*
            //DJIKSTRA
            stopWatch.Start();

            Algorithm algorithm3 = new Algorithm();

            var actualPath3 = algorithm3.djikstraAlgorithm(linkedList, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());

            for (int i = 0; i < actualPath3[0].Value.Count - 1; i++)
            {
                //NOT IMPORTANT
                int[] coordinate1;
                int[] coordinate2;
                Boolean line = false;

                coordinate1 = Algorithm.getCoordinate(actualPath3[0].Value[i].ToString());
                coordinate2 = Algorithm.getCoordinate(actualPath3[0].Value[i+1].ToString());

                System.Drawing.Pen color = new Pen(System.Drawing.Color.Purple, 2);
                System.Drawing.Graphics graphic = e.Graphics;
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

                graphic.DrawLine(color, (int)(30.0 + ((float)coordinate1[0] / 31.0) * 642.0), (int)(658.0 - ((float)coordinate1[1] / 22.0) * 568.0), (int)(30.0 + ((float)coordinate2[0] / 31.0) * 642.0), (int)(658.0 - ((float)coordinate2[1] / 22.0) * 568.0));

                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate1[0] / 31.0) * 642.0), (int)(648.0 - ((float)coordinate1[1] / 22.0) * 568.0), 23, 23));
                graphic.FillEllipse(brush, new Rectangle((int)(20.0 + ((float)coordinate2[0] / 31.0) * 642.0), (int)(648.0 - ((float)coordinate2[1] / 22.0) * 568.0), 23, 23));
                graphic.DrawString(actualPath3[0].Value[i].ToString(), new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate1[0] / 31.0) * 642.0), (int)(650.0 - ((float)coordinate1[1] / 22.0) * 568.0));
                graphic.DrawString(actualPath3[0].Value[i + 1].ToString(), new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate2[0] / 31.0) * 642.0), (int)(650.0 - ((float)coordinate2[1] / 22.0) * 568.0));

                //END
            }

            stopWatch.Stop();
            ts3 = stopWatch.Elapsed;
            label13.Text = actualPath3[0].Key.ToString();

            //END
             */

            //SETTING TIME
            label9.Text = ts2.TotalMilliseconds.ToString() + " ms";
            label10.Text = ts1.TotalMilliseconds.ToString() + " ms";
            //label12.Text = ts3.TotalMilliseconds.ToString() + " ms";
            //END

            //Counting Heuristic
            /*
            ArrayList doneList = new ArrayList();
            for (int i = 0; i < done1.Length; i++)
                doneList.Add(done1[i]);

            Boolean isExist;
            String heuristicCost = ""; 
            int tempCost = 0;

            for (int i = 0; i < done2.Length; i++)
            {
                isExist = false;

                for (int j = 0; j < doneList.Count; j++)
                {
                    if (done2[i].Equals(doneList[j]))
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                    doneList.Add(done2[i]);
            } */

            String heuristicCost = "";
            int tempCost = 0;

            for (char i = 'A'; i < 'L'; i++)
            {
                if ((i != 'K') && (i != 'Q'))
                {
                    tempCost = Algorithm.countHeuristicCost(i.ToString(), Algorithm.getChar(comboBox2.SelectedItem.ToString()).ToString());
                    heuristicCost = heuristicCost + i.ToString() + " = " + tempCost + "\n";
                }

            }

            label25.Text = heuristicCost;

            heuristicCost = "";
            tempCost = 0;

            for (char i = 'L'; i < 'W'; i++)
            {
                if ((i != 'K') && (i != 'Q'))
                {
                    tempCost = Algorithm.countHeuristicCost(i.ToString(), Algorithm.getChar(comboBox2.SelectedItem.ToString()).ToString());
                    heuristicCost = heuristicCost + i.ToString() + " = " + tempCost + "\n";
                }

            }

            label64.Text = heuristicCost;
            //END

            //START AND END
            int[] startCoor;
            int[] endCoor;
            System.Drawing.Pen start = new Pen(System.Drawing.Color.Yellow,3);
            System.Drawing.Pen end = new Pen(System.Drawing.Color.Green,3);
            System.Drawing.Graphics graph = e.Graphics;

            startCoor = Algorithm.getCoordinate(Algorithm.getChar(comboBox1.SelectedItem.ToString()).ToString());
            endCoor = Algorithm.getCoordinate(Algorithm.getChar(comboBox2.SelectedItem.ToString()).ToString());

            graph.DrawEllipse(start, new Rectangle((int)(20.0 + ((float)startCoor[0] / 141.0) * 642.0), (int)(648.0 - ((float)startCoor[1] / 61.0) * 568.0), 22, 22));
            graph.DrawEllipse(end, new Rectangle((int)(20.0 + ((float)endCoor[0] / 141.0) * 642.0), (int)(648.0 - ((float)endCoor[1] / 61.0) * 568.0), 22, 22));

            //END
        }

        private void drawDefault(PaintEventArgs e)
        {
            System.Drawing.SolidBrush color;
            System.Drawing.Pen myPen;
            System.Drawing.Graphics graphic = e.Graphics;
            LinkedList linkedList;
            InitComponent init;

            init = new InitComponent();
            linkedList = init.linkedList;            
            color = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            float[] dashValue = { 5, 2, 5, 2 };
            myPen.DashPattern = dashValue;

            for (int i = 0; i < linkedList.getCount(); i++)
            {
                Node node;
                int[] coordinate1;
                int[] coordinate2;
                Boolean line = false;

                node = linkedList.getNode(i + 1);
                coordinate1 = Algorithm.getCoordinate(node.startNode);
                coordinate2 = Algorithm.getCoordinate(node.endNode);

                graphic.DrawLine(myPen, (int)(30.0 + ((float)coordinate1[0] / 141.0) * 642.0), (int)(658.0 - ((float)coordinate1[1] / 61.0) * 568.0), (int)(30.0 + ((float)coordinate2[0] / 141.0) * 642.0), (int)(658.0 - ((float)coordinate2[1] / 61.0) * 568.0));

                if (node.startNode.Equals("B") && node.endNode.Equals("U"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 25 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((640.0 - (coordinate1[1] / 61.0 * 568.0)) + (640.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("B") && node.endNode.Equals("R"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 10 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((655.0 - (coordinate1[1] / 61.0 * 568.0)) + (655.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("R") && node.endNode.Equals("U"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((655.0 - (coordinate1[1] / 61.0 * 568.0)) + (655.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("U") && node.endNode.Equals("I"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("I") && node.endNode.Equals("H"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((640.0 - (coordinate1[1] / 61.0 * 568.0)) + (640.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("P") && node.endNode.Equals("D"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((660.0 - (coordinate1[1] / 61.0 * 568.0)) + (660.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("D") && node.endNode.Equals("N"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 38 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((624.0 - (coordinate1[1] / 61.0 * 568.0)) + (624.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("R"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("C"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 2 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((650.0 - (coordinate1[1] / 61.0 * 568.0)) + (650.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("M") && node.endNode.Equals("F"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("C") && node.endNode.Equals("F"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("F") && node.endNode.Equals("E"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 10 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("J") && node.endNode.Equals("M"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("J"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((635.0 - (coordinate1[1] / 61.0 * 568.0)) + (635.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("T"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((630.0 - (coordinate1[1] / 61.0 * 568.0)) + (630.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("V") && node.endNode.Equals("G"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("E") && node.endNode.Equals("G"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("G") && node.endNode.Equals("A"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 20 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("O") && node.endNode.Equals("T"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 15 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((630.0 - (coordinate1[1] / 61.0 * 568.0)) + (630.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else if (node.startNode.Equals("S") && node.endNode.Equals("A"))
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 40 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((665.0 - (coordinate1[1] / 61.0 * 568.0)) + (665.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
                else
                    graphic.DrawString(node.actualCost.ToString(), new Font("Arial", 8), SystemBrushes.WindowText, 45 + (int)((coordinate1[0] / 141.0 * 642.0) + (coordinate2[0] / 141.0 * 642.0)) / 2, (int)((643.0 - (coordinate1[1] / 61.0 * 568.0)) + (643.0 - (coordinate2[1] / 61.0 * 568.0))) / 2);
            }

            for (char i = 'A'; i < 'W'; i++)
            {
                int[] coordinate;
               
                coordinate = Algorithm.getCoordinate(i.ToString());

                if ((i != 'K') && (i != 'Q'))
                {
                    graphic.FillEllipse(color, new Rectangle((int)(20.0 + ((float)coordinate[0] / 141.0) * 642.0), (int)(648.0 - ((float)coordinate[1] / 61.0) * 568.0), 23, 23));
                    graphic.DrawString(i.ToString(), new Font("Arial", 12), SystemBrushes.WindowText, (int)(24.0 + ((float)coordinate[0] / 141.0) * 642.0), (int)(650.0 - ((float)coordinate[1] / 61.0) * 568.0));
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem == null)
            {
                char[] tempChar;

                tempChar = Algorithm.getChar(comboBox1.Text).ToString().ToCharArray();
                comboBox2.Items.Clear();

                for (char i = 'A'; i < 'W'; i++)
                {
                    if ((i != 'K') && (i != 'Q') && (i != tempChar[0]))
                    {
                        comboBox2.Items.Add(Algorithm.getCity(i));
                    }
                }
            }

            comboBox1.Enabled = false;
            button3.Enabled = true;

            if (comboBox2.SelectedItem != null)
                button2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                char[] tempChar;

                tempChar = Algorithm.getChar(comboBox2.Text).ToString().ToCharArray();
                comboBox1.Items.Clear();

                for (char i = 'A'; i < 'W'; i++)
                {
                    if ((i != 'K') && (i != 'Q') && (i != tempChar[0]))
                    {
                        comboBox1.Items.Add(Algorithm.getCity(i));
                    }
                }
            }

            comboBox2.Enabled = false;
            button3.Enabled = true;

            if (comboBox1.SelectedItem != null)
                button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            label3.Text = "NONE";
            label8.Text = "NONE";
            label9.Text = "NONE";
            label10.Text = "NONE";
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;

            for (char i = 'A'; i < 'W'; i++)
            {
                if ((i != 'K') && (i != 'Q'))
                {
                    comboBox1.Items.Add(Algorithm.getCity(i));
                    comboBox2.Items.Add(Algorithm.getCity(i));
                }
            }

            button3.Enabled = false;
            button2.Enabled = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            label25.Text = "NONE";
            label64.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox2.Paint += new PaintEventHandler(this.pictureBox2_Paint);


        }


    }
}
