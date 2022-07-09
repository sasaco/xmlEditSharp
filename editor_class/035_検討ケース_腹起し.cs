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
                        <Decision>
                            <WalingList>
                                <DecisionWaling>
    */

    static public class editor_035
    {


        /// <summary>
        /// 地震時鉛直力を変更する
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double value )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");

            // 
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Decision = helper.getXmlElement(WShutData, "Decision");

            var WalingList = helper.getXmlElement(Decision, "WalingList");
            var DecisionWaling = helper.getXmlElement(WalingList, "DecisionWaling");
            var UseWalingNo = helper.getXmlElement(DecisionWaling, "UseWalingNo");

            UseWalingNo.InnerText = value.ToString();
        }



    }
}
