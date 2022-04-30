using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class SelectionSort : ISortEngine
    {
        private int[] arrayToSort;
        private Graphics graphicPanel;
        private int panelHeight;

        private Drawer drawer;

        public SelectionSort(int[] arrayToSort, Graphics graphicPanel, int panelHeight)
        {
            this.arrayToSort = arrayToSort;
            this.graphicPanel = graphicPanel;
            this.panelHeight = panelHeight;
        }

        public void sort()
        {
            int arraySize = arrayToSort.Length;

            for(int step = 0; step < arraySize - 1; step++ ){
                int indexOfMinumumValue = step;

                for (int j = step; j < arraySize; j++){
                    if(arrayToSort[j] < arrayToSort [indexOfMinumumValue]){
                        indexOfMinumumValue = j;
                    }
    
                }
                swap(step, indexOfMinumumValue);
            }

        }


        private void swap(int position, int indexOfMinumumValue)
        {
            drawer = new Drawer(graphicPanel);

            int temporary = arrayToSort[position];
            arrayToSort[position] = arrayToSort[indexOfMinumumValue];
            arrayToSort[indexOfMinumumValue] = temporary;

            drawer.drawBar(arrayToSort, position, panelHeight);
            drawer.drawBar(arrayToSort, indexOfMinumumValue, panelHeight);

        }

    }
}
