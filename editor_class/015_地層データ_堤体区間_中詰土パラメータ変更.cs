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
						<Init>
							<FillStruct>
        						<SoilType>
        						<Nvalue>
        						<WetUnitWeight>
        						<SubmegedUnitWeight>
        						<SaturationUnitWeight>
        						<FrictionAngle>
        						<Cohesion>
        						<CohesionCoefficient>
        						<ModulusOfDeformation>
        						<WallFrictionAngle>
        						<WallFrictionAngle_Layer>
                        <Basic>
                            <FillStruct>
            			        <SoilType>
        				        <Nvalue>
        				        <WetUnitWeight>
        				        <SubmegedUnitWeight>
        				        <SaturationUnitWeight>
        				        <FrictionAngle>
        				        <Cohesion>
        				        <CohesionCoefficient>
        				        <ModulusOfDeformation>
        				        <WallFrictionAngle>
        				        <WallFrictionAngle_Layer>
*/

    static public class editor_015
    {

        /// </summary>
        /// <param name="xmlDoc">地層データ_堤体区間_中詰土パラメータ変更</param>
        /// <param name="_SoilType">土質種類</param>
        /// <param name="_Nvalue">平均N値</param>
        /// <param name="_WetUnitWeight">湿潤重量</param>
        /// <param name="_SubmergedUnitWeight">水中重量</param>
        /// <param name="_SaturationUnitWeight">飽和重量</param>
        /// <param name="_FrictionAngle"></param>
        /// <param name="_Cohesion"></param>
        /// <param name="_CohesionCoefficient"></param>
        /// <param name="_ModulusOfDeformation"></param>
        /// <param name="_WallFrictionAngle"></param>
        /// <param name="_WallFrictionAngle_Layer"></param>
        static public void Edit(XmlDocument xmlDoc,
            string _InnerGround,
            string _SoilType,
            double _Nvalue,
            double _WetUnitWeight,
            double _SubmergedUnitWeight,
            double _SaturationUnitWeight,
            double _FrictionAngle,
            double _Cohesion,
            double _CohesionCoefficient,
            double _ModulusOfDeformation = 3360,
            double _WallFrictionAngle = 15,
            double _WallFrictionAngle_Layer = 0
            )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var InputData1 = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData1, "WShutData");

            foreach (string key in new string[] { "Init", "Basic" })
            {
                var Init = helper.getXmlElement(WShutData, key);
                var FillStruct = helper.getXmlElement(Init, "FillStruct");
                var Thickness = helper.getXmlElement(FillStruct, "Thickness");
                var SoilType = helper.getXmlElement(FillStruct, "SoilType");
                var NValue = helper.getXmlElement(FillStruct, "NValue");
                var WetUnitWeight = helper.getXmlElement(FillStruct, "WetUnitWeight");
                var SubmegedUnitWeight = helper.getXmlElement(FillStruct, "SubmegedUnitWeight");
                var SaturationUnitWeight = helper.getXmlElement(FillStruct, "SaturationUnitWeight");
                var FrictionAngle = helper.getXmlElement(FillStruct, "FrictionAngle");
                var Cohesion = helper.getXmlElement(FillStruct, "Cohesion");
                var CohesionCoefficient = helper.getXmlElement(FillStruct, "CohesionCoefficient");
                var ModulusOfDeformation = helper.getXmlElement(FillStruct, "ModulusOfDeformation");
                var WallFrictionAngle = helper.getXmlElement(FillStruct, "WallFrictionAngle");
                var WallFrictionAngle_Layer = helper.getXmlElement(FillStruct, "WallFrictionAngle_Layer");

                SoilType.InnerText = _SoilType;
                NValue.InnerText = _Nvalue.ToString("E");
                WetUnitWeight.InnerText = _WetUnitWeight.ToString("E");
                SubmegedUnitWeight.InnerText = _SubmergedUnitWeight.ToString("E");
                SaturationUnitWeight.InnerText = _SaturationUnitWeight.ToString("E");
                FrictionAngle.InnerText = _FrictionAngle.ToString("E");
                Cohesion.InnerText = _Cohesion.ToString("E");

                CohesionCoefficient.InnerText = _CohesionCoefficient.ToString("E");
                ModulusOfDeformation.InnerText = _ModulusOfDeformation.ToString("E");
                WallFrictionAngle.InnerText = _WallFrictionAngle.ToString("E");
                WallFrictionAngle_Layer.InnerText = _WallFrictionAngle_Layer.ToString("E");
            }

            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData2 = helper.getXmlElement(DrawingCreationData, "InputData");
            var PlanCondition = helper.getXmlElement(InputData2, "PlanCondition");
            var InnerGround = helper.getXmlElement(PlanCondition, "InnerGround");

            InnerGround.InnerText = _InnerGround;


        }



    }
}
