using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public class Printer
    {
        int nextIdx = 0;
        private List<string> contents;
        private Font printFont;

        public Printer(List<string> contents)
        {
            this.contents = contents;
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float yPos = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            int lastidx = getLastIdxForPage(ev);

            // Iterate over the file, printing each line.
            for(int i = nextIdx; i < lastidx; i++)
            {
                yPos = topMargin + ((nextIdx + i) * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(contents[i], printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }
            nextIdx = lastidx;
            if (lastidx < contents.Count)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }

        int getLastIdxForPage(PrintPageEventArgs ev)
        {
            int lastIdx = nextIdx;
            int linesPerPage = (int)(ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics));
            lastIdx = Math.Min(contents.Count, lastIdx + linesPerPage);
            return lastIdx;
        }

        // Print the file.
        public void Print()
        {
            try
            {
                printFont = new Font("Arial", 10);
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Print the document.
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


}
