
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Util;

namespace LQT.Core.Domain
{

    /// <summary>
    /// Site object for NHibernate mapped table 'Fr_Site'.
    /// </summary>
    public class ForlabSite
    {
        #region Member Variables

        private int _id;
        private string _siteName;
        private int _cD4TestingDaysPerMonth;
        private int _chemistryTestingDaysPerMonth;
        private int _hematologyTestingDaysPerMonth;
        private int _viralLoadTestingDaysPerMonth;
        private int _otherTestingDaysPerMonth;
        private ForlabRegion _region;
        private IList<SiteStatus> _siteStatuses;
        private IList<SiteInstrument> _siteInstruments;
        private SiteCategory _siteCategory;
        private int _cD4RefSite;
        private int _chemistryRefSite;
        private int _hematologyRefSite;
        private int _viralLoadRefSite;
        private int _otherRefSite;
        private int _workingDays;
        private string _siteLeve;
        #endregion

        #region Constructors

        public ForlabSite()
        {
            this._id = -1;
        }


        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string SiteName
        {
            get { return _siteName; }
            set
            {
                if (value != null && value.Length > 64)
                    throw new ArgumentOutOfRangeException("Invalid value for SiteName", value, value.ToString());
                _siteName = value;
            }
        }

        public virtual int CD4TestingDaysPerMonth
        {
            get { return _cD4TestingDaysPerMonth; }
            set { _cD4TestingDaysPerMonth = value; }
        }

        public virtual int ChemistryTestingDaysPerMonth
        {
            get { return _chemistryTestingDaysPerMonth; }
            set { _chemistryTestingDaysPerMonth = value; }
        }

        public virtual int HematologyTestingDaysPerMonth
        {
            get { return _hematologyTestingDaysPerMonth; }
            set { _hematologyTestingDaysPerMonth = value; }
        }

        public virtual int ViralLoadTestingDaysPerMonth
        {
            get { return _viralLoadTestingDaysPerMonth; }
            set { _viralLoadTestingDaysPerMonth = value; }
        }

        public virtual int OtherTestingDaysPerMonth
        {
            get { return _otherTestingDaysPerMonth; }
            set { _otherTestingDaysPerMonth = value; }
        }

        public virtual ForlabRegion Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public virtual SiteCategory SiteCategory
        {
            get { return _siteCategory; }
            set { _siteCategory = value; }
        }

        public virtual IList<SiteStatus> SiteStatuses
        {
            get
            {
                if (_siteStatuses == null)
                {
                    _siteStatuses = new List<SiteStatus>();
                }
                return _siteStatuses;
            }
            set { _siteStatuses = value; }
        }

        public virtual IList<SiteInstrument> SiteInstruments
        {
            get
            {
                if (_siteInstruments == null)
                    _siteInstruments = new List<SiteInstrument>();
                return _siteInstruments;
            }
            set { _siteInstruments = value; }
        }

        public virtual int CD4RefSite
        {
            get { return _cD4RefSite; }
            set { _cD4RefSite = value; }
        }

        public virtual int ChemistryRefSite
        {
            get { return _chemistryRefSite; }
            set { _chemistryRefSite = value; }
        }

        public virtual int HematologyRefSite
        {
            get { return _hematologyRefSite; }
            set { _hematologyRefSite = value; }
        }

        public virtual int ViralLoadRefSite
        {
            get { return _viralLoadRefSite; }
            set { _viralLoadRefSite = value; }
        }

        public virtual int OtherRefSite
        {
            get { return _otherRefSite; }
            set { _otherRefSite = value; }
        }

        public virtual int WorkingDays
        {
            get { return _workingDays; }
            set
            {
                if (value == 0)
                    _workingDays = 22;
                else
                    _workingDays = value;
            }
        }

        public virtual string SiteLevel
        {
            get { return _siteLeve; }
            set { _siteLeve = value; }
        }

        #endregion

        public virtual bool CurrentlyOpen
        {
            get
            {
                foreach (SiteStatus ss in this.SiteStatuses)
                {
                    if (ss.ClosedOn == null)
                        return true;
                }
                return false;
            }
        }

        public virtual DateTime GetLastOpenDate
        {
            get
            {
                int count = SiteStatuses.Count;
                if (count > 0)
                    return ((SiteStatus)SiteStatuses[count - 1]).OpenedFrom;

                return DateTime.Now;
            }
        }

        public virtual DateTime? GetLastClosedDate
        {
            get
            {
                int count = SiteStatuses.Count;
                if (count > 0)
                    return ((SiteStatus)SiteStatuses[count - 1]).ClosedOn;

                return null;
            }
        }

        public virtual SiteStatus GetSiteStatusById(int id)
        {
            foreach (SiteStatus ss in SiteStatuses)
            {
                if (ss.Id == id)
                    return ss;
            }
            return null;
        }

        public virtual SiteInstrument GetSiteInstrumentById(int id)
        {
            foreach (SiteInstrument s in SiteInstruments)
            {
                if (s.Id == id)
                    return s;
            }
            return null;
        }

        public virtual SiteInstrument GetSiteInstrumentByInsId(int instrumentid)
        {
            foreach (SiteInstrument s in SiteInstruments)
            {
                if (s.Instrument.Id == instrumentid)
                    return s;
            }
            return null;
        }

        public virtual IList<SiteInstrument> GetInstrumentByPlatform(ClassOfMorbidityTestEnum p)
        {
            IList<SiteInstrument> i = new List<SiteInstrument>();

            foreach (SiteInstrument si in this.SiteInstruments)
            {
                if (si.Instrument.TestingArea.Category == p.ToString())
                    i.Add(si);
            }
            return i;
        }

        public virtual int MaxWorkingDays()
        {
            int maxday = _cD4TestingDaysPerMonth;
            if (maxday < _chemistryTestingDaysPerMonth)
                maxday = _chemistryTestingDaysPerMonth;
            if (maxday < _hematologyTestingDaysPerMonth)
                maxday = _hematologyTestingDaysPerMonth;
            if (maxday < _viralLoadTestingDaysPerMonth)
                maxday = _viralLoadTestingDaysPerMonth;
            return maxday;
        }
    }

}
