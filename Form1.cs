using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"data/master.f7n");

            //editor_001.Edit(xmlDoc, 10.0);
            //editor_002.Edit(xmlDoc, 4.5);
            //editor_003.Edit(xmlDoc, 3.5);
            //editor_004.Edit(xmlDoc, 3.5);
            //editor_005.Edit(xmlDoc, 3.5);
            //editor_010.Edit(xmlDoc, 1);
            //editor_011.Edit(xmlDoc, 1);
            //editor_012.Edit(xmlDoc, 5);
            //editor_013.Edit(xmlDoc,
            //    1.40000000000000E+001,
            //    "_Clay",
            //    1.10000000000000E+001,
            //    1.70000000000000E+001,
            //    8.00000000000000E+000,
            //    1.80000000000000E+001,
            //    2.50000000000000E+001,
            //    5.00000000000000E-001,
            //    5.00000000000000E-001,
            //    3.00000000000000E+004
            //    );
            //editor_014.Edit(xmlDoc, 5);
            //editor_015.Edit(xmlDoc, 
            //    "粘性土", 
            //    "_Clay", 
            //    1.10000000000000E+001,
            //    1.70000000000000E+001,
            //    8.00000000000000E+000,
            //    1.80000000000000E+001,
            //    2.50000000000000E+001,
            //    5.00000000000000E+000,
            //    5.00000000000000E-001
            //    );
            //editor_016.Edit(xmlDoc,
            //    1.40000000000000E+001,
            //    "_Clay",
            //    1.10000000000000E+001,
            //    1.70000000000000E+001,
            //    8.00000000000000E+000,
            //    1.80000000000000E+001,
            //    2.50000000000000E+001,
            //    8.00000000000000E-001,
            //    6.00000000000000E-001,
            //    3.00000000000000E+004
            //    );
            //editor_017.Edit(xmlDoc, 5);
            //editor_018.Edit(xmlDoc,
            //    1.40000000000000E+001,
            //    "_Clay",
            //    1.10000000000000E+001,
            //    1.70000000000000E+001,
            //    8.00000000000000E+000,
            //    1.80000000000000E+001,
            //    2.50000000000000E+001,
            //    5.00000000000000E-001,
            //    5.00000000000000E-001,
            //    3.00000000000000E+004
            //    );
            //editor_019.Edit(xmlDoc, 6.00000000000000E-001, 8.00000000000000E-001);
            //editor_020.Edit(xmlDoc, 4);
            //editor_021.Edit(xmlDoc, "_SY390");
            //editor_022.Edit(xmlDoc, "_Sandy");
            //editor_023.Edit(xmlDoc, 3.200000000000E-001,2.0000000000000E-2, 5.00000000000000E+000, 5.00000000000000E+000);
            //editor_024.Edit(xmlDoc, true, 9.00000000000000E-001, 2.00000000000000E+001, 2, 2, true, 2.00000000000000E+000, "_SM490", 20, "SS400（＞40mm)", "SM490");
            //editor_025.Edit(xmlDoc, true, 9.00000000000000E-001, 4.50000000000000E+001, 1, 2, true, 2.00000000000000E+000, "_SM490", 45, "SS400（＜40mm）", "SM490");
            //editor_026.Edit(xmlDoc, "高水位時");
            //editor_027.Edit(xmlDoc, 5.00000000000000E+000, 1.00000000000000E+000);
            //editor_028.Edit(xmlDoc, 1.00000000000000E+000);
            //editor_029.Edit(xmlDoc, "高水位時");
            //editor_030.Edit(xmlDoc, 1.00000000000000E+000, 5.00000000000000E-001);
            //editor_031.Edit(xmlDoc, 5.00000000000000E-001);
            //editor_032.Edit(xmlDoc, 1.00000000000000E+000);

            xmlDoc.Save(@"../../data/edited.f7n");

            MessageBox.Show("＼(^o^)／ｵﾜﾀ");
        }
    }
}
