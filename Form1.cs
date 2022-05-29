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
            xmlDoc.Load(@"data/master.xml");

            //editor_001.Edit(xmlDoc, 10.0);
            //editor_002.Edit(xmlDoc, 5.5); 
            //editor_003.Edit(xmlDoc, 3.5); 
            //editor_004.Edit(xmlDoc, 4.5); 
            //editor_005.Edit(xmlDoc, 2.5); 
            //editor_010.Edit(xmlDoc, 0.9);
            //editor_011.Edit(xmlDoc, 0.9);
            //editor_012.Edit(xmlDoc, 4);
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
            //editor_014.Edit(xmlDoc, 4);
            editor_015.Edit(xmlDoc, 
                "粘性土", 
                "_Clay", 
                1.10000000000000E+001,
                1.70000000000000E+001,
                8.00000000000000E+000,
                1.80000000000000E+001,
                2.50000000000000E+001,
                5.00000000000000E+000,
                5.00000000000000E-001
                );

        }
    }
}
