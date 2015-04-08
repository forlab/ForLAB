
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace LQT.Core.Domain
{

    public class PLexport
    {

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Export_File
        {

            private File_Header file_HeaderField;

            private Product[] productsField;

            private Record[] recordsField;

            /// <remarks/>
            public File_Header File_Header
            {
                get
                {
                    return this.file_HeaderField;
                }
                set
                {
                    this.file_HeaderField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
            public Product[] Products
            {
                get
                {
                    return this.productsField;
                }
                set
                {
                    this.productsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Record", IsNullable = false)]
            public Record[] Records
            {
                get
                {
                    return this.recordsField;
                }
                set
                {
                    this.recordsField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class File_Header
        {

            private string system_NameField;

            private string fileTypeField;

            private string dtmDataExportedField;

            private string dtmStartField;

            private string dtmEndField;

            private sbyte dblDataIntervalField;

            private string sourceNameField;

            /// <remarks/>
            public string System_Name
            {
                get
                {
                    return this.system_NameField;
                }
                set
                {
                    this.system_NameField = value;
                }
            }

            /// <remarks/>
            public string FileType
            {
                get
                {
                    return this.fileTypeField;
                }
                set
                {
                    this.fileTypeField = value;
                }
            }

            /// <remarks/>
            public string dtmDataExported
            {
                get
                {
                    return this.dtmDataExportedField;
                }
                set
                {
                    this.dtmDataExportedField = value;
                }
            }

            /// <remarks/>
            public string dtmStart
            {
                get
                {
                    return this.dtmStartField;
                }
                set
                {
                    this.dtmStartField = value;
                }
            }

            /// <remarks/>
            public string dtmEnd
            {
                get
                {
                    return this.dtmEndField;
                }
                set
                {
                    this.dtmEndField = value;
                }
            }

            /// <remarks/>
            public sbyte dblDataInterval
            {
                get
                {
                    return this.dblDataIntervalField;
                }
                set
                {
                    this.dblDataIntervalField = value;
                }
            }

            /// <remarks/>
            public string SourceName
            {
                get
                {
                    return this.sourceNameField;
                }
                set
                {
                    this.sourceNameField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class Product
        {

            private string strNameField;

            private string strProductIDField;

            private string sourceField;

            private string userDefinedField;

            private string productGroupField;

            private string innovatorNameField;

            private BaseUOM baseUOMField;

            /// <remarks/>
            public string strName
            {
                get
                {
                    return this.strNameField;
                }
                set
                {
                    this.strNameField = value;
                }
            }

            /// <remarks/>
            public string strProductID
            {
                get
                {
                    return this.strProductIDField;
                }
                set
                {
                    this.strProductIDField = value;
                }
            }

            /// <remarks/>
            public string Source
            {
                get
                {
                    return this.sourceField;
                }
                set
                {
                    this.sourceField = value;
                }
            }

            /// <remarks/>
            public string UserDefined
            {
                get
                {
                    return this.userDefinedField;
                }
                set
                {
                    this.userDefinedField = value;
                }
            }

            /// <remarks/>
            public string ProductGroup
            {
                get
                {
                    return this.productGroupField;
                }
                set
                {
                    this.productGroupField = value;
                }
            }

            /// <remarks/>
            public string InnovatorName
            {
                get
                {
                    return this.innovatorNameField;
                }
                set
                {
                    this.innovatorNameField = value;
                }
            }

            /// <remarks/>
            public BaseUOM BaseUOM
            {
                get
                {
                    return this.baseUOMField;
                }
                set
                {
                    this.baseUOMField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class BaseUOM
        {

            private sbyte lowestUnitQtyField;

            private string lowestUnitMeasureField;

            private sbyte quantificationFactorField;

            /// <remarks/>
            public sbyte LowestUnitQty
            {
                get
                {
                    return this.lowestUnitQtyField;
                }
                set
                {
                    this.lowestUnitQtyField = value;
                }
            }

            /// <remarks/>
            public string LowestUnitMeasure
            {
                get
                {
                    return this.lowestUnitMeasureField;
                }
                set
                {
                    this.lowestUnitMeasureField = value;
                }
            }

            /// <remarks/>
            public sbyte QuantificationFactor
            {
                get
                {
                    return this.quantificationFactorField;
                }
                set
                {
                    this.quantificationFactorField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class Record
        {

            private string strProductIDField;

            private string dtmPeriodField;

            private int lngConsumptionField;

            private sbyte lngAdjustmentsField;

            /// <remarks/>
            public string strProductID
            {
                get
                {
                    return this.strProductIDField;
                }
                set
                {
                    this.strProductIDField = value;
                }
            }

            /// <remarks/>
            public string dtmPeriod
            {
                get
                {
                    return this.dtmPeriodField;
                }
                set
                {
                    this.dtmPeriodField = value;
                }
            }

            /// <remarks/>
            public int lngConsumption
            {
                get
                {
                    return this.lngConsumptionField;
                }
                set
                {
                    this.lngConsumptionField = value;
                }
            }

            /// <remarks/>
            public sbyte lngAdjustments
            {
                get
                {
                    return this.lngAdjustmentsField;
                }
                set
                {
                    this.lngAdjustmentsField = value;
                }
            }
        }
    }
}