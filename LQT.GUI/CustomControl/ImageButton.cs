
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace LQT.GUI
{
    public class ImageButton : PictureBox, IButtonControl
    {
        private string _title;
        private string _description;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private bool _hover = false;
        private ImageList _imageList1;
        private IContainer components;
        private bool isDefault = false;
        private Popup _toolTip;
        private CustomToolTip _customToolTip;

        [Category("Appearance")]
        [Description("A title to show when the button is hovered over.")]        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [Category("Appearance")]
        [Description("A description text to show when the button is hovered over.")]        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }


        public ImageButton()
        {
            InitializeComponent();
            Image = _imageList1.Images[0];
            SizeMode = PictureBoxSizeMode.StretchImage;
            Width = 16;
            Height = 16;
        }

        #region IButtonControl Members

        private DialogResult m_DialogResult;
        public DialogResult DialogResult
        {
            get
            {
                return m_DialogResult;
            }
            set
            {
                m_DialogResult = value;
            }
        }

        public void NotifyDefault(bool value)
        {
            isDefault = value;
        }

        public void PerformClick()
        {
            base.OnClick(EventArgs.Empty);
        }

        #endregion

        #region Description Changes
        [Description("Controls how the ImageButton will handle image placement and control sizing.")]
        public new PictureBoxSizeMode SizeMode { get { return base.SizeMode; } set { base.SizeMode = value; } }

        [Description("Controls what type of border the ImageButton should have.")]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { base.BorderStyle = value; } }
        #endregion

        #region Hiding

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image { get { return base.Image; } set { base.Image = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { base.BackgroundImageLayout = value; } }
              

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage { get { return base.BackgroundImage; } set { base.BackgroundImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String ImageLocation { get { return base.ImageLocation; } set { base.ImageLocation = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image ErrorImage { get { return base.ErrorImage; } set { base.ErrorImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image InitialImage { get { return base.InitialImage; } set { base.InitialImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool WaitOnLoad { get { return base.WaitOnLoad; } set { base.WaitOnLoad = value; } }
        #endregion

        #region Events

        protected override void OnMouseHover(EventArgs e)
        {
            _hover = true;
            Image = _imageList1.Images[1];
            base.OnMouseHover(e);

            if (_toolTip == null)
            {
                _toolTip = new Popup(_customToolTip = new CustomToolTip(Title, Description));
                _toolTip.AutoClose = false;
                _toolTip.FocusOnOpen = false;
            }
            _toolTip.Show(this);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            Image = _imageList1.Images[0];
            base.OnMouseLeave(e);

            if (_toolTip != null)
                _toolTip.Close();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.Focus();
            OnMouseUp(null);
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_hover)
            {
                Image = _imageList1.Images[1];
            }
            else
                Image = _imageList1.Images[0];
            base.OnMouseUp(e);
        }

        private bool holdingSpace = false;

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WM_KEYUP)
            {
                if (holdingSpace)
                {
                    if ((int)msg.WParam == (int)Keys.Space)
                    {
                        OnMouseUp(null);
                        PerformClick();
                    }
                    else if ((int)msg.WParam == (int)Keys.Escape
                        || (int)msg.WParam == (int)Keys.Tab)
                    {
                        holdingSpace = false;
                        OnMouseUp(null);
                    }
                }
                return true;
            }
            else if (msg.Msg == WM_KEYDOWN)
            {
                if ((int)msg.WParam == (int)Keys.Space)
                {
                    holdingSpace = true;
                    OnMouseDown(null);
                }
                else if ((int)msg.WParam == (int)Keys.Enter)
                {
                    PerformClick();
                }
                return true;
            }
            else
                return base.PreProcessMessage(ref msg);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            holdingSpace = false;
            OnMouseUp(null);
            base.OnLostFocus(e);
        }

        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageButton));
            this._imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // _imageList1
            // 
            this._imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList1.ImageStream")));
            this._imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList1.Images.SetKeyName(0, "Help1.png");
            this._imageList1.Images.SetKeyName(1, "Help2.png");
            // 
            // ImageButton
            // 
            this.InitialImage = ((System.Drawing.Image)(resources.GetObject("$this.InitialImage")));
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

       
    }
}
