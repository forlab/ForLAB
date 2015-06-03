
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;



namespace LQT.GUI
{

    // This class is an implementation of the 'IComparer' interface.
    public class ListViewColumnSorter : IComparer
    {
        // Specifies the column to be sorted
        private int ColumnToSort;

        // Specifies the order in which to sort (i.e. 'Ascending').
        private SortOrder OrderOfSort;

        // Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;

        // Class constructor, initializes various elements
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        // This method is inherited from the IComparer interface.
        // It compares the two objects passed using a case
        // insensitive comparison.
        //
        // x: First object to be compared
        // y: Second object to be compared
        //
        // The result of the comparison. "0" if equal,
        // negative if 'x' is less than 'y' and
        // positive if 'x' is greater than 'y'
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                System.DateTime firstDate =
                    LqtUtil.DurationToDateTime(listviewX.SubItems[ColumnToSort].Text);
               // DateTime f = LqtUtil.DurationToDateTime(listviewX.SubItems[ColumnToSort].Text);
                System.DateTime secondDate =
                    LqtUtil.DurationToDateTime(listviewY.SubItems[ColumnToSort].Text);
                   // DateTime.Parse(listviewY.SubItems[ColumnToSort].Text);

                // Compare the two dates.
                compareResult = DateTime.Compare(firstDate, secondDate);
            }

            // If neither compared object has a valid date format,
            // perform a Case Insensitive Sort
            catch
            {
                // Case Insensitive Compare
                compareResult = ObjectCompare.Compare(
                    listviewX.SubItems[ColumnToSort].Text,
                    listviewY.SubItems[ColumnToSort].Text
                );
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        } 

        // Gets or sets the number of the column to which to
        // apply the sorting operation (Defaults to '0').
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        // Gets or sets the order of sorting to apply
        // (for example, 'Ascending' or 'Descending').
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    } 
}
