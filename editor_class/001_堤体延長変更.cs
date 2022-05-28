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
                                    <Width>
    */

    static public class editor_001
    {


        /// <summary>
        /// 堤体の延長を変更する
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double value )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData = helper.getXmlElement(DrawingCreationData, "InputData");
            var Shape_Plane = helper.getXmlElement(InputData, "Shape_Plane");
            var PlaneUnit = helper.getXmlElement(Shape_Plane, "PlaneUnit");
            var Index = helper.getXmlElement(PlaneUnit, "Index");
            var Width = helper.getXmlElement(Index, "Width");

            Width.InnerText = value.ToString();

        }



    }
}
