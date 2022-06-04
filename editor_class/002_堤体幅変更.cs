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
						<Shape_Plane>
							<PlaneUnit>
								<Index No="0">
									<Between>
    */

    /*
    <Project>
	    <Products>
		    <WShut3>
			    <InputData>
				    <WShutData>
					    <Decision>
						    <DamBodyWidth>
    */

    static public class editor_002
    {
        /// <summary>
        /// 堤体幅変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="_DamBodyWidth">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double _DamBodyWidth)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");

            // 
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData1 = helper.getXmlElement(DrawingCreationData, "InputData");
            var Shape_Plane = helper.getXmlElement(InputData1, "Shape_Plane");
            var PlaneUnit = helper.getXmlElement(Shape_Plane, "PlaneUnit");
            var Index = helper.getXmlElement(PlaneUnit, "Index");
            var Between = helper.getXmlElement(Index, "Between");

            Between.InnerText = _DamBodyWidth.ToString();


            // 
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Decision = helper.getXmlElement(WShutData, "Decision");

            var DamBodyWidth = helper.getXmlElement(Decision, "DamBodyWidth");
            DamBodyWidth.InnerText = _DamBodyWidth.ToString("E");
        }
    }
}
