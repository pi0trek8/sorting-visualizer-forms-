using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class BubbleSort : IStartEngine
    {
        private bool isSorted = false;
        private int[] arrayToSort;
        private Graphics panelGraphic;
        private int panelHeight;
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush blackBrush = new SolidBrush(Color.Black);

        public void sort(int[] arrayToSort, Graphics graphicPanel, int panelHeight)
        {
            this.arrayToSort = arrayToSort;
            this.panelGraphic = graphicPanel;
            this.panelHeight = panelHeight;


            while (!isSorted)
            {
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if(arrayToSort[i]>arrayToSort[i+1]){
                        swapValues(i);

                        graphicPanel.FillRectangle(blackBrush, i, 0, 1, panelHeight);
                        graphicPanel.FillRectangle(blackBrush, i + 1, 0, 1, panelHeight);

                        graphicPanel.FillRectangle(whiteBrush, i, panelHeight - arrayToSort[i], 1, panelHeight);
                        graphicPanel.FillRectangle(whiteBrush, i+1, panelHeight - arrayToSort[i+1], 1, panelHeight);
                    }

                }
                isSorted = checkIfSorted();
               

            }
        }

        private bool checkIfSorted()
        {
            for(int i=0;i<arrayToSort.Length-1;i++){
                if (arrayToSort[i] > arrayToSort[i + 1])
                    return false;
            }
            return true;
        }

        private void swapValues(int i)
        {
            int temporary = arrayToSort[i];
            arrayToSort[i] = arrayToSort[i + 1];
            arrayToSort[i + 1] = temporary;
        }
    }
}
