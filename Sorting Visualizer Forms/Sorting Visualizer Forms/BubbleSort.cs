using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Sorting_Visualizer_Forms
{
    class BubbleSort : ISortEngine
    {
        private bool isSorted = false;
        private int[] arrayToSort;
        private Graphics graphicPanel;
        private int panelHeight;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);

        private Drawer drawer; 

        public BubbleSort(int[] arrayToSort, Graphics graphicPanel, int panelHeight)
        {
            this.arrayToSort = arrayToSort;
            this.graphicPanel = graphicPanel;
            this.panelHeight = panelHeight;
        }

        public void sort()
        {
            while(!isSorted){
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        swapValues(i);
                    }
                }
                isSorted = checkIfSorted();
            }
        }

        public bool checkIfSorted()
        {
            for(int i=0;i<arrayToSort.Length-1;i++){
                if (arrayToSort[i] > arrayToSort[i + 1])
                    return false;
            }
            return true;
        }

        private void swapValues(int i)
        {
            drawer = new Drawer(graphicPanel);

            int temporary = arrayToSort[i];
            arrayToSort[i] = arrayToSort[i + 1];
            arrayToSort[i + 1] = temporary;

            drawer.drawBar(arrayToSort, i, panelHeight);
            drawer.drawBar(arrayToSort, i + 1, panelHeight);
        }
    }
}
