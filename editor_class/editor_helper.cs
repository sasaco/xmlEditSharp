using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    static public class helper
    {
        static public XmlElement getXmlElement(XmlElement target, string key, int index = 0)
        {
            int i = 0;
            int j;

            XmlElement result = null;
            foreach (var child in target.ChildNodes)
            {
                var node = (XmlElement)child;
                if (node.Name == key)
                {
                    result = node;

                    if (int.TryParse(node.GetAttribute("No"), out j))
                    {
                        if (index == j)
                            break;
                    }
                    else
                    {
                        if (index == i)
                            break;
                    }
                    i++;
                }
            }
            return result;
        }
    }
}
