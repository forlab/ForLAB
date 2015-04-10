
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
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class RapidTestAlgorithm
    {
        private AlgorithmType _algorithm;
        //private IList<RapidTestSpec> _rapidTests;
        private double[,] _screening = new double[3, 7];     //0 => TestSensitivity 1 => TestSpecificity
        private double[,] _confirmatory = new double[3, 7];
        private double[,] _tiebreaker = new double[3, 7];

        private ForlabParameter _paramNegative;
        private ForlabParameter _paramPositive;
        private ForlabParameter _paramDiscordant;

        public RapidTestAlgorithm(AlgorithmType algorithm)
        {
            _algorithm = algorithm;
            _paramNegative = DataRepository.GetForlabParameterByParamName("RulesBothNegative");
            _paramPositive = DataRepository.GetForlabParameterByParamName("RulesBothPositive");
            _paramDiscordant = DataRepository.GetForlabParameterByParamName("RulesDiscordant");
            InitTestSpec();
        }

        private void InitTestSpec()
        {
            for (int i = 0; i < 3; i++)
            {
                _screening[i, 0] = 0d;
                _screening[i, 1] = 0d;
                _screening[i, 2] = 0d;
                _screening[i, 3] = 0d;

                _confirmatory[i, 0] = 0d;
                _confirmatory[i, 1] = 0d;
                _confirmatory[i, 2] = 0d;
                _confirmatory[i, 3] = 0d;

                _tiebreaker[i, 0] = 0d;
                _tiebreaker[i, 1] = 0d;
                _tiebreaker[i, 2] = 0d;
                _tiebreaker[i, 3] = 0d;
            }

            if (_algorithm == AlgorithmType.Serial)
            {
                foreach (RapidTestSpec rs in DataRepository.GetAllRapidTestSpec())
                {
                    switch (rs.TestGroupEnum)
                    {
                        case TestingSpecificationGroup.Screening:
                            _screening[rs.ProductOrder - 1, 0] = rs.SerialFalseNegative / 100d;
                            _screening[rs.ProductOrder - 1, 1] = rs.SerialFalsePositive / 100d;
                            _screening[rs.ProductOrder - 1, 2] = rs.SerialTestSensitivity / 100d;
                            _screening[rs.ProductOrder - 1, 3] = rs.SerialTestSpecificity / 100d;
                            _screening[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _screening[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _screening[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                        case TestingSpecificationGroup.Confirmatory:
                            _confirmatory[rs.ProductOrder - 1, 0] = rs.SerialFalseNegative / 100d;
                            _confirmatory[rs.ProductOrder - 1, 1] = rs.SerialFalsePositive / 100d;
                            _confirmatory[rs.ProductOrder - 1, 2] = rs.SerialTestSensitivity / 100d;
                            _confirmatory[rs.ProductOrder - 1, 3] = rs.SerialTestSpecificity / 100d;
                            _confirmatory[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _confirmatory[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _confirmatory[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                        case TestingSpecificationGroup.Tie_Breaker:
                            _tiebreaker[rs.ProductOrder - 1, 0] = rs.SerialFalseNegative / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 1] = rs.SerialFalsePositive / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 2] = rs.SerialTestSensitivity / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 3] = rs.SerialTestSpecificity / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _tiebreaker[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _tiebreaker[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                    }
                }
            }
            else
            {
                foreach (RapidTestSpec rs in DataRepository.GetAllRapidTestSpec())
                {
                    switch (rs.TestGroupEnum)
                    {
                        case TestingSpecificationGroup.Screening:
                            _screening[rs.ProductOrder - 1, 0] = rs.ParallelFalseNegative / 100d;
                            _screening[rs.ProductOrder - 1, 1] = rs.ParallelFalsePositive / 100d;
                            _screening[rs.ProductOrder - 1, 2] = rs.ParallelTestSensitivity / 100d;
                            _screening[rs.ProductOrder - 1, 3] = rs.ParallelTestSpecificity / 100d;
                            _screening[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _screening[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _screening[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                        case TestingSpecificationGroup.Confirmatory:
                            _confirmatory[rs.ProductOrder - 1, 0] = rs.ParallelFalseNegative / 100d;
                            _confirmatory[rs.ProductOrder - 1, 1] = rs.ParallelFalsePositive / 100d;
                            _confirmatory[rs.ProductOrder - 1, 2] = rs.ParallelTestSensitivity / 100d;
                            _confirmatory[rs.ProductOrder - 1, 3] = rs.ParallelTestSpecificity / 100d;
                            _confirmatory[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _confirmatory[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _confirmatory[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                        case TestingSpecificationGroup.Tie_Breaker:
                            _tiebreaker[rs.ProductOrder - 1, 0] = rs.ParallelFalseNegative / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 1] = rs.ParallelFalsePositive / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 2] = rs.ParallelTestSensitivity / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 3] = rs.ParallelTestSpecificity / 100d;
                            _tiebreaker[rs.ProductOrder - 1, 4] = rs.GetProductId();
                            _tiebreaker[rs.ProductOrder - 1, 5] = rs.UsageRate;
                            _tiebreaker[rs.ProductOrder - 1, 6] = rs.GetProductPackSize();
                            break;
                    }
                }
            }
        }

        public double ScreeningTestSensitivty(int proLine)
        {
           return _screening[proLine-1, 2];
        }
        public double ConfirmatoryTestSpecificity(int proLine)
        {
            return _confirmatory[proLine - 1, 3];
        }

        public double ConfirmatoryTestSensitivty(int proLine)
        {
            return _confirmatory[proLine - 1, 2];
        }
        public double ScreeningTestSpecificity(int proLine)
        {
            return _screening[proLine - 1, 3];
        }
        public double TiebreakerTestSensitivty(int proLine)
        {
            return _tiebreaker[proLine - 1, 2];
        }
        public double TiebreakerTestSpecificity(int proLine)
        {
            return _tiebreaker[proLine - 1, 3];
        }
        public double ScreeningTestFalseNegative(int proLine)
        {
            return _screening[proLine - 1, 0];
        }

        public double ScreeningTestFalsePositive(int proLine)
        {
            return _screening[proLine - 1, 1];
        }

        public double ConfirmatoryTestFalseNegative(int proLine)
        {
            return _confirmatory[proLine - 1, 0];
        }

        public double ConfirmatoryTestFalsePositive(int proLine)
        {
            return _confirmatory[proLine - 1, 1];
        }

        public double TieBreakerTestFalseNegative(int proLine)
        {
            return _tiebreaker[proLine - 1, 0];
        }

        public double TieBreakerTestFalsePositive(int proLine)
        {
            return _tiebreaker[proLine - 1, 1];
        }

        public bool BothNegativeProceed
        {
            get { return _paramNegative.ParmValue == "Proceed"; }
        }

        public bool BothPositiveProceed
        {
            get { return _paramPositive.ParmValue == "Proceed"; }
        }

        public bool DiscordantProceed
        {
            get { return _paramDiscordant.ParmValue == "Proceed"; }
        }
        public int GetProductId(TestingSpecificationGroup tgroup, int proLine)
        {
            int result = 0;
            switch (tgroup)
            {
                case TestingSpecificationGroup.Screening:
                    result = Convert.ToInt32(_screening[proLine - 1, 4]);
                    break;
                case TestingSpecificationGroup.Confirmatory:
                    result = Convert.ToInt32(_confirmatory[proLine - 1, 4]);
                    break;
                case TestingSpecificationGroup.Tie_Breaker:
                    result = Convert.ToInt32(_tiebreaker[proLine - 1, 4]);
                    break;
            }
            return result;
        }
        public double GetUsageRate(TestingSpecificationGroup tgroup, int proLine)
        {
            double result = 0;
            switch (tgroup)
            {
                case TestingSpecificationGroup.Screening:
                    result = _screening[proLine - 1, 5];
                    break;
                case TestingSpecificationGroup.Confirmatory:
                    result = _confirmatory[proLine - 1, 5];
                    break;
                case TestingSpecificationGroup.Tie_Breaker:
                    result = _tiebreaker[proLine - 1, 5];
                    break;
            }
            return result;
        }

        public double GetPackSize(TestingSpecificationGroup tgroup, int proLine)
        {
            double result = 0;
            switch (tgroup)
            {
                case TestingSpecificationGroup.Screening:
                    result = _screening[proLine - 1, 6];
                    break;
                case TestingSpecificationGroup.Confirmatory:
                    result = _confirmatory[proLine - 1, 6];
                    break;
                case TestingSpecificationGroup.Tie_Breaker:
                    result = _tiebreaker[proLine - 1, 6];
                    break;
            }
            return result;
        }

        public IList<int> GetAllProductIds()
        {
            IList<int> proIds = new List<int>();

            for (int i = 1; i <= 3; i++)
            {
                int pidS = GetProductId(TestingSpecificationGroup.Screening, i);
                if (pidS > 0)
                    proIds.Add(pidS);
                
                int pidC = GetProductId(TestingSpecificationGroup.Confirmatory, i);
                if (pidC > 0)
                    proIds.Add(pidC);
             
                int pidT = GetProductId(TestingSpecificationGroup.Tie_Breaker, i);
                if (pidT > 0)
                    proIds.Add(pidT);
            }
            return proIds;
        }
    }
}
