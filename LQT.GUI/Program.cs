
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
using System.Windows.Forms;
using LQT.Core.UserExceptions;

namespace LQT.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

               Application.DoEvents();
                new frmSplash().ShowDialog();                
                Application.Run(new LqtMainWindowForm());
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                //System.Diagnostics.Debugger.Break();
            }
        }
    }
}
