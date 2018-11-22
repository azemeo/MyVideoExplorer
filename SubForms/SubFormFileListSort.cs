using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace MyVideoExplorer
{
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class SubFormFileListSort : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int sortColumnIndex;
        /// <summary>
        /// Specifies the order in which to sort
        /// </summary>
        private int sortOrderIndex;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer objectCompare;


        private struct SortColumns
        {
            public const int TITLE = 0;
            public const int TYPE = 1;
            public const int SIZE = 2;
        }

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public SubFormFileListSort()
        {
            // Initialize the column to '0'
            sortColumnIndex = SortColumns.TITLE;

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
            int compareResult = 0;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (sortColumnIndex == SortColumns.SIZE)
            {
                VideoItemFileInfo listviewXVideoFileInfo = (VideoItemFileInfo)listviewX.Tag;
                VideoItemFileInfo listviewYVideoFileInfo = (VideoItemFileInfo)listviewY.Tag;

                compareResult = (listviewXVideoFileInfo.videoItemFile.Length > listviewYVideoFileInfo.videoItemFile.Length) ? 1 : -1;
            }
            else 
            {
                // strings: title, type
                compareResult = objectCompare.Compare(listviewX.SubItems[sortColumnIndex].Text, listviewY.SubItems[sortColumnIndex].Text);
            }

            if (sortOrderIndex == SortOrders.DESC)
            {
                // Descending sort is selected, return negative result of compare operation
                compareResult *= -1;
            }
            return compareResult;
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (SortColumns.TITLE, etc).
        /// </summary>
        public int SortColumnIndex
        {
            set
            {
                sortColumnIndex = value;
            }
            get
            {
                return sortColumnIndex;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (SortOrders.ASC or SortOrders.DESC).
        /// </summary>
        public int SortOrderIndex
        {
            set
            {
                sortOrderIndex = value;
            }
            get
            {
                return sortOrderIndex;
            }
        }

    }

}
