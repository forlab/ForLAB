
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Location
{
    public partial class SiteCategoryForm : Form
    {
        public SiteCategoryForm()
        {
            InitializeComponent();
            BindSiteCategorys();
        }

        private void BindSiteCategorys()
        {
            lsvCategory.BeginUpdate();
            lsvCategory.Items.Clear();

            foreach (SiteCategory sc in DataRepository.GetListOfAllSiteCategory())
            {
                ListViewItem li = new ListViewItem(sc.CategoryName) { Tag = sc };
                lsvCategory.Items.Add(li);
            }

            lsvCategory.EndUpdate();

            butEdit.Enabled = false;
            butRemove.Enabled = false;
        }

        private void butAddnew_Click(object sender, EventArgs e)
        {
            FrmSiteCat frm = new FrmSiteCat(new SiteCategory());
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindSiteCategorys();
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (lsvCategory.SelectedItems.Count > 0)
            {
                FrmSiteCat frm = new FrmSiteCat((SiteCategory)lsvCategory.SelectedItems[0].Tag);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindSiteCategorys();
                }
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            if (lsvCategory.SelectedItems.Count > 0)
            {
                try
                {
                    SiteCategory sc = (SiteCategory)lsvCategory.SelectedItems[0].Tag;
                    DataRepository.DeleteSiteCategory(sc);
                    BindSiteCategorys();
                }
                catch(Exception ex)
                {
                    new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry you could not delete this Site-Category." }).ShowDialog();
                }
                finally
                {
                    DataRepository.CloseSession();
                }
            }
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvCategory.SelectedItems.Count > 0)
            {
                butRemove.Enabled = true;
                butEdit.Enabled = true;
            }
            else
            {
                butRemove.Enabled = false;
                butEdit.Enabled = false;
            }
        }
    }
}
