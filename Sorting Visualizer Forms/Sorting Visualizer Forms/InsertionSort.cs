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

        private bool isSorted = false;
        private int[] arrayToSort;
        private Graphics panelGraphic;
        private int panelHeight;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);

        public bool checkIfSorted()
        {
            throw new NotImplementedException();
        }

        public void nextStep()
        {
            throw new NotImplementedException();
        }

        public void reDraw()
        {
            throw new NotImplementedException();
        }

        public void sort(int[] arrayToSort, Graphics  graphicPanel, int panelHeight)
        {
            int size = arrayToSort.Length;

            this.arrayToSort = arrayToSort;
            this.panelGraphic = graphicPanel;
            this.panelHeight = panelHeight;


            for (int i = 0; i<size; i++){
                int key = arrayToSort[i];
                int j = i - 1;

                while(j>=0 && key <arrayToSort[j]){
                    arrayToSort[j + 1] = arrayToSort[j];
                    j--;

                    graphicPanel.FillRectangle(blackBrush, i, 0, 1, panelHeight);
                    graphicPanel.FillRectangle(blackBrush, i + 1, 0, 1, panelHeight);

                    graphicPanel.FillRectangle(whiteBrush, i, panelHeight - arrayToSort[i], 1, panelHeight);
                    graphicPanel.FillRectangle(whiteBrush, i + 1, panelHeight - arrayToSort[i + 1], 1, panelHeight);
                }
                arrayToSort[j + 1] = key;
            }
        }
    }
}
