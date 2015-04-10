
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using System.Globalization;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class ProductQuantityInStock : LQT.GUI.MorbidityUserCtr.BaseMorbidityControl
    {
        private MorbidityForecast _forecast;      
        public bool _edited = false;
        private IList<MorbiditySupplyProcurement> _supplyProcurement;

        public ProductQuantityInStock(MorbidityForecast forecast)
        {
            _forecast = forecast;
            
            InitializeComponent();

            lvproductQinstock.AddNoneEditableColumn(0);
            lvproductQinstock.AddNoneEditableColumn(1);
            lvproductQinstock.AddNoneEditableColumn(2);
            lvproductQinstock.AddNoneEditableColumn(3);
            lvproductQinstock.AddNoneEditableColumn(5);
            lvproductQinstock.AddNoneEditableColumn(6);
            lvproductQinstock.AddNoneEditableColumn(7);

            lvproductQinstock.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lvproductQinstock_SubitemTextChanged);
            _supplyProcurement = DataRepository.GetSupplyProcurementByForecastId(_forecast.Id);
            BindProcurement();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            double total=0;
            foreach (MorbiditySupplyProcurement sp in _supplyProcurement)
            {
                total += sp.TotalCost;
            }
            lbltotal.Text = string.Format("{0:C}", total);
        }

        private void lvproductQinstock_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            LQTListViewTag tag = (LQTListViewTag)li.Tag;

            MorbiditySupplyProcurement msp;

            if (tag.Id <= 0)
                msp = (MorbiditySupplyProcurement)_supplyProcurement[tag.Index];
            else
                msp =DataRepository.GetMorbiditySupplyProcurementById(tag.Id);
            

            double newvalue = double.Parse(li.SubItems[4].Text);
            if (newvalue >= 0)
                msp.QuantityInStock = newvalue;
            else
                li.SubItems[4].Text = msp.QuantityInStock.ToString();

            double QtoPurchase = double.Parse(li.SubItems[3].Text) - double.Parse(li.SubItems[4].Text);
            if (QtoPurchase < 0)
                QtoPurchase = 0;

            li.SubItems[5].Text = QtoPurchase.ToString();

            NumberStyles styles = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            double totalCost = double.Parse(li.SubItems[6].Text, styles) * double.Parse(li.SubItems[5].Text,styles);

            li.SubItems[7].Text = string.Format("{0:C}",totalCost);

            CalculateTotal();
            
            _edited = true;
        }

        public override string Title
        {
            get { return "Procurement Summary"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }
        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return true;
        }

        public override string Description
        {
            get
            {
                string des = "The Procurement Summary is the most important output of the Laboratory Quantification Model. ";
                des +="It shows you how many of each product need to be purchased, and how much money will need to be spent.<br>";
                
                return des;
            }
        }
        private void BindProcurement()
        {
            lvproductQinstock.Items.Clear();
            lvproductQinstock.BeginUpdate();
            int index = 0;
            foreach (MorbiditySupplyProcurement p in _supplyProcurement)
            {
                LQTListViewTag tag = new LQTListViewTag();
                tag.GroupTitle = (p.PlatformEnum.ToString());
                tag.Id = p.Id;
                tag.Index = index;
                MasterProduct product=DataRepository.GetProductById(p.ProductId);
                
                ListViewItem li = new ListViewItem(product.ProductName) { Tag = tag };

                li.SubItems.Add(p.PackSize.ToString());
                li.SubItems.Add(product.BasicUnit);
                li.SubItems.Add(p.QuantityNeeded.ToString());
                li.SubItems.Add(p.QuantityInStock.ToString());
                li.SubItems.Add(p.QuantityToPurchase.ToString());
                li.SubItems.Add(string.Format("{0:C}",p.UnitCost).ToString());
                li.SubItems.Add(string.Format("{0:C}",p.TotalCost).ToString());

                LqtUtil.AddItemToGroup(lvproductQinstock, li);

                lvproductQinstock.Items.Add(li);
                index++;
            }

            lvproductQinstock.EndUpdate();

        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.MorbiditySupplyProcurementBatchSave(_supplyProcurement);
            }
            return true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DataRepository.MorbiditySupplyProcurementBatchSave(_supplyProcurement);
            _edited = true;
        }
    }
}
