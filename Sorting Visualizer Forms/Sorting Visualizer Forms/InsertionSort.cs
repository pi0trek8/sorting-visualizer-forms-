using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class InsertionSort : ISortEngine
    {

        private int[] arrayToSort;
        private Graphics graphicPanel;
        private int panelHeight;

        private Drawer drawer; 
   

        public InsertionSort(int[] arrayToSort, Graphics graphicPanel, int panelHeight)
        {
            this.arrayToSort = arrayToSort;
            this.graphicPanel = graphicPanel;
            this.panelHeight = panelHeight;
        }

       

       

        public void sort()
        {
            int size = arrayToSort.Length;
            drawer = new Drawer(graphicPanel);

            for (int i = 0; i<size; i++){
                int key = arrayToSort[i];
                int j = i - 1;

                while(j>=0 && key <arrayToSort[j]){
                    arrayToSort[j + 1] = arrayToSort[j];
                    --j;
                    drawer.drawBar(arrayToSort, j, panelHeight);
                    drawer.drawBar(arrayToSort, j - 1, panelHeight);
                }
                arrayToSort[j + 1] = key;

                
            }
        }

    }
}
