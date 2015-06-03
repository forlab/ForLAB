
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
using System.Collections;

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// ForecastSite object for NHibernate mapped table 'ForecastSite'.
	/// </summary>
	public class ForecastSite 
	{
		#region Member Variables
		
		private int _id;
        private int _reportedSiteId;
		private ForlabSite _site;
		private ForecastInfo _forecastInfo;
		private IList<ForecastSiteProduct> _siteProducts;
        private IList<ForecastNRSite> _NRSites;
        private IList<ForecastSiteTest> _siteTests;

		#endregion

		#region Constructors

		public ForecastSite() 
		{
			this._id = -1;
		}

		
		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}
        public virtual int ReportedSiteId
        {
            get { return _reportedSiteId; }
            set { _reportedSiteId = value; }
        }
		public virtual ForlabSite Site
		{
			get { return _site; }
			set { _site = value; }
		}

		public virtual ForecastInfo ForecastInfo
		{
			get { return _forecastInfo; }
			set { _forecastInfo = value; }
		}

		public virtual IList<ForecastSiteProduct> SiteProducts
		{
			get
			{
				if (_siteProducts==null)
				{
					_siteProducts = new List<ForecastSiteProduct>();
				}
				return _siteProducts;
			}
			set { _siteProducts = value; }
		}

        public virtual IList<ForecastNRSite> NoneReportedSites
        {
            get
            {
                if (_NRSites == null)
                {
                    _NRSites = new List<ForecastNRSite>();
                }
                return _NRSites;
            }
            set { _NRSites = value; }
        }

        public virtual IList<ForecastSiteTest> SiteTests
        {
            get
            {
                if (_siteTests == null)
                {
                    _siteTests = new List<ForecastSiteTest>();
                }
                return _siteTests;
            }
            set { _siteTests = value; }
        }

		#endregion
		
        public virtual bool IsProductSlected(int proid)
        {
            foreach (ForecastSiteProduct p in SiteProducts)
            {
                if (p.Product.Id == proid)
                    return true;
            }

            return false;
        }
        public virtual IList<int> GetSelectedProductId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastSiteProduct p in SiteProducts)
            {
                proids.Add(p.Product.Id);
            }
            return proids;
        }

        public virtual ForecastSiteProduct GetSiteProductByproId(int proid)
        {
            foreach (ForecastSiteProduct p in SiteProducts)
            {
                if (p.Product.Id == proid)
                    return p;
            }

            return null;
        }

        public virtual ForecastSiteProduct GetSiteProduct(int fsproid)
        {
            foreach (ForecastSiteProduct p in SiteProducts)
            {
                if (p.Id == fsproid)
                    return p;
            }

            return null;
        }

        public virtual void RemoveFSiteProduct(int fsproid)
        {
            ForecastSiteProduct fp = GetSiteProduct(fsproid);
            if(fp != null)
                SiteProducts.Remove(fp);
        }

        public virtual Consumption ConsumptionByProduct(int proid)
        {
            decimal sum = 0;
            int count = 0;
            foreach (ForecastSiteProduct t in SiteProducts)
            {
                if (t.Product.Id == proid)
                {
                    sum += t.AmountUsed;
                    count++;
                }
            }
            return new Consumption(count, sum);
        }

        public virtual bool IsNRSiteSelected(int siteid)
        {
            foreach (ForecastNRSite s in _NRSites)
            {
                if (s.NReportedSite.Id == siteid)
                    return true;
            }
            return false;
        }

        public virtual IList<int> GetSelectedNRSiteId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastNRSite s in _NRSites)
            {
                proids.Add(s.NReportedSite.Id);
            }
            return proids;
        }
        public virtual ForecastNRSite GetNReportedSite(int nrid)
        {
            foreach (ForecastNRSite s in _NRSites)
            {
                if (s.Id == nrid)
                    return s;
            }
            return null;
        }

        public virtual void RemoveNReportedSite(int nrid)
        {
            ForecastNRSite nr = GetNReportedSite(nrid);
            if (nr != null)
            {
                NoneReportedSites.Remove(nr);
            }
        }

        public virtual IList<MasterProduct> GetUniqFSProduct()
        {
            IList<MasterProduct> temp = new List<MasterProduct>();

            foreach (ForecastSiteProduct p in SiteProducts)
            {
                bool pexist = false;
                for (int i = 0; i < temp.Count; i++)
                {
                    if (p.Product.Id == temp[i].Id)
                    {
                        pexist = true;
                        break;
                    }
                }

                if (!pexist)
                {
                    temp.Add(p.Product);
                }
            }

            return temp;
        }

        public virtual bool TestIsSlected(int testid)
        {
            foreach (ForecastSiteTest p in SiteTests)
            {
                if (p.Test.Id == testid)
                    return true;
            }

            return false;
        }
        
        public virtual IList<int> GetSelectedTestId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastSiteTest p in SiteTests)
            {
                proids.Add(p.Test.Id);
            }
            return proids;
        }

        public virtual ForecastSiteTest GetFSiteTestBytestId(int testid)
        {
            foreach (ForecastSiteTest p in SiteTests)
            {
                if (p.Test.Id == testid)
                    return p;
            }

            return null;
        }

        public virtual ForecastSiteTest GetSiteTest(int id)
        {
            foreach (ForecastSiteTest p in SiteTests)
            {
                if (p.Id == id)
                    return p;
            }

            return null;
        }

        public virtual Consumption ConsumptionByTest(int testid)
        {
            decimal sum = 0;
            int count = 0;
            foreach (ForecastSiteTest t in SiteTests)
            {
                if (t.Test.Id == testid)
                {
                    sum += t.AmountUsed;
                    count++;
                }
            }
            return new Consumption(count, sum);
        }

        public virtual IList<Test> GetUniqTest()
        {
            IList<Test> temp = new List<Test>();

            foreach (ForecastSiteTest p in SiteTests)
            {
                bool pexist = false;
                for (int i = 0; i < temp.Count; i++)
                {
                    if (p.Test.Id == temp[i].Id)
                    {
                        pexist = true;
                        break;
                    }
                }

                if (!pexist)
                {
                    temp.Add(p.Test);
                }
            }

            return temp;
        }

        public virtual IList<ProductType> GetUniqueFSProductType()
        {
            IList<ProductType> temp = new List<ProductType>();

            foreach (ForecastSiteProduct p in SiteProducts)
            {
                bool pexist = false;
                for (int i = 0; i < temp.Count; i++)
                {
                    if (p.Product.ProductType.Id == temp[i].Id)
                    {
                        pexist = true;
                        break;
                    }
                }

                if (!pexist)
                {
                    temp.Add(p.Product.ProductType);
                }
            }

            return temp;
        }

        public virtual IList<TestingArea> GetUniqueFSTestingArea()
        {
            IList<TestingArea> temp = new List<TestingArea>();

            foreach (ForecastSiteTest t in SiteTests)
            {
                bool pexist = false;
                for (int i = 0; i < temp.Count; i++)
                {
                    if (t.Test.TestingArea.Id == temp[i].Id)
                    {
                        pexist = true;
                        break;
                    }
                }

                if (!pexist)
                {
                    temp.Add(t.Test.TestingArea);
                }
            }

            return temp;
        }

        public virtual IList<ForecastSiteProduct> GetFSProduct(int id)
        {
            IList<ForecastSiteProduct> temp = new List<ForecastSiteProduct>();

            foreach (ForecastSiteProduct p in SiteProducts)
            {

                if (p.Product.Id == id)
                {
                    temp.Add(p);
                }

            }

            return temp;
        }

	}

}
