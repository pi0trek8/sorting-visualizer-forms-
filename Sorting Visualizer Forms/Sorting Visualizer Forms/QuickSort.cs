using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class QuickSort
    {
        private int panelHeight;
        private Graphics graphicPanel;
        private Drawer drawer;

        public QuickSort(Graphics graphicPanel, int panelHeight)
        {
            this.panelHeight = panelHeight;
            this.graphicPanel = graphicPanel;
        }

        public void quickSort(int[] arrayToSort, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arrayToSort, left, right);

                if (pivot > 1)
                {
                    quickSort(arrayToSort, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arrayToSort, pivot + 1, right);
                }
            }

        }


        private int Partition(int[] arrayToSort, int left, int right)
        {
            drawer = new Drawer(graphicPanel);
            int pivot = arrayToSort[left];
            while (true)
            {

                while (arrayToSort[left] < pivot)
                {
                    left++;
                }

                while (arrayToSort[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arrayToSort[left] == arrayToSort[right]) return right;

                    int temp = arrayToSort[left];
                    arrayToSort[left] = arrayToSort[right];
                    arrayToSort[right] = temp;

                    drawer.drawBar(arrayToSort, left, panelHeight);
                    drawer.drawBar(arrayToSort, right, panelHeight);

                }
                else
                {
                    return right;
                }
            }
        }




    }
}
