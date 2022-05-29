using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    /*
    <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <CaseList>
                            <Case>
                                <LandSideN>

    */

    static public class editor_028
    {


        /// <summary>
        /// 常時鉛直力を変更する。
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double value )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData = helper.getXmlElement(WShut3", "InputData");
            var WShutData = helper.getXmlElement(InputData, "WShutData");
            var CaseList = helper.getXmlElement(WShutData, "CaseList");
            var Case = helper.getXmlElement(CaseList, "Case");
            var LandSideN = helper.getXmlElement(Case, "LandSideN");

            LandSideN = value.ToString("E");

        }



    }
}
