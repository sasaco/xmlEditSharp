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
                                    <MomentAlp>

    */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <Wall>
                            <SteelSheetPile>
                                <SideList>
                                     <SectionModulusAlp>
     */
     
    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <Wall>
                            <SteelSheetPile>
                                <CorrosionExcvT2>

     */
     
    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <Wall>
                            <SteelSheetPile>
                                <CorrosionBackT1>

     */

    static public class editor_019
    {
        /// <summary>
        /// 部材壁体鋼矢板の有効率変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double value)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData, "WShutData");
            var Wall = helper.getXmlElement(WShutData, "Wall");
            var SteelSheetPile = helper.getXmlElement(Wall, "SteelSheetPile");

            // 
            var MomentAlp = helper.getXmlElement(SteelSheetPile, "MomentAlp");
            MomentAlp.InnerText = value.ToString("E");

            // 
            var SectionModulusAlp = helper.getXmlElement(SteelSheetPile, "SectionModulusAlp");
            SectionModulusAlp.InnerText = value.ToString("E");
            
            // 
            var CorrosionExcvT2 = helper.getXmlElement(SteelSheetPile, "CorrosionExcvT2");
            CorrosionExcvT2.InnerText = value.ToString("E");
            
            // 
            var CorrosionBackT1 = helper.getXmlElement(SteelSheetPile, "CorrosionBackT1");
            CorrosionBackT1.InnerText = value.ToString("E");


        }
    }
}
