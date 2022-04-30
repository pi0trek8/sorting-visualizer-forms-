using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sorting_Visualizer_Forms
{
    public partial class Form1 : Form
    {
        int[] arrayToSort;
        Graphics pictureBoxGraphic;
        BackgroundWorker backgroundWorker = null;
        bool paused = false;
        private Drawer drawer;
        private ISortEngine sortEngine;

        public Form1()
        {
            InitializeComponent();
            populateDropdown();
        }

        private void populateDropdown()
        {
            //gets list of names of classes that implement the ISortEngine interface
            //(excluding any abstract classes and intarface itself).
            List<string> ClassList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISortEngine).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.Name).ToList();
            ClassList.Sort();
            foreach(string nameOfAlgorith in ClassList){
                comboBox1.Items.Add(nameOfAlgorith);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pictureBoxGraphic = pictureBox.CreateGraphics();
            int pictureBoxWidth = pictureBox.Width;
            int pictureBoxHeight = pictureBox.Height;

            pictureBoxGraphic.FillRectangle(new SolidBrush(Color.Black), 0, 0, pictureBoxWidth, pictureBoxHeight);

            RandomArray randomArray = new RandomArray();
            arrayToSort = randomArray.createRandomArray(pictureBoxWidth, pictureBoxHeight);

            Console.WriteLine(pictureBoxWidth);

            Drawer drawer = new Drawer(pictureBoxGraphic);
            drawer.drawBars(arrayToSort, pictureBoxHeight);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (arrayToSort.Length == 0) btnReset_Click(null, null);

            string sortEngineName = (string)comboBox1.SelectedItem;

            switch(sortEngineName){
                case "BubbleSort":
                    sortEngine = new BubbleSort(arrayToSort, pictureBoxGraphic, pictureBox.Height);
                    sortEngine.sort();
                    break;
                case "InsertionSort":
                    sortEngine = new InsertionSort(arrayToSort, pictureBoxGraphic, pictureBox.Height);
                    sortEngine.sort();
                    break;
                case "SelectionSort":
                    sortEngine = new SelectionSort(arrayToSort, pictureBoxGraphic, pictureBox.Height);
                    sortEngine.sort();
                    break;

            }
        }

       /* private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                backgroundWorker.CancelAsync();
                paused = true;
            }
            else
            {
                drawer = new Drawer(pictureBoxGraphic);
                drawer.reDraw(arrayToSort, pictureBox.Height);
                paused = false;
            }
            backgroundWorker.RunWorkerAsync(argument: comboBox1.SelectedItem);
        }




        #region BackGroundEngine
        public void doWork(object sender, System.ComponentModel.DoWorkEventArgs e){
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            string sortEngineName = (string)e.Argument; //extracts algorithm name
            Type type = Type.GetType("Sorting_Visualizer_Forms." + sortEngineName); //namespaceName.sortEngineName
            var constructors = type.GetConstructors();

            try{
                ISortEngine sortEngine = (ISortEngine)constructors[0].Invoke(
                    new object[]{arrayToSort, pictureBoxGraphic, pictureBox.Height});

                while(!sortEngine.checkIfSorted() && backgroundWorker.CancellationPending){
                    sortEngine.sort();
                }
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }

            
        }
        #endregion
        */
       
    }
}
