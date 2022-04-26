using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Visualizer_Forms
{
    class Drawer
    {
        private Graphics graphicPanel;

        public Drawer(Graphics graphicPanel)
        {
            this.graphicPanel = graphicPanel;
        }

        public void drawBars(int[] arrayToSort, int panelHeight)
        {
            for (int i=0; i<arrayToSort.Length; i++)
            {
                graphicPanel.FillRectangle(new SolidBrush(Color.White), i, panelHeight - arrayToSort[i], 1, panelHeight);
            }
        }
    }
}
