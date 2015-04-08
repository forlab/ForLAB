
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

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// ForecastCategory object for NHibernate mapped table 'ForecastCategory'.
	/// </summary>
	public class ForecastCategory 
	{
		#region Member Variables
		
		private int _id;
		private string _categoryName;
		private ForecastInfo _forecast;
		private IList<ForecastCategorySite> _catsites;
		private IList<ForecastCategoryProduct> _catproducts;
        private IList<ForecastCategoryTest> _ctegoryTests;
		#endregion

		#region Constructors

		public ForecastCategory() 
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

		public virtual string CategoryName
		{
			get { return _categoryName; }
			set
			{
				if ( value != null && value.Length > 32)
					throw new ArgumentOutOfRangeException("Invalid value for CategoryName", value, value.ToString());
				_categoryName = value;
			}
		}

		public virtual ForecastInfo ForecastInfo
		{
			get { return _forecast; }
			set { _forecast = value; }
		}

		public virtual IList<ForecastCategorySite> CategorySites
		{
			get
			{
				if (_catsites==null)
				{
					_catsites = new List<ForecastCategorySite>();
				}
				return _catsites;
			}
			set { _catsites = value; }
		}

		public virtual IList<ForecastCategoryProduct> CategoryProducts
		{
			get
			{
				if (_catproducts==null)
				{
					_catproducts = new List<ForecastCategoryProduct>();
				}
				return _catproducts;
			}
			set { _catproducts = value; }
		}

        public virtual IList<ForecastCategoryTest> CategoryTests
        {
            get
            {
                if (_ctegoryTests == null)
                {
                    _ctegoryTests = new List<ForecastCategoryTest>();
                }
                return _ctegoryTests;
            }
            set { _ctegoryTests = value; }
        }
		#endregion
        
        public virtual ForecastCategoryProduct GetFCatProduct(int id)
        {
            foreach (ForecastCategoryProduct p in CategoryProducts)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        public virtual ForecastCategoryProduct GetFCatProduct(int id, string duration)
        {
            foreach (ForecastCategoryProduct p in CategoryProducts)
            {
                if (p.Product.Id == id && p.CDuration == duration)
                    return p;
            }
            return null;
        }

        public virtual Consumption ConsumptionByProduct(int proid)
        {
            decimal sum = 0;
            int count = 0;
            foreach (ForecastCategoryProduct t in CategoryProducts)
            {
                if (t.Product.Id == proid)
                {
                    sum += t.AmountUsed;
                    count++;
                }
            }
            return new Consumption(count, sum);
        }

        public virtual ForecastCategorySite GetFCatSite(int id)
        {
            foreach (ForecastCategorySite s in CategorySites)
            {
                if (s.Id == id)
                    return s;
            }
            return null;
        }

        public virtual ForecastCategoryTest GetFCatTest(int id)
        {
            foreach (ForecastCategoryTest t in CategoryTests)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        public virtual ForecastCategoryTest GetFCatTest(int testid, string duration)
        {
            foreach (ForecastCategoryTest t in CategoryTests)
            {
                if (t.Test.Id == testid && t.CDuration == duration)
                    return t;
            }
            return null;
        }
        public virtual Consumption ConsumptionByTest(int testid)
        {
            decimal sum = 0;
            int count = 0;
            foreach (ForecastCategoryTest t in CategoryTests)
            {
                if (t.Test.Id == testid)
                {
                    sum += t.AmountUsed;
                    count++;
                }
            }
            return new Consumption(count, sum);
        }

        public virtual bool SiteIsSelected(int siteid)
        {
            foreach (ForecastCategorySite s in CategorySites)
            {
                if (s.Site.Id == siteid)
                    return true;
            }
            return false;
        }

        public virtual IList<int> GetSelectedSiteId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastCategorySite s in CategorySites)
            {
                proids.Add(s.Site.Id);
            }
            return proids;
        }

        public virtual bool ProductIsSelected(int proid)
        {
            foreach (ForecastCategoryProduct p in CategoryProducts)
            {
                if (p.Product.Id == proid)
                    return true;
            }
            return false;
        }
        
        public virtual IList<int> GetSelectedProductId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastCategoryProduct p in CategoryProducts)
            {
                proids.Add(p.Product.Id);
            }
            return proids;
        }

        public virtual IList<MasterProduct> GetUniqFSProduct()
        {
            IList<MasterProduct> temp = new List<MasterProduct>();

            foreach (ForecastCategoryProduct p in CategoryProducts)
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

        public virtual bool TsetIsSelected(int testid)
        {
            foreach (ForecastCategoryTest p in CategoryTests)
            {
                if (p.Test.Id == testid)
                    return true;
            }
            return false;
        }

        public virtual IList<int> GetSelectedTestId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastCategoryTest p in CategoryTests)
            {
                proids.Add(p.Test.Id);
            }
            return proids;
        }

        public virtual IList<Test> GetUniqFCTest()
        {
            IList<Test> temp = new List<Test>();

            foreach (ForecastCategoryTest p in CategoryTests)
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

        public virtual IList<ProductType> GetUniqueFCProductType()
        {
            IList<ProductType> temp = new List<ProductType>();

            foreach (ForecastCategoryProduct p in CategoryProducts)
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

        public virtual IList<TestingArea> GetUniqueFCTestingArea()
        {
            IList<TestingArea> temp = new List<TestingArea>();

            foreach (ForecastCategoryTest t in CategoryTests)
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
        public virtual IList<ForecastCategoryProduct> GetFCProduct(int id)
        {
            IList<ForecastCategoryProduct> temp = new List<ForecastCategoryProduct>();

            foreach (ForecastCategoryProduct p in CategoryProducts)
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
