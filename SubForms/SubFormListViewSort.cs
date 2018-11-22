using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;

namespace MyVideoExplorer
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class SubFormListViewSort : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        public int sortColumnIndex;
        /// <summary>
        /// Specifies the order in which to sort
        /// </summary>
        public int sortOrderIndex;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer objectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public SubFormListViewSort()
        {
            // Initialize the column to '0'
            sortColumnIndex = FilterEnums.sortColumn.GetValueByKey("TITLE");

            // Initialize the sort order to 'none'
            sortOrderIndex = SortOrders.ASC;

            // Initialize the CaseInsensitiveComparer object
            objectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  
        /// It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // SortOrders.ASC
            // Compare the two items
            compareResult = objectCompare.Compare(listviewX.SubItems[sortColumnIndex].Text, listviewY.SubItems[sortColumnIndex].Text);

            if (sortOrderIndex == SortOrders.DESC)
            {
                // Descending sort is selected, return negative result of compare operation
                compareResult *= -1;
            }
            return compareResult;
        }

    }

}
