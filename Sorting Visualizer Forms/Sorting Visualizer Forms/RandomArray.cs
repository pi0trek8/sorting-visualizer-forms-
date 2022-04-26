using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class RandomArray
    {
        public int[] createRandomArray(int arraySize, int panelHeight)
        {
            int[] arrayToSort = new int[arraySize];
            Random random = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                arrayToSort[i] = random.Next(0, panelHeight);
            }
            return arrayToSort;
        }
    }
}
