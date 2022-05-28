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
                <DrawingCreationData>
                    <InputData>
                        <Shape_Structure>
                            <StructureUnit>
                                <Index No="0">
                                    <GroundDepth>
                                        <OutSide>
    */

    /*
    <Project>
	    <Products>
		    <WShut3>
				<InputData>
					<WShutData>
						<StratumList>
							<Stratum>
							    <Level>
    */

    static public class editor_012
    {

        /// <summary>
        /// 引張材平面配置_標準ピッチ上段変更
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
            var InputData1 = helper.getXmlElement(DrawingCreationData, "InputData");
            var Shape_Structure = helper.getXmlElement(InputData1, "Shape_Structure");
            var StructureUnit = helper.getXmlElement(Shape_Structure, "StructureUnit");
            var Index1 = helper.getXmlElement(StructureUnit, "Index");
            var GroundDepth = helper.getXmlElement(Index1, "GroundDepth");
            var OutSide = helper.getXmlElement(GroundDepth, "OutSide");

            OutSide.InnerText = value.ToString();


            // 
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var StratumList = helper.getXmlElement(WShutData, "StratumList");
            var Stratum = helper.getXmlElement(StratumList, "Stratum");
            var Level = helper.getXmlElement(Stratum, "Level");

            Level.InnerText = value.ToString("E");

        }



    }
}
