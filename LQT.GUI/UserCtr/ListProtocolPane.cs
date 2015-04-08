
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LQT.GUI.MorbidityProtocolSetting;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListProtocolPane : LQT.GUI.UserCtr.BaseUserControl
    {        
        public ListProtocolPane()
        {
            InitializeComponent();
            BindProtocols();
        }

        public override string GetControlTitle
        {
            get
            {
                return "List of Protocols";
            }
        }

        public void BindProtocols()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            Protocol prt = DataRepository.GetProtocolByPlatform((int)ClassOfMorbidityTestEnum.CD4);
            ListViewItem li = new ListViewItem(ClassOfMorbidityTestEnum.CD4.ToString() + " Protocols") { Tag = ClassOfMorbidityTestEnum.CD4 };
            if (prt != null)
            {
                li.SubItems.Add(prt.Descritpion);
                li.SubItems.Add(prt.TestReapeated.ToString());
                li.SubItems.Add(prt.SymptomDirectedAmt.ToString());
            }
            listView1.Items.Add(li);

            prt = DataRepository.GetProtocolByPlatform((int)ClassOfMorbidityTestEnum.Chemistry);
            li = new ListViewItem(ClassOfMorbidityTestEnum.Chemistry.ToString() + " Protocols") { Tag = ClassOfMorbidityTestEnum.Chemistry };
            if (prt != null)
            {
                li.SubItems.Add(prt.Descritpion);
                li.SubItems.Add(prt.TestReapeated.ToString());
                li.SubItems.Add(prt.SymptomDirectedAmt.ToString());
            }
            listView1.Items.Add(li);


            prt = DataRepository.GetProtocolByPlatform((int)ClassOfMorbidityTestEnum.Hematology);
            li = new ListViewItem(ClassOfMorbidityTestEnum.Hematology.ToString() + " Protocols") { Tag = ClassOfMorbidityTestEnum.Hematology };
            if (prt != null)
            {
                li.SubItems.Add(prt.Descritpion);
                li.SubItems.Add(prt.TestReapeated.ToString());
                li.SubItems.Add(prt.SymptomDirectedAmt.ToString());
            }
            listView1.Items.Add(li);


            prt = DataRepository.GetProtocolByPlatform((int)ClassOfMorbidityTestEnum.ViralLoad);
            li = new ListViewItem(ClassOfMorbidityTestEnum.ViralLoad.ToString() + " Protocols") { Tag = ClassOfMorbidityTestEnum.ViralLoad};
            if (prt != null)
            {
                li.SubItems.Add(prt.Descritpion);
                li.SubItems.Add(prt.TestReapeated.ToString());
                li.SubItems.Add(prt.SymptomDirectedAmt.ToString());
            }
            listView1.Items.Add(li);

            prt = DataRepository.GetProtocolByPlatform((int)ClassOfMorbidityTestEnum.OtherTest);
            li = new ListViewItem(ClassOfMorbidityTestEnum.OtherTest.ToString() + " Protocols") { Tag = ClassOfMorbidityTestEnum.OtherTest };
            if (prt != null)
            {
                li.SubItems.Add(prt.Descritpion);
                li.SubItems.Add(prt.TestReapeated.ToString());
                li.SubItems.Add(prt.SymptomDirectedAmt.ToString());
            }
            listView1.Items.Add(li);

            listView1.EndUpdate();
        }
        
        public override void ReloadUserCtrContents()
        {
            BindProtocols();
        }
               
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                FrmProtocol frm = new FrmProtocol((ClassOfMorbidityTestEnum)listView1.SelectedItems[0].Tag, MdiParentForm);
                frm.ShowDialog();
                BindProtocols();
            }
        }

    }
}
