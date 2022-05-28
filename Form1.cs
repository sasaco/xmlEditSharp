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
            editor_012.Edit(xmlDoc, 4);

        }
    }
}
