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
						<StratumList>
							<Stratum>
							    <LayerList>
    							    <Layer>
        							    <Thickness>
        							    <SoilType>
        							    <Nvalue>
        							    <WetUnitWeight>
        							    <SubmergedUnitWeight>
        							    <SaturationUnitWeight>
        							    <FrictionAngle>
        							    <Cohesion>
        							    <CohesionCoefficient>
        							    <ModulusOfDeformation>
        							    <InputCoefficientSubgrade>
        							    <LiquefactionResistanceRate>
        							    <WallFrictionAngle>
        							    <WallFrictionAngle_Layer>
    */

    static public class editor_013
    {

        /// </summary>
        /// <param name="xmlDoc">地層データ_堤外区間_土パラメータ変更</param>
        /// <param name="_Thickness">層厚</param>
        /// <param name="_SoilType">土質種類</param>
        /// <param name="_Nvalue">平均N値</param>
        /// <param name="_WetUnitWeight">湿潤重量</param>
        /// <param name="_SubmergedUnitWeight">水中重量</param>
        /// <param name="_SaturationUnitWeight">飽和重量</param>
        /// <param name="_FrictionAngle"></param>
        /// <param name="_Cohesion"></param>
        /// <param name="_CohesionCoefficient"></param>
        /// <param name="_ModulusOfDeformation"></param>
        /// <param name="_InputCoefficientSubgrade"></param>
        /// <param name="_LiquefactionResistanceRate"></param>
        /// <param name="_WallFrictionAngle"></param>
        /// <param name="_WallFrictionAngle_Layer"></param>
        static public void Edit(XmlDocument xmlDoc,
            double _Thickness,
            string _SoilType,
            double _Nvalue,
            double _WetUnitWeight,
            double _SubmergedUnitWeight,
            double _SaturationUnitWeight,
            double _FrictionAngle,
            double _Cohesion,
            double _CohesionCoefficient,
            double _ModulusOfDeformation,
            double _InputCoefficientSubgrade = 1,
            double _LiquefactionResistanceRate = 1.3,
            double _WallFrictionAngle = 15,
            double _WallFrictionAngle_Layer = 15
            )
        {
            XmlElement root = xmlDoc.DocumentElement;

            var Products = helper.getXmlElement(root, "Products");
            var WShut3 = helper.getXmlElement(Products, "WShut3");
            var DrawingCreationData = helper.getXmlElement(WShut3, "DrawingCreationData");
            var InputData = helper.getXmlElement(WShut3, "InputData");
            var WShutData = helper.getXmlElement(InputData, "WShutData");
            var StratumList = helper.getXmlElement(WShutData, "StratumList");
            var Stratum = helper.getXmlElement(StratumList, "Stratum");
            var LayerList = helper.getXmlElement(Stratum, "LayerList");
            var Layer = helper.getXmlElement(LayerList, "Layer");

            var Thickness = helper.getXmlElement(Layer, "Thickness");
            var SoilType = helper.getXmlElement(Layer, "SoilType");
            var Nvalue = helper.getXmlElement(Layer, "Nvalue");
            var WetUnitWeight = helper.getXmlElement(Layer, "WetUnitWeight");
            var SubmergedUnitWeight = helper.getXmlElement(Layer, "SubmergedUnitWeight");
            var SaturationUnitWeight = helper.getXmlElement(Layer, "SaturationUnitWeight");
            var FrictionAngle = helper.getXmlElement(Layer, "FrictionAngle");
            var Cohesion = helper.getXmlElement(Layer, "Cohesion");
            var CohesionCoefficient = helper.getXmlElement(Layer, "CohesionCoefficient");
            var ModulusOfDeformation = helper.getXmlElement(Layer, "ModulusOfDeformation");
            var InputCoefficientSubgrade = helper.getXmlElement(Layer, "InputCoefficientSubgrade");
            var LiquefactionResistanceRate = helper.getXmlElement(Layer, "LiquefactionResistanceRate");
            var WallFrictionAngle = helper.getXmlElement(Layer, "WallFrictionAngle");
            var WallFrictionAngle_Layer = helper.getXmlElement(Layer, "WallFrictionAngle_Layer");

            Thickness.InnerText = _Thickness.ToString("E");
            SoilType.InnerText = _SoilType;
            Nvalue.InnerText = _Nvalue.ToString("E");
            WetUnitWeight.InnerText = _WetUnitWeight.ToString("E");
            SubmergedUnitWeight.InnerText = _SubmergedUnitWeight.ToString("E");
            SaturationUnitWeight.InnerText = _SaturationUnitWeight.ToString("E");
            FrictionAngle.InnerText = _FrictionAngle.ToString("E");
            Cohesion.InnerText = _Cohesion.ToString("E");

            CohesionCoefficient.InnerText = _CohesionCoefficient.ToString("E");
            ModulusOfDeformation.InnerText = _ModulusOfDeformation.ToString("E");
            InputCoefficientSubgrade.InnerText = _InputCoefficientSubgrade.ToString("E");
            LiquefactionResistanceRate.InnerText = _LiquefactionResistanceRate.ToString("E");
            WallFrictionAngle.InnerText = _WallFrictionAngle.ToString("E");
            WallFrictionAngle_Layer.InnerText = _WallFrictionAngle_Layer.ToString("E");

        }



    }
}
