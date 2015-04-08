
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI
{
    public partial class FrmSelectInstrument : Form
    {
        //public IList<int> SelectedInstrumentIds;
        public IList<Instrument> SelectedInstruments;
        private IList<SiteInstrument> _selectedInstids;
        private IList<ForecastCategoryInstrument> _selectedFCInst;
        
        public FrmSelectInstrument(IList<SiteInstrument> selectedids)
        {
            _selectedInstids = selectedids;
        
            InitializeComponent();
            //SelectedInstrumentIds = new List<int>();
            SelectedInstruments = new List<Instrument>();
            BindSites();
        }

        public FrmSelectInstrument(IList<ForecastCategoryInstrument> selectedids,int i)
        {
            _selectedFCInst = selectedids;

            InitializeComponent();
            //SelectedInstrumentIds = new List<int>();
            SelectedInstruments = new List<Instrument>();
            BindFCInstrument();
        }

        private void BindFCInstrument()
        {
            lvSiteAll.BeginUpdate();
            lvSiteAll.Items.Clear();

            foreach (Instrument s in DataRepository.GetAllInstrument())
            {
                if (!IsFCInstSelected(s.Id))
                {
                    ListViewItem li = new ListViewItem(s.TestingArea.AreaName.ToString()) { Tag = s };
                    li.SubItems.Add(s.InstrumentName);//b
                    li.SubItems.Add(s.MaxThroughPut.ToString());

                    lvSiteAll.Items.Add(li);
                }
            }

            lvSiteAll.EndUpdate();
        }

        private void BindSites()
        {
            lvSiteAll.BeginUpdate();
            lvSiteAll.Items.Clear();

            foreach (Instrument s in DataRepository.GetAllInstrument())
            {
                if (!IsInstSelected(s.Id))
                {
                    ListViewItem li = new ListViewItem(s.TestingArea.AreaName.ToString()) { Tag = s };
                    li.SubItems.Add(s.InstrumentName);//b
                    li.SubItems.Add(s.MaxThroughPut.ToString());

                    lvSiteAll.Items.Add(li);
                }
            }

            lvSiteAll.EndUpdate();
        }

        private bool IsInstSelected(int instid)
        {
            foreach (SiteInstrument si in _selectedInstids)
            {
                if (si.Instrument.Id == instid)
                    return true;
            }
            return false;
        }

        private bool IsFCInstSelected(int instid)
        {
            foreach (ForecastCategoryInstrument si in _selectedFCInst)
            {
                if (si.Instrument.Id == instid)
                    return true;
            }
            return false;
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvSiteAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                //SelectedInstrumentIds.Add((int)lvSiteAll.SelectedItems[i].Tag);
                SelectedInstruments.Add((Instrument)lvSiteAll.SelectedItems[i].Tag);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
