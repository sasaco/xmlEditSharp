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
                                    <OutSideWall>
                                        <TopDepth>
    */

    /*
    <Project>
	    <Products>
		    <WShut3>
				<InputData>
					<WShutData>
						<Shape>
							<WaterSideLevel>
    */

    static public class editor_004
    {

        /// <summary>
        /// 堤外側矢板天端高変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="_TopDepth">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double _TopDepth, double _Length)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");

            // 
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData1 = helper.getXmlElement(DrawingCreationData, "InputData");
            var Shape_Structure = helper.getXmlElement(InputData1, "Shape_Structure");
            var StructureUnit = helper.getXmlElement(Shape_Structure, "StructureUnit");
            var Index = helper.getXmlElement(StructureUnit, "Index");
            var OutSideWall = helper.getXmlElement(Index, "OutSideWall");
            var TopDepth = helper.getXmlElement(OutSideWall, "TopDepth");

            TopDepth.InnerText = _TopDepth.ToString();

            var Length = helper.getXmlElement(OutSideWall, "Length");
            Length.InnerText = _Length.ToString();

            // 
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Shape = helper.getXmlElement(WShutData, "Shape");
            var WaterSideLevel = helper.getXmlElement(Shape, "WaterSideLevel");

            WaterSideLevel.InnerText = _TopDepth.ToString("E");

            // 
            var Decision = helper.getXmlElement(WShutData, "Decision");

            var WaterSideLength = helper.getXmlElement(Decision, "WaterSideLength");
            WaterSideLength.InnerText = _Length.ToString("E");
        }



    }
}
