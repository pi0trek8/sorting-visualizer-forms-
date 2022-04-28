using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sorting_Visualizer_Forms
{
    public partial class Form1 : Form
    {
        int[] arrayToSort;
        Graphics pictureBoxGraphic;
        BackgroundWorker backgroundWorker = null;
        bool paused = false;


        public Form1()
        {
            InitializeComponent();
            populateDropdown();
        }

        private void populateDropdown()
        {
            //gets list of names of classes that implement the ISortEngine interface (excluding any abstract classes and intarface itself).
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach(string nameOfAlgorith in ClassList){
                comboBox1.Items.Add(nameOfAlgorith);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBoxGraphic = pictureBox.CreateGraphics();
            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;
            int arraySize = pictureBox.Width;
            //Console.WriteLine(panelWidth);

            pictureBoxGraphic.FillRectangle(new SolidBrush(Color.Black), 0, 0, pictureBoxWidth, pictureBoxHeight);

            RandomArray randomArray = new RandomArray();
            arrayToSort = randomArray.createRandomArray(arraySize, pictureBoxHeight);

            Console.WriteLine(arraySize);

            Drawer drawer = new Drawer(pictureBoxGraphic);
            drawer.drawBars(arrayToSort, pictureBoxHeight);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            //backgroundWorker += new DoWorkEventHandler(backgroundWorker.DoWork);
            backgroundWorker.RunWorkerAsync(argument: comboBox1.SelectedItem);

            //sortingAlgorithm.sort(arrayToSort, pictureBoxGraphic, pictureBox.Height);
        }

    }
}
