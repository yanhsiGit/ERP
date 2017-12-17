using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace My
{
    public class MyXML
    {
        /// <summary>
        /// get XML value for Single value (Overloading)
        /// </summary>
        /// <param name="doc">XElement Type</param>
        /// <param name="parent">Parent element name</param>
        /// <param name="getValueElementName">You need get Value of ElementName</param>
        /// <returns></returns>
        public static string getXMLValue(XElement doc, string parent, string getValueElementName)
        {
            try
            {
                var query = from c in doc.Descendants(parent)
                            where c.Element(getValueElementName).ToString() != ""
                            select c.Element(getValueElementName);

                string result = "";
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        result = obj.Value;
                    }
                }

                return result;
                //Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }


        /// <summary>
        /// get XML value for Multiple value (Overloading) 
        /// for example: string[] strArray = headerHandler.getXMLValue(doc, "BasicInfo", "SellerPartNumber",true);
        /// </summary>
        /// <param name="doc">XElement Type</param>
        /// <param name="parent">Parent element name</param>
        /// <param name="getValueElementName">You need get Value of ElementName</param>
        /// <param name="IsMultiElements">Is return Multiple Value , If true is return multiple value by array</param>
        /// <returns>return string array</returns>
        public static string[] getXMLValue(XElement doc, string parent, string getValueElementName, bool IsMultiElements)
        {
            try
            {
                var query = from c in doc.Descendants(parent)
                            where c.Element(getValueElementName).ToString() != ""
                            select c.Element(getValueElementName);


                string[] result;
                if (IsMultiElements == true)
                {
                    //Limit MaxItem is 10000
                    result = new string[10000];
                }
                else
                {
                    result = new string[1];
                }

                int i = 0;
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        result[i] = obj.Value;
                        i = i + 1;
                    }
                }
                //Resize to real array size , reduce to consume of memory
                Array.Resize(ref result, i);

                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }

        }

        /// <summary>
        /// get XML value for Single value (Overloading) 
        /// </summary>
        /// <param name="doc">XElement Type</param>
        /// <param name="first">first layer</param>
        /// <param name="second">second layer</param>
        /// <param name="getValueElementName">You need get Value of ElementName</param>
        /// <returns></returns>
        public static string getXMLValue(XElement doc, string first, string second, string getValueElementName)
        {
            try
            {
                var query = from c in doc.Element(first).Elements(second)
                            where c.Element(getValueElementName).ToString() != ""
                            select c.Element(getValueElementName);

                string result = "";
                if (query != null)
                {
                    foreach (var obj in query)
                    {
                        result = obj.Value;
                    }
                }

                //Console.WriteLine(result);
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }


        }

        /// <summary>
        /// get XML Value By ColumnName - Modify by Kevin.C.Hsu on 2012/07/17 for 21409
        /// </summary>
        /// <param name="xDoc"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string getXMLValueByColumnName(XDocument xDoc, string columnName)
        {
            var query = from c in xDoc.Element("CellSet").Element("Row").Elements("Cell")
                        where
                        c.Attribute("column").Value.IndexOf(columnName) != -1
                        select c;
            string result = "";
            foreach (var obj in query)
            {
                if (obj != null)
                {
                    result = obj.Value;
                    break;
                }
            }
            return result;
        }

        /// <summary> 
        /// get XML Value By ColumnName - Modify by Peggy.J.Huang on 2012/09/11 for 21409 
        /// </summary> 
        /// <param name="RowElement"></param> 
        /// <param name="columnName"></param> 
        /// <returns></returns> 

        public static string getXMLValueByColumnName(XElement rowElement, string columnName)
        {
            var query = from c in rowElement.Elements("Cell")
                        where
                        c.Attribute("column").Value.IndexOf(columnName) != -1
                        select c;
            string result = "";
            foreach (var obj in query)
            {
                if (obj != null)
                {
                    result = obj.Value;
                    break;
                }
            }
            return result;
        }
    }
}
