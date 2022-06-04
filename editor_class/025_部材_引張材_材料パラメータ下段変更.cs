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
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <Effective>

    */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <Space>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <UseSteelDiameter>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <UseMaterialNumber>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <UseMembers>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <InputTensionSpring>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <SpringConstant>

     */

    /*
     <Project>
        <Products>
            <WShut3>
                <InputData>
                    <WShutData>
                        <TensionMember>
                            <MemberList>
                                <Member>
                                    <WalingMaterials>
      */
    /*
   <Project>
      <Products>
          <WShut3>
               <DrawingCreationData>
                      <InputData>
                          <Shape_Structure>
                              <Index No="0">
                                  <Tai>
                                      <TaiUnit>
                                          <Index N0="1">
                                              <Deameter>


   */
    /*
    <Project>
       <Products>
           <WShut3>
                <DrawingCreationData>
                       <InputData>
                           <Shape_Structure>
                               <Index No="0">
                                   <Tai>
                                       <TaiUnit>
                                           <Index N0="1">
                                               <TaiMaterial>                                     


    */
    /*
    <Project>
       <Products>
           <WShut3>
                <DrawingCreationData>
                       <InputData>
                           <Shape_Structure>
                               <Index No="0">
                                   <Tai>
                                       <TaiUnit>
                                           <Index N0="1">
                                               <Harakoshimaterial>     
   */




    static public class editor_025
    {
        /// <summary>
        /// 部材引張材材料パラメータ下段変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, bool eff, double spa, double USD, double UMN, double UM, bool ITS, double SC, string WM, double dea, string TM, string HM)
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");

            //
            var InputData1 = helper.getXmlElement(WShut3, "InputData1");
            var WShutData = helper.getXmlElement(InputData1, "WShutData");
            var TensionMember = helper.getXmlElement(WShutData, "TensionMember");
            var MemberList = helper.getXmlElement(TensionMember, "MemberList");
            var Member = helper.getXmlElement(MemberList, "Member", 1);

            // 

            var Effective = helper.getXmlElement(Member, "Effective");

            Effective.InnerText = eff.ToString();


            // 
            var Space = helper.getXmlElement(Member, "Space");


            Space.InnerText = spa.ToString("E");

            // 
            var UseSteelDiameter = helper.getXmlElement(Member, "UseSteelDiameter");


            UseSteelDiameter.InnerText = USD.ToString("E");

            // 
            var UseMaterialNumber = helper.getXmlElement(Member, "UseMaterialNumber");


            UseMaterialNumber.InnerText = UMN.ToString();


            // 
            var UseMembers = helper.getXmlElement(Member, "UseMembers");


            UseMembers.InnerText = UM.ToString();

            //
            var InputTensionSpring = helper.getXmlElement(Member, "InputTensionSpring");


            InputTensionSpring.InnerText = ITS.ToString();


            //
            var SpringConstant = helper.getXmlElement(Member, "SpringConstant");


            SpringConstant.InnerText = SC.ToString("E");

            //
            var WalingMaterials = helper.getXmlElement(Member, "WalingMaterials");


            WalingMaterials.InnerText = WM.ToString();

            //
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData2 = helper.getXmlElement(DrawingCreationData, "InputData2");
            var Shape_Structure = helper.getXmlElement(InputData2, "Shape_Structure");
            var Index0 = helper.getXmlElement(Shape_Structure, "Index0");
            var Tai = helper.getXmlElement(Index0, "Tai");
            var TaiUnit = helper.getXmlElement(Tai, "TaiUnit");
            var Index1 = helper.getXmlElement(TaiUnit, "Index1");

            //
            var Deameter = helper.getXmlElement(Index1, "Deameter");


            Deameter.InnerText = dea.ToString();

            //
            var TaiMaterial = helper.getXmlElement(Index1, "TaiMaterial");


            TaiMaterial.InnerText = TM.ToString();

            //
            var HaraokoshiMaterial = helper.getXmlElement(Index1, "HaraokoshiMaterial");


            HaraokoshiMaterial.InnerText = dea.ToString();





        }
    }
}
