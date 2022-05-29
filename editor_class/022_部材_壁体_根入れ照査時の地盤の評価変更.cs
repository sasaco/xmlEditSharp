﻿using System;
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
                                        <EmbedmentSoilValue>

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
                                    <SteelSheetPileOneSide>
                                        <EmbedmentSoilValue>
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

    static public class editor_022
    {
        /// <summary>
        /// 部材壁体根入れ照査時の地盤の評価変更.cs
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
            var SteelSheetPile = helper.getXmlElement(Wall, "SteelSheetPile",3);

            // 

            var SideList = helper.getXmlElement(SteelSheetPile, "SideList");
            var SteelSheetPileOneSide = helper.getXmlElement(SideList, "SteelSheetPileOneSide");
            var InvalidLayerThickness = helper.getXmlElement(SteelSheetPile, "EmbedmentSoilValue");
            

            EmbedmentSoilValue.InnerText = value.ToString();


            // 
            var SideList = helper.getXmlElement(SteelSheetPile, "SideList");
            var SteelSheetPileOneSide = helper.getXmlElement(SideList, "SteelSheetPileOneSide",1);
            var InvalidLayerThickness = helper.getXmlElement(SteelSheetPile, "EmbedmentSoilValue");
            

            InvalidLayerThickness.InnerText = value.ToString();
            
            // 
            var CorrosionExcvT2 = helper.getXmlElement(SteelSheetPile", "CorrosionExcvT2");
            

            CorrosionExcvT2.InnerText = value.ToString("E");
            
            // 
            var CorrosionBackT1 = helper.getXmlElement(SteelSheetPile", "CorrosionBackT1");
            

            CorrosionBackT1.InnerText = value.ToString("E");
            
            


        }
    }
}
