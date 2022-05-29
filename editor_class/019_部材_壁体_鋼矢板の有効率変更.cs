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
						<Wall>
							<SteelSheetPile>
							    <MomentAlp>
							    <SectionModulusAlp>

                                <CorrosionBackT1>
                                <CorrosionExcvT2>
    */

    static public class editor_019
    {

        /// <summary>
        /// 引張材平面配置_標準ピッチ上段変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double _MomentAlp, double _SectionModulusAlp)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Wall = helper.getXmlElement(WShutData, "Wall");
            var SteelSheetPile = helper.getXmlElement(Wall, "SteelSheetPile");
            
            var MomentAlp = helper.getXmlElement(SteelSheetPile, "MomentAlp");
            var SectionModulusAlp = helper.getXmlElement(SteelSheetPile, "SectionModulusAlp");

            MomentAlp.InnerText = _MomentAlp.ToString("E");
            SectionModulusAlp.InnerText = _SectionModulusAlp.ToString("E");


            var CorrosionBackT1 = helper.getXmlElement(SteelSheetPile, "CorrosionBackT1");
            var CorrosionExcvT2 = helper.getXmlElement(SteelSheetPile, "CorrosionExcvT2");

            CorrosionBackT1.InnerText = _MomentAlp.ToString("E");
            CorrosionExcvT2.InnerText = _SectionModulusAlp.ToString("E");

        }



    }
}
