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
                                <LandsideHWL>

    */

    /*
    <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <CaseList>
                            <Case>
                                <LandsideLWL>

    */

    static public class editor_027
    {
        /// <summary>
        /// 常時の水位条件変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="HWL">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double HWL, double LWL)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData, "WShutData");
            var CaseList = helper.getXmlElement(WShutData, "CaseList");
            var Case = helper.getXmlElement(CaseList, "Case");

            // 

            var LandsideHWL = helper.getXmlElement(Case, "LandsideHWL");

            LandsideHWL.InnerText = HWL.ToString("E");


            // 
            var LandsideLWL = helper.getXmlElement(Case, "LandsideLWL");
            

            LandsideLWL.InnerText = LWL.ToString("E");

        }
    }
}
