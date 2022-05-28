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
                                    <InSideWall>
                                        <TopDepth>
    */

    /*
    <Project>
	    <Products>
		    <WShut3>
				<InputData>
					<WShutData>
						<Shape>
							<LandSideLevel>
    */

    static public class editor_003
    {

        /// <summary>
        /// 堤内側矢板天端高変更
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
            var Index = helper.getXmlElement(StructureUnit, "Index");
            var InSideWall = helper.getXmlElement(Index, "InSideWall");
            var TopDepth = helper.getXmlElement(InSideWall, "TopDepth");

            TopDepth.InnerText = value.ToString();


            // 
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Shape = helper.getXmlElement(WShutData, "Shape");
            var LandSideLevel = helper.getXmlElement(Shape, "LandSideLevel");

            LandSideLevel.InnerText = value.ToString("E");

        }



    }
}
