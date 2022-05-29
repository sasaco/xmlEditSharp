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
							    <SideList>
							        <SteelSheetPileOneSide>
                                        <UseSteelNo>
                                    <SteelSheetPileOneSide>
                                        <UseSteelNo>

                                <CorrosionBackT1>
                                <CorrosionExcvT2>
    */

    static public class editor_020
    {

        /// <summary>
        /// 引張材平面配置_標準ピッチ上段変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, int _UseSteelNo,
            double _CorrosionBackT1, double _CorrosionExcvT2)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Wall = helper.getXmlElement(WShutData, "Wall");
            var SteelSheetPile = helper.getXmlElement(Wall, "SteelSheetPile");

            var SideList = helper.getXmlElement(SteelSheetPile, "SideList");
            foreach (var SteelSheetPileOneSide in SideList.GetElementsByTagName("SteelSheetPileOneSide"))
            {
                var UseSteelNo = helper.getXmlElement((XmlElement)SteelSheetPileOneSide, "UseSteelNo");
                UseSteelNo.InnerText = _UseSteelNo.ToString();
            }


            var CorrosionBackT1 = helper.getXmlElement(SteelSheetPile, "CorrosionBackT1");
            var CorrosionExcvT2 = helper.getXmlElement(SteelSheetPile, "CorrosionExcvT2");

            CorrosionBackT1.InnerText = _CorrosionBackT1.ToString("E");
            CorrosionExcvT2.InnerText = _CorrosionExcvT2.ToString("E");

        }



    }
}
