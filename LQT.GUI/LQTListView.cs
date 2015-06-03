
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using LQT.Core.Util;

namespace LQT.GUI
{
    public class LQTListView : System.Windows.Forms.ListView
    {
        private ListViewItem lvItem;
        private int X = 0;
        private int Y = 0;
        private string subItemText;
        public int subItemSelected = 0;
        //private static int SelectedSubItem = 0;
        private System.Windows.Forms.TextBox editTextBox = new System.Windows.Forms.TextBox();
        private IList<int> noneEditablCol = new List<int>();
        private string groupHeader;
        //private ForecastPeriodEnum _fperiodEnum = ForecastPeriodEnum.MONTHLY;

        public event EventHandler<SubitemTextEventArgs> SubitemTextChanged;
        //public event EventHandler OnSubitemTextChanged;
        public event EventHandler OnSelectedGroupChanged;

        private System.Windows.Forms.LinkLabel lnkLabel = new System.Windows.Forms.LinkLabel();
        private IList<int> lnkLabelCols = new List<int>();
        private System.Windows.Forms.Form lnkFrm = new System.Windows.Forms.Form();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public void AddNoneEditableColumn(int colIndex)
        {
            if (!noneEditablCol.Contains(colIndex))
                noneEditablCol.Add(colIndex);
        }

        public void AddLinkLableColumn(int colIndex,Form frm)
        {
            if (!lnkLabelCols.Contains(colIndex))
                lnkLabelCols.Add(colIndex);
            lnkFrm = frm;
        }

        public LQTListView()
        {
            InitializeComponent();

            ListViewColumnSorter _lvwItemComparer = new ListViewColumnSorter();
            this.ListViewItemSorter = _lvwItemComparer;

            this.MouseUp += new MouseEventHandler(LQTListView_MouseUp);

            this.editTextBox.Size = new System.Drawing.Size(0, 0);
            this.editTextBox.Location = new System.Drawing.Point(0, 0);
        
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.editTextBox});
            this.editTextBox.KeyPress += new KeyPressEventHandler(editTextBox_KeyPress);
            this.editTextBox.KeyDown +=new KeyEventHandler(editTextBox_KeyDown);

            this.editTextBox.LostFocus += new EventHandler(editTextBox_LostFocus);
        
            this.editTextBox.Font = this.Font; //new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.editTextBox.BackColor = Color.LightYellow;
            this.editTextBox.BorderStyle = BorderStyle.FixedSingle;
            this.editTextBox.Text = "";
            this.editTextBox.Hide();


