
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LQT.Core.Util
{
    public static class SortExtensions
    {
        /// <summary>
        /// Sorts an IList(T) in place.
        /// </summary>
        /// <typeparam name="T">The type of objects the list holds</typeparam>
        /// <param name="list">The list to be sorted</param>
        /// <param name="comparison">A delegate defining how to compare two items in the list</param>
        public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
        {
            ArrayList.Adapter((IList)list).Sort(new ComparisonComparer<T>(comparison));
        }

        /// <summary>
        /// Convenience method on IEnumerable(T) to allow passing of a Comparison delegate
        /// to the OrderBy method.
        /// </summary>
        /// <typeparam name="T">The type of objects the list holds</typeparam>
        /// <param name="list">The list to be sorted</param>
        /// <param name="comparison">A delegate defining how to compare two items in the list</param>
        /// <returns>An IOrderedEnumerable(T)</returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, Comparison<T> comparison)
        {
            return list.OrderBy(t => t, new ComparisonComparer<T>(comparison));
        }
    }

    /// <summary>
    /// Wraps a generic Comparison(T) delegate in an IComparer to make it easy 
    /// to use a lambda expression for methods that take an IComparer or IComparer(T)
    /// </summary>
    /// <typeparam name="T">The type being compared</typeparam>
    public class ComparisonComparer<T> : IComparer<T>, IComparer
    {
        private readonly Comparison<T> _comparison;

        ///<summary>
        /// Wraps a generic Comparison(T) delegate so that we may easily use a lambda 
        /// expression with methods that accept an IComparer or IComparer(T).
        ///</summary>
        ///<param name="comparison">A delegate that compares two objects of type T</param>
        public ComparisonComparer(Comparison<T> comparison)
        {
            _comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            return _comparison(x, y);
        }

        public int Compare(object o1, object o2)
        {
            return _comparison((T)o1, (T)o2);
        }
    }
}
