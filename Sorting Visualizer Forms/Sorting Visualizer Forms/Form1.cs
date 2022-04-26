using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting_Visualizer_Forms
{
    public partial class Form1 : Form
    {
        int[] arrayToSort;
        Graphics graphicPanel;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphicPanel = pictureBox.CreateGraphics();
            int panelWidth = pictureBox.Width;
            int panelHeight = pictureBox.Height;
            int arraySize = pictureBox.Width;
            //Console.WriteLine(panelWidth);

            //graphicPanel.FillRectangle(new SolidBrush(Color.Black), 0, 0, panelWidth, panelHeight);

            RandomArray randomArray = new RandomArray();
            arrayToSort = randomArray.createRandomArray(arraySize, panelHeight);

            //Console.WriteLine(arrayToSort.Length);

            Drawer drawer = new Drawer(graphicPanel);
            drawer.drawBars(arrayToSort, panelHeight);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IStartEngine sortingAlgorithm = new BubbleSort();
            Console.WriteLine(arrayToSort.Length);

            sortingAlgorithm.sort(arrayToSort, graphicPanel, pictureBox.Height);
        }

    }
}
