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
                                    <Tai>
                                        <TaiUnit>
                                            <Index No="0">
                                                <Interval>
    */

    /*
    <Project>
	    <Products>
		    <WShut3>
				<InputData>
					<WShutData>
						<Shape>
							<BodyDataList>
							    <BodyData>
							        <TierodDataList>
							            <TierodData>
							                <NormalPitch>
    */

    static public class editor_011
    {

        /// <summary>
        /// 引張材平面配置_標準ピッチ上段変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="_Interval">間隔</param>
        /// <param name="_PosDepth">深さ位置</param>
        static public void Edit(XmlDocument xmlDoc, double _Interval, double _PosDepth)
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
            var Tai = helper.getXmlElement(Index1, "Tai");
            var TaiUnit = helper.getXmlElement(Tai, "TaiUnit");
            var Index2 = helper.getXmlElement(TaiUnit, "Index", 1);

            var Interval = helper.getXmlElement(Index2, "Interval");
            Interval.InnerText = _Interval.ToString();

            var PosDepth = helper.getXmlElement(Index2, "PosDepth");
            PosDepth.InnerText = _PosDepth.ToString();

            // 
            var InputData2 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData2, "WShutData");
            var Shape = helper.getXmlElement(WShutData, "Shape");
            var BodyDataList = helper.getXmlElement(Shape, "BodyDataList");
            var BodyData = helper.getXmlElement(BodyDataList, "BodyData");
            var TierodDataList = helper.getXmlElement(BodyData, "TierodDataList");
            var TierodData = helper.getXmlElement(TierodDataList, "TierodData", 1);
            var NormalPitch = helper.getXmlElement(TierodData, "NormalPitch");

            NormalPitch.InnerText = _Interval.ToString("E");


            var InputData = helper.getXmlElement(WShut3, "InputData");
            var WShutData1 = helper.getXmlElement(InputData, "WShutData");
            var TensionMember = helper.getXmlElement(WShutData1, "TensionMember");
            var MemberList = helper.getXmlElement(TensionMember, "MemberList");
            var Member = helper.getXmlElement(MemberList, "Member", 1);
            var Level = helper.getXmlElement(Member, "Level");

            Level.InnerText = _PosDepth.ToString("E");
        }



    }
}