            this.lnkLabel.Size = new System.Drawing.Size(0, 0);
            this.lnkLabel.Location = new System.Drawing.Point(0, 0);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lnkLabel });
            this.lnkLabel.Click += new EventHandler(lnkLabel_Click);
            this.lnkLabel.Font = this.Font; 
            this.lnkLabel.Text = "";
            this.lnkLabel.Hide();
      }


        private void lnkLabel_Click(object sender, EventArgs e)
        {
            
            lnkFrm.ShowDialog();
            if (lnkFrm.DialogResult == DialogResult.OK)
            {
               
                this.lvItem.SubItems[2].Text = lnkFrm.Tag.ToString();
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.SuspendLayout();
            // 
            // LQTListView
            // 
            this.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LQTListView_ItemSelectionChanged);
            this.ResumeLayout(false);

        }
        #endregion

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        protected override void WndProc(ref Message msg)
        {
            // Look for the WM_VSCROLL or the WM_HSCROLL messages.
            if ((msg.Msg == WM_VSCROLL) || (msg.Msg == WM_HSCROLL))
            {
                // Move focus to the ListView to cause TextBox to lose focus.
                this.Focus();
            }

            // Pass message to default handler.
            base.WndProc(ref msg);
        }

        public void OnSubitemTextChanged1(SubitemTextEventArgs e)
        {
            EventHandler<SubitemTextEventArgs> handler = SubitemTextChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void SetSubitemText()
        {
            try
            {
                if (this.lvItem.SubItems[subItemSelected].Text != editTextBox.Text)
                {
                    this.lvItem.SubItems[subItemSelected].Text = editTextBox.Text;
                    //this.lvItem.Focused = true;

                    OnSubitemTextChanged1(new SubitemTextEventArgs(lvItem, subItemSelected));
                    RaiseSelectedGroupChanged(lvItem.Group);
                }
            }
            catch (Exception ex)
            {

            }
        }
                

        private void editTextBox_LostFocus(object sender, System.EventArgs e)
        {
            try 
            { 
                //this.lvItem.SubItems[subItemSelected].Text = editTextBox.Text;
                SetSubitemText();
                this.editTextBox.Hide();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void editTextBox_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void editTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verify that the user presses ESC.
                switch (e.KeyChar)
                {
                    case (char)(int)Keys.Escape:
                        {
                            this.editTextBox.Text = lvItem.SubItems[subItemSelected].Text;
                            this.editTextBox.Hide();
                            break;
                        }

                    case (char)(int)Keys.Enter:
                        {
                            //this.lvItem.SubItems[subItemSelected].Text = editTextBox.Text;
                            SetSubitemText();
                            this.editTextBox.Hide();
                            break;
                        }
                    case (char)(int)Keys.Tab:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            { }

        }

        private void editTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try { 
            // Verify that the user presses ESC.
            switch (e.KeyCode)
            {

                case Keys.Up:
                    {
                        this.editTextBox.Hide();
                        this.editTextBox.SendToBack();
                        MoveWithArrow(Keys.Up);
                        break;
                    }
                case Keys.Down:
                    {

                        this.editTextBox.Hide();
                        this.editTextBox.SendToBack();
                        MoveWithArrow(Keys.Down);
                        break;
                    }
                case Keys.Left:
                    {
                        this.editTextBox.Hide();
                        this.editTextBox.SendToBack();
                        MoveWithArrow(Keys.Left);
                        break;
                    }
                case Keys.Right:
                    {

                        this.editTextBox.Hide();
                        this.editTextBox.SendToBack();
                        MoveWithArrow(Keys.Right);
                        break;
                    }
            }
            }
            catch (Exception ex)
            { }

        }

        private void MoveWithArrow(Keys k)
        {
            try { 
            int lvItemC=this.Items.Count;
                int id=0 ;//b
                if (lvItem.Text == "ProductUsed/TestPerformed")
                    id = 0;
                else if (lvItem.Text == "StockOut")
                    id = 1;
                else if (lvItem.Text == "InstrumentDowntime")
                    id = 2;
                else if (lvItem.Text == "Adjusted")
                    id = 3;
                else
                    id = 4;

                

            if (k == Keys.Up)
            {
                if (this.Groups.Count > 0)
                {
                    if(((LQTListViewTag)lvItem.Tag).GroupIndex==0)
                    {
                       
                    }
                    lvItemC = lvItem.Group.Items.Count;
                  //  lvItem = lvItem.Group.Items[(((lvItemC +  ((LQTListViewTag)lvItem.Tag).GroupIndex) - 1) % lvItemC)];
                    if(id!=0)
                    lvItem = lvItem.Group.Items[id-1];
                    else
                        lvItem = lvItem.Group.Items[id];
                    
                }
                else
                {
                    lvItem = this.Items[(((lvItemC + lvItem.Index) - 1) % lvItemC)];
                }
            }
            else if (k == Keys.Down)
            {
                if (this.Groups.Count > 0)
                {
                    if ((((LQTListViewTag)lvItem.Tag).GroupIndex + 1) % lvItem.Group.Items.Count == 0)
                    {

                    }
                    lvItemC = lvItem.Group.Items.Count;
                    //lvItem = lvItem.Group.Items[(((lvItemC + ((LQTListViewTag)lvItem.Tag).GroupIndex) +1) % lvItemC)];
                    if (id != 4)
                        lvItem = lvItem.Group.Items[id + 1];
                    else
                        lvItem = lvItem.Group.Items[id];

                }
                else
                {
                    lvItem = this.Items[(((lvItemC + lvItem.Index) + 1) % lvItemC)];
                }
            }
           else
            {
                int position = (k == Keys.Right) ? 1 : -1;
                int index = subItemSelected;
                do
                {
                    subItemSelected = ((lvItem.SubItems.Count +index) + position) % lvItem.SubItems.Count;
                    index += position;

                } while (noneEditablCol.Contains(subItemSelected));
            }
                if (!noneEditablCol.Contains(subItemSelected))
                {
                    subItemText = lvItem.SubItems[subItemSelected].Text;

                    Rectangle ClickedItem = lvItem.SubItems[subItemSelected].Bounds;
                    ClickedItem.Width = this.Columns[subItemSelected].Width;
                    ClickedItem.Height = lvItem.SubItems[subItemSelected].Bounds.Bottom - lvItem.SubItems[subItemSelected].Bounds.Top;

                    this.editTextBox.Bounds = ClickedItem;
                    this.editTextBox.Text = subItemText;
                    
                    this.editTextBox.Show();
                    this.editTextBox.BringToFront();
                    this.editTextBox.Focus();
                   // ((LQTListViewTag)lvItem.Tag).Id =id;
                    //this.editTextBox.SelectAll();
                }
            }
            catch 
            { }

        }
       
        private void LQTListView_MouseUp(object sender, MouseEventArgs e)
        {
            try { 
            // Get the item on the row that is clicked.
            lvItem = this.GetItemAt(e.X, e.Y);
            X = e.X;
            Y = e.Y;

            if (lvItem != null)
            {
                int nStart = X;
                int spos = 0;
                int epos = 0;

                for (int i = 0; i < this.Columns.Count; i++)
                {
                    epos += this.Columns[i].Width;
                    if (nStart > spos && nStart < epos)
                    {
                        subItemSelected = i;
                        break;
                    }

                    spos = epos;
                }
                if (lnkLabelCols.Contains(subItemSelected) )
                {
                    //SelectedSubItem = subItemSelected;
                    subItemText = lvItem.SubItems[subItemSelected].Text;
                    Rectangle ClickedItem = lvItem.Bounds;

                    ClickedItem.Width = this.Columns[subItemSelected].Width;
                    ClickedItem.Height = lvItem.Bounds.Bottom - lvItem.Bounds.Top;
                    ClickedItem.X = spos;

                    this.lnkLabel.Bounds = ClickedItem;

                    //// Set default text for TextBox to match the item that is clicked.
                    this.lnkLabel.Text = subItemText;

                    //// Display the TextBox, and make sure that it is on top with focus.
                    this.lnkLabel.Show();
                    this.lnkLabel.BringToFront();
                    this.lnkLabel.Focus();
                    this.editTextBox.Hide();
                }

                if (!noneEditablCol.Contains(subItemSelected))
                {
                    subItemText = lvItem.SubItems[subItemSelected].Text;

                    Rectangle ClickedItem = lvItem.Bounds;

                    ClickedItem.Width = this.Columns[subItemSelected].Width;
                    ClickedItem.Height = lvItem.Bounds.Bottom - lvItem.Bounds.Top;
                    ClickedItem.X = spos;

                    this.editTextBox.Bounds = ClickedItem;

                    //// Set default text for TextBox to match the item that is clicked.
                    this.editTextBox.Text = subItemText;
                   

                    //// Display the TextBox, and make sure that it is on top with focus.
                    this.editTextBox.Show();
                    this.editTextBox.BringToFront();
                    this.editTextBox.Focus();
                }
            }
            }
            catch 
            { }
        }

        private void LQTListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Group != null)
            {
                if (e.Item.Group.Header != groupHeader)
                {
                    groupHeader = e.Item.Group.Header;
                    RaiseSelectedGroupChanged(e.Item.Group);
                }
            }
        }

        private void RaiseSelectedGroupChanged(ListViewGroup lgroup)
        {
            try
            {
                if (OnSelectedGroupChanged != null)
                {
                    IList<ChartXYValue> xyvlues = new List<ChartXYValue>();
                    foreach (ListViewItem li in lgroup.Items)
                    {
                        ChartXYValue c = new ChartXYValue();
                        c.XValue = li.SubItems[0].Text;
                        c.YValue = decimal.Parse(li.SubItems[4].Text);
                        xyvlues.Add(c);
                    }
                    OnSelectedGroupChanged(this, new LqtListViewGroupSelectedEventArgs(xyvlues, lgroup.Header));
                }
            }
            catch
            {
               
            }
        }

        public void ItemAreAddtogroup()
        {
            groupHeader = "";
            //RaiseSelectedGroupChanged(lgroup);
        }

    }

    public class SubitemTextEventArgs : EventArgs
    {
        private ListViewItem _lvItem;
        private int _columnIndex;

        public SubitemTextEventArgs(ListViewItem lvitem,int columnIndex)
        {
            _lvItem = lvitem;
            _columnIndex = columnIndex;
        }
        public ListViewItem ListVItem
        {
            get { return _lvItem; }
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
        }
    }
}
