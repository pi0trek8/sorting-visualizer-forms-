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


        public void reDraw(int[] arrayToSort, int panelHeight){

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                graphicPanel.FillRectangle(new SolidBrush(Color.Black), i, 0, 1, panelHeight);
                graphicPanel.FillRectangle(new SolidBrush(Color.White), i, panelHeight - arrayToSort[i], 1, panelHeight);
            }
           
        }

        public void drawBar(int[] arrayToSort, int position, int height){
            graphicPanel.FillRectangle(new SolidBrush(Color.Black), position, 0, 1, height);
            graphicPanel.FillRectangle(new SolidBrush(Color.White), position, height - arrayToSort[position], 1, height);
        }
    }
}
