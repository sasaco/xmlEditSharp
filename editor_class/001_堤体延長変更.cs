using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    static class editor_001
    {
        /// <summary>
        /// 堤体の延長を変更する
        /// </summary>
        /// <param name="xmlDoc">変更する対象</param>
        /// <param name="value">新しい値</param>
        static public void Edit(XmlDocument xmlDoc, double value )
        {
            var CofferdamLength = xmlDoc.GetElementsByTagName("CofferdamLength");

            var PlaneUnit = xmlDoc.GetElementsByTagName("PlaneUnit");
            var Width = xmlDoc.GetElementsByTagName("Width");

            //var CofferdamLength1 = xmlDoc.SelectSingleNode("CofferdamLength");
            //var CofferdamLength2 = xmlDoc.SelectNodes("CofferdamLength");
            //var PlaneUnit = xmlDoc.SelectNodes("PlaneUnit");
            //var Width = PlaneUnit.SelectNodes("//Width");

        }
    }
}
