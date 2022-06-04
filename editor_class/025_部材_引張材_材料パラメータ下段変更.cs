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
    

    

    static public class editor_025
    {
        /// <summary>
        /// 部材引張材材料パラメータ下段変更
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc,
            bool _effective,
            double _space,
            int _UseSteelDiameter,
            int _UseMaterialNumber,
            int _UseMembers,
            bool _InputTensionSpring,
            int _SpringConstant,
            string _WalingMaterials,
            string _TaiMaterial,
            int _HaraokoshiSteelNo,
            string _HaraokoshiMaterial
            )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData, "WShutData");
            var TensionMember = helper.getXmlElement(WShutData, "TensionMember");
            var MemberList = helper.getXmlElement(TensionMember, "MemberList");
            var Member = helper.getXmlElement(MemberList, "Member", 1);

            // 

            var Effective = helper.getXmlElement(Member, "Effective");

            Effective.InnerText = _effective.ToString();


            // 
            var Space = helper.getXmlElement(Member, "Space");
            Space.InnerText = _space.ToString("E");

            // 
            var UseSteelDiameter = helper.getXmlElement(Member, "UseSteelDiameter");
            UseSteelDiameter.InnerText = _UseSteelDiameter.ToString("E");

            // 
            var UseMaterialNumber = helper.getXmlElement(Member, "UseMaterialNumber");
            UseMaterialNumber.InnerText = _UseMaterialNumber.ToString();

            // 
            var UseMembers = helper.getXmlElement(Member, "UseMembers");
            UseMembers.InnerText = _UseMembers.ToString();

            //
            var InputTensionSpring = helper.getXmlElement(Member, "InputTensionSpring");
            InputTensionSpring.InnerText = _InputTensionSpring.ToString();

            //
            var SpringConstant = helper.getXmlElement(Member, "SpringConstant");
            SpringConstant.InnerText = _SpringConstant.ToString("E");

            //
            var WalingMaterials = helper.getXmlElement(Member, "WalingMaterials");
            WalingMaterials.InnerText = _WalingMaterials.ToString();

            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData1 = helper.getXmlElement(DrawingCreationData, "InputData");
            var Shape_Structure = helper.getXmlElement(InputData1, "Shape_Structure");
            var StructureUnit = helper.getXmlElement(Shape_Structure, "StructureUnit");
            var Index1 = helper.getXmlElement(StructureUnit, "Index");
            var Tai = helper.getXmlElement(Index1, "Tai");
            var TaiUnit = helper.getXmlElement(Tai, "TaiUnit");
            var Index2 = helper.getXmlElement(TaiUnit, "Index", 1);

            var Deameter = helper.getXmlElement(Index2, "Deameter");
            Deameter.InnerText = _UseSteelDiameter.ToString();

            var TaiMaterial = helper.getXmlElement(Index2, "TaiMaterial");
            TaiMaterial.InnerText = _TaiMaterial.ToString();

            var HaraokoshiSteelNo = helper.getXmlElement(Index2, "HaraokoshiSteelNo");
            HaraokoshiSteelNo.InnerText = _HaraokoshiSteelNo.ToString();

            var HaraokoshiMaterial = helper.getXmlElement(Index2, "HaraokoshiMaterial");
            HaraokoshiMaterial.InnerText = _HaraokoshiMaterial.ToString();

        }

    }
}
