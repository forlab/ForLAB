
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
    public class SortWrapper
    {
        internal ListViewItem sortItem;
        internal int sortColumn;


        // A SortWrapper requires the item and the index of the clicked column.
        public SortWrapper(ListViewItem Item, int iColumn)
        {
            sortItem = Item;
            sortColumn = iColumn;
        }

        // Text property for getting the text of an item.
        //public string Text
        //{
        //    get
        //    {
        //        return sortItem.SubItems[sortColumn].Text;
        //    }
        //}

        // Implementation of the IComparer
        // interface for sorting ArrayList items.

        public class SortComparer : IComparer
        {
            bool ascending;

            // Constructor requires the sort order;
            // true if ascending, otherwise descending.
            public SortComparer(bool asc)
            {
                this.ascending = asc;
            }

            // Implemnentation of the IComparer:Compare
            // method for comparing two objects.
            public int Compare(object x, object y)
            {
                SortWrapper xItem = (SortWrapper)x;
                SortWrapper yItem = (SortWrapper)y;

                string xText = xItem.sortItem.SubItems[xItem.sortColumn].Text;
                string yText = yItem.sortItem.SubItems[yItem.sortColumn].Text;
                return xText.CompareTo(yText) * (this.ascending ? 1 : -1);
            }
        }

       
    }
}
