
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class SiteListView :ListView 
    {
        
        private ListViewItem.ListViewSubItem _clickedsubitem; //clicked ListViewSubItem
        private ListViewItem _clickeditem; //clicked ListViewItem
        private int _col; //index of doubleclicked ListViewSubItem
        private int _sortcol; //index of clicked ColumnHeader
        private Brush _sortcolbrush; //color of items in sorted column
        private Brush _highlightbrush; //color of highlighted items
        private int _cpadding; //padding of the embedded controls
        private TextBox txtbx; //the default edit control
        //private ComboBox _comBox;

        private const UInt32 LVM_FIRST = 0x1000;
        private const UInt32 LVM_SCROLL = (LVM_FIRST + 20);
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_PAINT = 0x000F;

        //private System.ComponentModel.IContainer components;
        public event EventHandler<EXBoolListViewSubItemEventArgs> BoolListViewSubItemValueChanged;
        public event EventHandler<EXEditableListViewSubitemEventArgs> EditableListViewSubitemValueChanged;
        public event EventHandler<EXEditableListViewComboBoxEventArgs> ComboBoxBeforeVisible;
        //private struct EmbeddedControl
        //{
        //    public Control MyControl;
        //    public EXControlListViewSubItem MySubItem;
        //}

        //private ArrayList _controls;
            
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, UInt32 m, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == WM_PAINT)
            //{
            //    foreach (EmbeddedControl c in _controls)
            //    {
            //        Rectangle r = c.MySubItem.Bounds;
            //        if (r.Y > 0 && r.Y < this.ClientRectangle.Height)
            //        {
            //            c.MyControl.Visible = true;
            //            c.MyControl.Bounds = new Rectangle(r.X + _cpadding, r.Y + _cpadding, r.Width - (2 * _cpadding), r.Height - (2 * _cpadding));
            //        }
            //        else
            //        {
            //            c.MyControl.Visible = false;
            //        }
            //    }
            //}
            switch (m.Msg)
            {
                case WM_HSCROLL:
                case WM_VSCROLL:
                case WM_MOUSEWHEEL:
                    this.Focus();
                    break;
            }
            base.WndProc(ref m);
        }

        private void ScrollMe(int x, int y)
        {
            SendMessage((IntPtr)this.Handle, LVM_SCROLL, x, y);
        }

        public SiteListView()
        {
            _cpadding = 4;
            _sortcol = -1;
            //_controls = new ArrayList();
            _sortcolbrush = SystemBrushes.ControlLight;
            _highlightbrush = SystemBrushes.Highlight;

            this.OwnerDraw = true;
            this.FullRowSelect = true;
            this.View = View.Details;
            this.MouseDown += new MouseEventHandler(this_MouseDown);
            this.MouseDoubleClick += new MouseEventHandler(this_MouseDoubleClick);
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this_DrawColumnHeader);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(this_DrawSubItem);
            this.MouseMove += new MouseEventHandler(this_MouseMove);
            this.ColumnClick += new ColumnClickEventHandler(this_ColumnClick);

            txtbx = new TextBox();
            txtbx.Visible = false;
            this.Controls.Add(txtbx);
            txtbx.Leave += new EventHandler(c_Leave);
            txtbx.KeyPress += new KeyPressEventHandler(txtbx_KeyPress);

            //_comBox = new ComboBox();
            //_comBox.Visible = false;
            //this.Controls.Add(_comBox);
            //_comBox.Leave += new EventHandler(c_Leave);
        }

        public int ControlPadding {
            get {return _cpadding;}
            set {_cpadding = value;}
        }
        
        public Brush MySortBrush {
            get {return _sortcolbrush;}
            set {_sortcolbrush = value;}
        }
        
        public Brush MyHighlightBrush {
            get {return _highlightbrush;}
            set {_highlightbrush = value;}
        }

        private void txtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtbx.Text != _clickedsubitem.Text)
                {
                    _clickedsubitem.Text = txtbx.Text;
                    OnEditableListViewSubitemChanged(new EXEditableListViewSubitemEventArgs(_clickeditem, (EXListViewSubItem)_clickedsubitem));
                }
                txtbx.Visible = false;
                //_clickeditem.Tag = null;
            }
        }

        private void c_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c.Text != _clickedsubitem.Text)
            {
                _clickedsubitem.Text = c.Text;
                OnEditableListViewSubitemChanged(new EXEditableListViewSubitemEventArgs(_clickeditem, (EXListViewSubItem)_clickedsubitem));
            }
            c.Visible = false;
            
            //_clickeditem.Tag = null;

        }
        
        public void OnEditableListViewSubitemChanged(EXEditableListViewSubitemEventArgs e)
        {
            if (EditableListViewSubitemValueChanged != null)
            {
                EditableListViewSubitemValueChanged(this, e);
            }
        }

        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo lstvinfo = this.HitTest(e.X, e.Y);
            ListViewItem.ListViewSubItem subitem = lstvinfo.SubItem;
            if (subitem == null) return;
            int subx = subitem.Bounds.Left;
            if (subx < 0)
            {
                this.ScrollMe(subx, 0);
            }
        }

        private void this_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EXListViewItem lstvItem = this.GetItemAt(e.X, e.Y) as EXListViewItem;
            if (lstvItem == null) 
                return;
            _clickeditem = lstvItem;
            int x = lstvItem.Bounds.Left;
            int i;
            for (i = 0; i < this.Columns.Count; i++)
            {
                x = x + this.Columns[i].Width;
                if (x > e.X)
                {
                    x = x - this.Columns[i].Width;
                    _clickedsubitem = lstvItem.SubItems[i];
                    _col = i;
                    break;
                }
            }
            
            if (!(this.Columns[i] is EXColumnHeader)) 
                return;
            
            EXColumnHeader col = (EXColumnHeader)this.Columns[i];
            if (col.GetType() == typeof(EXEditableColumnHeader))
            {
                EXEditableColumnHeader editcol = (EXEditableColumnHeader) col;
                if (editcol.MyControl != null)
                {
                    Control c = editcol.MyControl;
                    if (c.Tag != null)
                    {
                        this.Controls.Add(c);
                        c.Tag = null;
                        if (c is ComboBox)
                        {
                            ((ComboBox)c).SelectedValueChanged += new EventHandler(cmbx_SelectedValueChanged);
                        }
                        c.Leave += new EventHandler(c_Leave);
                    }

                    if (c is ComboBox)
                    {
                        if(ComboBoxBeforeVisible != null)
                            ComboBoxBeforeVisible(this, new EXEditableListViewComboBoxEventArgs(_clickeditem, (EXListViewSubItem)_clickedsubitem) );
                    }

                    c.Location = new Point(x, this.GetItemRect(this.Items.IndexOf(lstvItem)).Y);
                    c.Width = this.Columns[i].Width;
                    if (c.Width > this.Width) c.Width = this.ClientRectangle.Width;
                    c.Text = _clickedsubitem.Text;
                    c.Visible = true;
                    c.BringToFront();
                    c.Focus();
                }
                else
                {
                    txtbx.Location = new Point(x, this.GetItemRect(this.Items.IndexOf(lstvItem)).Y);
                    txtbx.Width = this.Columns[i].Width;
                    if (txtbx.Width > this.Width) txtbx.Width = this.ClientRectangle.Width;
                    txtbx.Text = _clickedsubitem.Text;
                    txtbx.Visible = true;
                    txtbx.BringToFront();
                    txtbx.Focus();
                }
            }
            else if (col.GetType() == typeof(EXBoolColumnHeader))
            {
                EXBoolColumnHeader boolcol = (EXBoolColumnHeader)col;
                if (boolcol.Editable)
                {
                    EXBoolListViewSubItem boolsubitem = (EXBoolListViewSubItem)_clickedsubitem;
                    if (boolsubitem.BoolValue == true)
                    {
                        boolsubitem.BoolValue = false;
                    }
                    else
                    {
                        boolsubitem.BoolValue = true;
                    }

                    if (BoolListViewSubItemValueChanged != null)
                    {
                        BoolListViewSubItemValueChanged(this, new EXBoolListViewSubItemEventArgs(_clickeditem, boolsubitem));
                    }
                    this.Invalidate(boolsubitem.Bounds);
                }
            }
        }

        private void cmbx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Visible == false || _clickedsubitem == null) 
                return;
            ComboBox c = (ComboBox)sender;
            _clickedsubitem.Text = c.Text;
            OnEditableListViewSubitemChanged(new EXEditableListViewSubitemEventArgs(_clickeditem, (EXListViewSubItem)_clickedsubitem));
        }

        private void this_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag == null)
            {
                this.Invalidate(item.Bounds);
                item.Tag = "t";
            }
        }
        
        private void this_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            e.DrawDefault = true;
        }

        private void this_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            if (e.ColumnIndex == _sortcol)
            {
                e.Graphics.FillRectangle(_sortcolbrush, e.Bounds);
            }
            if ((e.ItemState & ListViewItemStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(_highlightbrush, e.Bounds);
            }

            int fonty = e.Bounds.Y + ((int)(e.Bounds.Height / 2)) - ((int)(e.SubItem.Font.Height / 2));
            int x = e.Bounds.X + 2;
            
            if (e.ColumnIndex == 0)
            {
                EXListViewItem item = (EXListViewItem)e.Item;
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(e.SubItem.ForeColor), x, fonty);
                return;
            }
            
            EXListViewSubItemAB subitem = e.SubItem as EXListViewSubItemAB;
            if (subitem == null)
            {
                e.DrawDefault = true;
            }
            else
            {
                x = subitem.DoDraw(e, x, this.Columns[e.ColumnIndex] as EXColumnHeader);
                e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, new SolidBrush(e.SubItem.ForeColor), x, fonty);
            }
        }

        private void this_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.Items.Count == 0) return;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                this.Columns[i].ImageKey = null;
            }
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Tag = null;
            }
            if (e.Column != _sortcol)
            {
                _sortcol = e.Column;
                this.Sorting = SortOrder.Ascending;
                this.Columns[e.Column].ImageKey = "up";
            }
            else
            {
                if (this.Sorting == SortOrder.Ascending)
                {
                    this.Sorting = SortOrder.Descending;
                    this.Columns[e.Column].ImageKey = "down";
                }
                else
                {
                    this.Sorting = SortOrder.Ascending;
                    this.Columns[e.Column].ImageKey = "up";
                }
            }
            if (_sortcol == 0)
            {
                //ListViewItem
                if (this.Items[0].GetType() == typeof(EXListViewItem))
                {
                    //sorting on text
                    this.ListViewItemSorter = new ListViewItemComparerText(e.Column, this.Sorting);
                }
                else
                {
                    //sorting on value
                    this.ListViewItemSorter = new ListViewItemComparerValue(e.Column, this.Sorting);
                }
            }
            else
            {
                //ListViewSubItem
                if (this.Items[0].SubItems[_sortcol].GetType() == typeof(EXListViewSubItemAB))
                {
                    //sorting on text
                    this.ListViewItemSorter = new ListViewSubItemComparerText(e.Column, this.Sorting);
                }
                else
                {
                    //sorting on value
                    this.ListViewItemSorter = new ListViewSubItemComparerValue(e.Column, this.Sorting);
                }
            }

            
        }

        class ListViewSubItemComparerText : System.Collections.IComparer
        {

            private int _col;
            private SortOrder _order;

            public ListViewSubItemComparerText()
            {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewSubItemComparerText(int col, SortOrder order)
            {
                _col = col;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                string xstr = ((ListViewItem)x).SubItems[_col].Text;
                string ystr = ((ListViewItem)y).SubItems[_col].Text;

                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;

                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y))
                {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                }
                else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y))
                {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                }
                else
                {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }

        }

        class ListViewSubItemComparerValue : System.Collections.IComparer
        {

            private int _col;
            private SortOrder _order;

            public ListViewSubItemComparerValue()
            {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewSubItemComparerValue(int col, SortOrder order)
            {
                _col = col;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                string xstr = ((EXListViewSubItemAB)((ListViewItem)x).SubItems[_col]).MyValue;
                string ystr = ((EXListViewSubItemAB)((ListViewItem)y).SubItems[_col]).MyValue;

                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;

                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y))
                {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                }
                else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y))
                {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                }
                else
                {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }

        }

        class ListViewItemComparerText : System.Collections.IComparer
        {

            private int _col;
            private SortOrder _order;

            public ListViewItemComparerText()
            {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewItemComparerText(int col, SortOrder order)
            {
                _col = col;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                string xstr = ((ListViewItem)x).Text;
                string ystr = ((ListViewItem)y).Text;

                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;

                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y))
                {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                }
                else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y))
                {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                }
                else
                {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }

        }

        class ListViewItemComparerValue : System.Collections.IComparer
        {

            private int _col;
            private SortOrder _order;

            public ListViewItemComparerValue()
            {
                _col = 0;
                _order = SortOrder.Ascending;
            }

            public ListViewItemComparerValue(int col, SortOrder order)
            {
                _col = col;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                string xstr = ((EXListViewItem)x).MyValue;
                string ystr = ((EXListViewItem)y).MyValue;

                decimal dec_x;
                decimal dec_y;
                DateTime dat_x;
                DateTime dat_y;

                if (Decimal.TryParse(xstr, out dec_x) && Decimal.TryParse(ystr, out dec_y))
                {
                    returnVal = Decimal.Compare(dec_x, dec_y);
                }
                else if (DateTime.TryParse(xstr, out dat_x) && DateTime.TryParse(ystr, out dat_y))
                {
                    returnVal = DateTime.Compare(dat_x, dat_y);
                }
                else
                {
                    returnVal = String.Compare(xstr, ystr);
                }
                if (_order == SortOrder.Descending) returnVal *= -1;
                return returnVal;
            }

        }
    }

    public class EXColumnHeader : ColumnHeader
    {

        public EXColumnHeader()
        {

        }

        public EXColumnHeader(string text)
        {
            this.Text = text;
        }

        public EXColumnHeader(string text, int width)
        {
            this.Text = text;
            this.Width = width;
        }
        
    }

    public class EXEditableColumnHeader : EXColumnHeader
    {
        private Control _control;

        public EXEditableColumnHeader()
        {

        }

        public EXEditableColumnHeader(string text)
        {
            this.Text = text;
        }

        public EXEditableColumnHeader(string text, int width)
        {
            this.Text = text;
            this.Width = width;
        }

        public EXEditableColumnHeader(string text, Control control)
        {
            this.Text = text;
            this.MyControl = control;
        }

        public EXEditableColumnHeader(string text, Control control, int width)
        {
            this.Text = text;
            this.MyControl = control;
            this.Width = width;
        }

        public Control MyControl
        {
            get { return _control; }
            set
            {
                _control = value;
                _control.Visible = false;
                _control.Tag = "not_init";
            }
        }

    }
    
    public class EXBoolColumnHeader : EXColumnHeader
    {
        private Image _trueimage;
        private Image _falseimage;
        private bool _editable;

        public EXBoolColumnHeader()
        {
            init();
        }
        
        public EXBoolColumnHeader(string text)
        {
            init();
            this.Text = text;
        }

        public EXBoolColumnHeader(string text, int width)
        {
            init();
            this.Text = text;
            this.Width = width;
        }

        public EXBoolColumnHeader(string text, Image trueimage, Image falseimage)
        {
            init();
            this.Text = text;
            _trueimage = trueimage;
            _falseimage = falseimage;
        }

        public EXBoolColumnHeader(string text, Image trueimage, Image falseimage, int width)
            : this(text, trueimage, falseimage)
        {
            this.Width = width;
        }

        private void init()
        {
            _editable = false;
        }

        public Image TrueImage
        {
            get 
            {
                 //SiteListView
                return _trueimage; 
            }
            set { _trueimage = value; }
        }

        public Image FalseImage
        {
            get { return _falseimage; }
            set { _falseimage = value; }
        }

        public bool Editable
        {
            get { return _editable; }
            set { _editable = value; }
        }

    }

    public abstract class EXListViewSubItemAB : ListViewItem.ListViewSubItem
    {

        private string _value = "";

        public EXListViewSubItemAB()
        {

        }

        public EXListViewSubItemAB(string text)
        {
            this.Text = text;
        }

        public string MyValue
        {
            get { return _value; }
            set { _value = value; }
        }

        //return the new x coordinate
        public abstract int DoDraw(DrawListViewSubItemEventArgs e, int x, LQT.GUI.MorbidityUserCtr.EXColumnHeader ch);

    }

    public class EXListViewSubItem : EXListViewSubItemAB
    {
        private object _colName;

        public EXListViewSubItem()
        {

        }

        public EXListViewSubItem(string text)
        {
            this.Text = text;
        }
        public EXListViewSubItem(string text, object columnName)
        {
            this.Text = text;
            this._colName = columnName;
        }

        public object ColumnName
        {
            get { return _colName; }
        }

        public override int DoDraw(DrawListViewSubItemEventArgs e, int x, LQT.GUI.MorbidityUserCtr.EXColumnHeader ch)
        {
            return x;
        }        
    }

    public class EXControlListViewSubItem : EXListViewSubItemAB
    {
        private Control _control;

        public EXControlListViewSubItem()
        {

        }

        public Control MyControl
        {
            get { return _control; }
            set { _control = value; }
        }

        public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch)
        {
            return x;
        }

    }

    public class EXBoolListViewSubItem : EXListViewSubItemAB
    {
        private bool _value;
        private object _colName;

        public EXBoolListViewSubItem()
        {
        }

        public EXBoolListViewSubItem(bool val)
        {
            _value = val;
            this.MyValue = val.ToString();
        }
        public EXBoolListViewSubItem(bool val, object colname)
            : this(val)
        {
            _colName = colname;
        }

        public bool BoolValue
        {
            get { return _value; }
            set
            {
                _value = value;
                this.MyValue = value.ToString();
            }
        }

        public object ColumnName
        {
            get { return _colName; }
            set { _colName = value; }
        }

        public override int DoDraw(DrawListViewSubItemEventArgs e, int x, EXColumnHeader ch)
        {
            EXBoolColumnHeader boolcol = (EXBoolColumnHeader)ch;
            
            Image boolimg;
            if (this.BoolValue == true)
            {
                boolimg = boolcol.TrueImage;
            }
            else
            {
                boolimg = boolcol.FalseImage;
            }
            int imgy = e.Bounds.Y + ((int)(e.Bounds.Height / 2)) - ((int)(boolimg.Height / 2));
            e.Graphics.DrawImage(boolimg, x, imgy, boolimg.Width, boolimg.Height);
            x += boolimg.Width + 2;
            return x;
        }

    }

    public class EXListViewItem : ListViewItem
    {

        private string _value;

        public EXListViewItem()
        {

        }

        public EXListViewItem(string text)
        {
            this.Text = text;
        }

        public string MyValue
        {
            get { return _value; }
            set { _value = value; }
        }

    }

    public class EXBoolListViewSubItemEventArgs : EventArgs
    {
        public EXBoolListViewSubItemEventArgs(ListViewItem lvitem, EXBoolListViewSubItem subitem)
        {
            ListVItem= lvitem;
            Subitem = subitem;
        }

        public ListViewItem ListVItem { get; private set; }

        public EXBoolListViewSubItem Subitem { get; private set; }
    }

    public class EXEditableListViewSubitemEventArgs : EventArgs
    {
        public EXEditableListViewSubitemEventArgs(ListViewItem lvitem, EXListViewSubItem subitem)
        {
            ListVItem = lvitem;
            SubItem = subitem;
        }

        public ListViewItem ListVItem { get; private set; }

        public EXListViewSubItem SubItem { get; private set; }
    }

    public class EXEditableListViewComboBoxEventArgs : EventArgs
    {
        public EXEditableListViewComboBoxEventArgs(ListViewItem lvitem, EXListViewSubItem subitem)
        {
            ListVItem = lvitem;
            SubItem = subitem;
        }

        public ListViewItem ListVItem { get; private set; }

        public EXListViewSubItem SubItem { get; private set; }
    }
}
