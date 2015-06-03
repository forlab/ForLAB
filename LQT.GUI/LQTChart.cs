
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
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;

namespace LQT.GUI
{
    public partial class LQTChart : System.Windows.Forms.DataVisualization.Charting.Chart
    {
        private System.Windows.Forms.ContextMenuStrip cmnuchart;
        private System.Windows.Forms.ToolStripMenuItem tsmcopy;
        private System.Windows.Forms.ToolStripMenuItem tsmsaveimage;
        private System.Windows.Forms.ToolStripMenuItem tsmpreview;
        private System.Windows.Forms.ToolStripMenuItem tsmprint;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartcopy;
        private System.Windows.Forms.Form frm;
        private System.Windows.Forms.Control c;

        public LQTChart()
        {


            InitializeComponent();
            this.frm = new System.Windows.Forms.Form();
            this.c = new System.Windows.Forms.Control();
            this.chartcopy = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.cmnuchart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmcopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmsaveimage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmprint = new System.Windows.Forms.ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.cmnuchart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();


            // cmnuchart
            // 
            this.cmnuchart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmcopy,
            this.tsmsaveimage,
            this.tsmpreview,
            this.tsmprint});
            this.cmnuchart.Name = "cmnuchart";
            this.cmnuchart.Size = new System.Drawing.Size(151, 92);
            // 
            // tsmcopy
            // 
            this.tsmcopy.Name = "tsmcopy";
            this.tsmcopy.Size = new System.Drawing.Size(150, 22);
            this.tsmcopy.Text = "Copy";
            this.tsmcopy.Click += new System.EventHandler(tsmcopy_Click);
            // 
            // tsmsaveimage
            // 
            this.tsmsaveimage.Name = "tsmsaveimage";
            this.tsmsaveimage.Size = new System.Drawing.Size(150, 22);
            this.tsmsaveimage.Text = "Save As Image";
            this.tsmsaveimage.Click += new System.EventHandler(tsmsaveimage_Click);
            // 
            // tsmpreview
            // 
            this.tsmpreview.Name = "tsmpreview";
            this.tsmpreview.Size = new System.Drawing.Size(150, 22);
            this.tsmpreview.Text = "Print";
            this.tsmpreview.Click += new System.EventHandler(tsmpreview_Click);
            // 
            // tsmprint
            // 
            this.tsmprint.Name = "tsmzoom";
            this.tsmprint.Size = new System.Drawing.Size(150, 22);
            this.tsmprint.Text = "Zoom";
            this.tsmprint.Click += new System.EventHandler(tsmzoom_Click);


            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.cmnuchart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

            this.ContextMenuStrip = this.cmnuchart;




        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

        }

        #endregion

        //private const int WM_HSCROLL = 0x114;
        //private const int WM_VSCROLL = 0x115;

        //protected override void WndProc(ref Message msg)
        //{
        //    // Look for the WM_VSCROLL or the WM_HSCROLL messages.
        //    if ((msg.Msg == WM_VSCROLL) || (msg.Msg == WM_HSCROLL))
        //    {
        //        // Move focus to the ListView to cause TextBox to lose focus.
        //        this.Focus();
        //    }

        //    // Pass message to default handler.
        //    base.WndProc(ref msg);
        //}

        private void tsmcopy_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.SaveImage(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            Bitmap bmp = new Bitmap(stream);
            Clipboard.SetDataObject(bmp);
        }
        private void tsmsaveimage_Click(object sender, EventArgs e)
        {

            try
            {
                if (SaveGraph())
                    MessageBox.Show("Graph Saved Successfully.");
            }
            catch
            {
                MessageBox.Show("There was an error saving the Graph. Please try again. If the problem persists, please call your System Administrator.");
            }
        }
        public bool SaveGraph()
        {
            SaveFileDialog sfdSave = new SaveFileDialog();
            sfdSave.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            sfdSave.FilterIndex = 2;
            sfdSave.RestoreDirectory = true;
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                ChartImageFormat format = ChartImageFormat.Bmp;
                if (sfdSave.FileName.EndsWith("jpg"))
                    format = ChartImageFormat.Jpeg;
                else
                    if (sfdSave.FileName.EndsWith("emf"))
                        format = ChartImageFormat.Emf;
                    else
                        if (sfdSave.FileName.EndsWith("gif"))
                            format = ChartImageFormat.Gif;
                        else
                            if (sfdSave.FileName.EndsWith("png"))
                                format = ChartImageFormat.Png;
                            else
                                if (sfdSave.FileName.EndsWith("tif"))
                                    format = ChartImageFormat.Tiff;
                this.SaveImage(sfdSave.FileName, format);
                return true;
            }
            else
            {
                return false;
            }

        }
        private void tsmpreview_Click(object sender, EventArgs e)
        {
            this.Printing.PrintPreview();
        }
        private void tsmzoom_Click(object sender, EventArgs e)
        {

            //this.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //this.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            Control c = this.Parent;
            chartcopy = this;

            ZoomedChart frm = new ZoomedChart(this);

            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            c.Controls.Add(chartcopy);
            chartcopy.Invalidate();
            chartcopy.Show();

        }
        private object CloneControls(object o)
        {
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Object retObject = type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, o, null);
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(retObject, propertyInfo.GetValue(o, null), null);
                }
            }
            return retObject;

        }
    }
}
