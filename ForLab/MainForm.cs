
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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ForLab
{
    public partial class MainForm : Form
    {
        private static readonly string LQTEXE = "LQT.GUI.exe";
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcessesByName(LQTEXE);
            if (procs.Length == 0)
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                path = Path.Combine(path, LQTEXE);
                Process.Start(path);

                Application.Exit();
            }
        }

    }
}
