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
    

    

    static public class editor_024
    {
        /// <summary>
        /// 部材引張材材料パラメータ下段変更
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
            var TensionMember = helper.getXmlElement(WShutData, "TensionMember");
            var MemberList = helper.getXmlElement(TensionMember, "MemberList");
            var Member = helper.getXmlElement(MemberList, "Member");

            // 

            var Effective = helper.getXmlElement(Member", "Effective");

            Effective.InnerText = value.ToString();


            // 
            var Space = helper.getXmlElement(Member", "Space");
            

            Space.InnerText = value.ToString("E");
            
            // 
            var UseSteelDiameter = helper.getXmlElement(Member", "UseSteelDiameter");
            

            UseSteelDiameter.InnerText = value.ToString("E");
            
            // 
            var UseMaterialNumber = helper.getXmlElement(Member", "UseMaterialNumber");
            

            UseMaterialNumber.InnerText = value.ToString();
            
            
            // 
            var UseMembers = helper.getXmlElement(Member", "UseMembers");
            

            UseMembers.InnerText = value.ToString();
            
            //
            var InputTensionSpring = helper.getXmlElement(Member", "InputTensionSpring");
            

            InputTensionSpring.InnerText = value.ToString();
            
            
            //
            var SpringConstant = helper.getXmlElement(Member", "SpringConstant");
            

            SpringConstant.InnerText = value.ToString("E");
            
            //
            var WalingMaterials = helper.getXmlElement(Member", "WalingMaterials");
            

            WalingMaterials.InnerText = value.ToString();

        }
    }
}
