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
            //コントロールを初期化する
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 10000;
            ProgressBar1.Value = 0;

            var xmlDoc = new XmlDocument();
            for(int i = ProgressBar1.Minimum; i < ProgressBar1.Maximum+1; ++i)
            {
                ProgressBar1.Value = i;
                Label1.Text = string.Format("データ生成中{0}/{1}", ProgressBar1.Value + 1, ProgressBar1.Maximum);

                xmlDoc.Load(@"data/master.f7n");

                Random r1 = new System.Random();

                // 堤体
                var param001 = r1.Next(10, 31); // 堤体延長
                editor_001.Edit(xmlDoc, param001);       

                editor_002.Edit(xmlDoc, Convert.ToDouble(r1.Next(10, 201)) / 10);   // 堤体幅 1m～20m

                // 堤内側矢板天端高さ
                var param003 = Convert.ToDouble(r1.Next(20, 101)) / 10; // 高さ 1m～10m
                var param004 = param003;
                editor_003.Edit(xmlDoc, param003, param004 + Convert.ToDouble(r1.Next(10, 101)) / 10);

                // 堤外側矢板天端高さ
                editor_004.Edit(xmlDoc, param003, param004 + Convert.ToDouble(r1.Next(10, 101)) / 10);

                // 中詰土天端高さ
                var param005 = param003 - 0.1;//堤内側と堤外側の低い方
                editor_005.Edit(xmlDoc, param005);

                // 堤外区間地表面（現地盤）高G.L.
                var h_out = Convert.ToDouble(r1.Next(0, Convert.ToInt32(param005 * 10))) / 10; // 0m ～ 中詰土天端高さ
                // 堤内区間地表面（現地盤）高G.L.
                var h_in = Convert.ToDouble(r1.Next(0, Convert.ToInt32(param005 * 10))) / 10; // 0m ～ 中詰土天端高さ

                // 引張材
                var min_h10 = Math.Max(h_out, h_in) + 0.1;
                // 1段目
                var pich_10 = Convert.ToDouble(r1.Next(2, param001 * 5 + 1)) / 10;                      // 上段ピッチ 0.2m～堤体延長/2
                var depth10 = Convert.ToDouble(r1.Next(Convert.ToInt32(min_h10 * 10), Convert.ToInt32(param005 * 10))) / 10;    // 上段深さ   0.2m～矢板天端高さ
                editor_010.Edit(xmlDoc, pich_10,
                                        depth10);
                // 2段目
                var pich_11 = Convert.ToDouble(r1.Next(2, param001 * 5 + 1)) / 10;                      // 下段ピッチ 0.2m～堤体延長/2
                var depth11 = Convert.ToDouble(r1.Next(Convert.ToInt32(min_h10 * 10), Convert.ToInt32(depth10 * 10))) / 10;     // 下段深さ   0.2m～矢板天端高さ
                editor_011.Edit(xmlDoc, pich_11,
                                        depth11);

                // 地層データ
                // 堤外区間地表面（現地盤）高G.L.
                editor_012.Edit(xmlDoc, h_out);  

                // 堤外区間 土質条件
                string[] soil_jp = new string[2] { "粘性土", "砂質土" };
                string[] soil_en = new string[2] { "_Clay", "_Sandy" };
                int r = r1.Next(11, 21);        // 土の湿潤重量 11 ～ 20

                editor_013.Edit(xmlDoc,
                    20,                        // 層厚 100m(固定
                    soil_en[r1.Next(0, 2)],     // 土質
                    r1.Next(0, 51),             // 平均N値 0 ～ 50
                    r,                          // 土の湿潤重量
                    r - 10,                     // 土の水中重量
                    r + 1,                      // 土の飽和重量
                    r1.Next(0, 46),             // 内部摩擦角 0 ～ 45°
                    r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                    0,                          // 粘着力 増分 0
                    r1.Next(10, 2000) * 100       // 変形係数 1000 ～ 200000
                    );

                // 堤内区間地表面（現地盤）高G.L.
                //editor_014.Edit(xmlDoc, r1.Next(0, param005 * 10) / 10);  // 0m ～ 中詰土端高さ
                editor_014.Edit(xmlDoc, 0);  // 中詰土端高さ-0.1m

                // 堤内区間 中詰め 土質条件
                int soil_index = r1.Next(0, 2);
                r = r1.Next(11, 21);            // 土の湿潤重量 11 ～ 20
                editor_015.Edit(xmlDoc,
                    soil_jp[soil_index],
                    soil_en[soil_index],
                    r1.Next(0, 51),             // 平均N値 0 ～ 50
                    r,                          // 土の湿潤重量
                    r - 10,                     // 土の水中重量
                    r + 1,                      // 土の飽和重量
                    r1.Next(0, 46),             // 内部摩擦角 0 ～ 45°
                    r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                    0                          // 粘着力 増分 0
                    );


                // 堤内区間 土質条件
                r = r1.Next(11, 21);            // 土の湿潤重量 11 ～ 20
                editor_016.Edit(xmlDoc,
                    20,
                    soil_en[r1.Next(0, 2)],     // 土質
                    r1.Next(0, 51),             // 平均N値 0 ～ 50
                    r,                          // 土の湿潤重量
                    r - 10,                     // 土の水中重量
                    r + 1,                      // 土の飽和重量
                    r1.Next(0, 46),             // 内部摩擦角 0 ～ 45°
                    r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                    0,                          // 粘着力 増分 0
                    r1.Next(10, 2000) * 100       // 変形係数 1000 ～ 200000
                    );

                // 堤内区間地表面（現地盤）高G.L.
                editor_017.Edit(xmlDoc, h_in);  


                // 堤内区間 土質条件
                editor_018.Edit(xmlDoc,
                    20,
                    soil_en[r1.Next(0, 2)],     // 土質
                    r1.Next(0, 51),             // 平均N値 0 ～ 50
                    r,                          // 土の湿潤重量
                    r - 10,                     // 土の水中重量
                    r + 1,                      // 土の飽和重量
                    r1.Next(0, 51),             // 内部摩擦角 0 ～ 50°
                    r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                    0,                          // 粘着力 増分 0
                    r1.Next(10, 2000) * 100       // 変形係数 1000 ～ 200000
                    );

                // 鋼矢板
                // editor_019.Edit(xmlDoc, 0.45, 0.6);  // 有効率

                // 使用する矢板
                editor_020.Edit(xmlDoc, r1.Next(1, 6)); // 1～5

                // 使用する材質
                string[] _SY = new string[2] { "_SY295", "_SY390" };
                editor_021.Edit(xmlDoc, _SY[r1.Next(0, 2)]);

                // 根入れ照査時の地盤の評価
                editor_022.Edit(xmlDoc, soil_en[r1.Next(0, 2)]);

                // 矢板前面の無効層厚
                editor_023.Edit(xmlDoc, r1.Next(0, 6)); // 0m ～ 5m

                // 引張材材料特性
                bool[] _bool = new bool[2] { true, false };

                // 1段目
                // 使用鋼材直径
                var Dia1 = r1.Next(10, 51);
                // 使用材料番号 
                int[] _No;
                if (Dia1 < 40)
                    _No = new int[2] { 1, 3 };
                else
                    _No = new int[2] { 2, 4 };
                // 腹起し材質   
                string[] _WALE = new string[2] { "_SS400", "_SM490" };
                // 使用材料番号   
                var iNo = _No[r1.Next(0, 2)];
                // 
                var sNo = "SS400（＜40mm）";
                switch (iNo)
                {
                    case 2:
                        sNo = "SS400（＞40mm）";
                        break;
                    case 3:
                        sNo = "SS490（＜40mm）";
                        break;
                    case 4:
                        sNo = "SS490（＞40mm）";
                        break;
                }
                // 腹起し材質
                var jNo = r1.Next(0, 2);
                var w1 = _WALE[jNo];

                editor_024.Edit(xmlDoc, _bool[r1.Next(0, 2)],   // 引張バネ有効・無効
                                        pich_10,                // 設置間隔
                                        Dia1,
                                        iNo,                     // 使用材料番号   
                                        r1.Next(1, 6),          // 使用本数  1 ～ 5, 
                                        false,                  // 引張材バネ直接入力 しない
                                        1,                      // バネ定数 
                                        w1,                     // 腹起し材質  
                                        sNo,
                                        jNo + 1,
                                        w1.Replace("_", "")
                                        );


                // 2段目
                // 使用鋼材直径
                Dia1 = r1.Next(10, 51);
                // 使用材料番号 
                if (Dia1 < 40)
                    _No = new int[2] { 1, 3 };
                else
                    _No = new int[2] { 2, 4 };
                // 腹起し材質   
                _WALE = new string[2] { "_SS400", "_SM490" };
                // 使用材料番号   
                iNo = _No[r1.Next(0, 2)];
                // 
                sNo = "SS400（＜40mm）";
                switch (iNo)
                {
                    case 2:
                        sNo = "SS400（＞40mm）";
                        break;
                    case 3:
                        sNo = "SS490（＜40mm）";
                        break;
                    case 4:
                        sNo = "SS490（＞40mm）";
                        break;
                }
                // 腹起し材質  
                jNo = r1.Next(0, 2);
                w1 = _WALE[jNo];

                editor_025.Edit(xmlDoc, _bool[r1.Next(0, 2)],   // 引張バネ有効・無効
                                        pich_10,                // 設置間隔
                                        Dia1,
                                        iNo,                     // 使用材料番号   
                                        r1.Next(1, 6),          // 使用本数  1 ～ 5, 
                                        false,                  // 引張材バネ直接入力 しない
                                        1,                      // バネ定数 
                                        w1,                     // 腹起し材質    
                                        sNo,
                                        jNo + 1,
                                        w1.Replace("_", "")
                                        );

                // 常時ケース名
                // editor_026.Edit(xmlDoc, "高水位時");

                // 常時の水位
                editor_027.Edit(xmlDoc,
                    Convert.ToDouble(r1.Next(Convert.ToInt32(Math.Max(h_out, h_in)* 10), Convert.ToInt32(param004 * 10))) / 10,     // 堤外側水位 0m ～ 堤外側矢板天端高さ
                    Convert.ToDouble(r1.Next(0, Convert.ToInt32(param003 * 10))) / 10      // 堤内側水位 0m ～ 堤内側矢板天端高さ
                    );

                // 常時鉛直力
                // editor_028.Edit(xmlDoc, 1.00000000000000E+000);


                // 地震時ケース名
                // editor_029.Edit(xmlDoc, "高水位時");

                // 地震時の水位
                editor_030.Edit(xmlDoc,
                    Convert.ToDouble(r1.Next(Convert.ToInt32(Math.Max(h_out, h_in) * 10), Convert.ToInt32(param004 * 10))) / 10,     // 堤外側水位 0m ～ 堤外側矢板天端高さ
                    Convert.ToDouble(r1.Next(0, Convert.ToInt32(param003 * 10))) / 10      // 堤内側水位 0m ～ 堤内側矢板天端高さ
                    );

                // 空気中における震度
                editor_031.Edit(xmlDoc, Convert.ToDouble(r1.Next(1, 6)) / 10); // Kh = 0.1 ～ 0.5

                // 地震時鉛直力
                // editor_032.Edit(xmlDoc, 1.00000000000000E+000);

                string filename = string.Format("Z:/{0}.f7n", i);
                xmlDoc.Save(filename);
            }

            Label1.Text = "完了しました。";
            MessageBox.Show("＼(^o^)／ｵﾜﾀ");
        }


        /*
        private void button1_Click(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"data/master.f7n");

            //editor_001.Edit(xmlDoc, 10.0);
            //editor_002.Edit(xmlDoc, 4.5);
            //editor_003.Edit(xmlDoc, 3.5);
            //editor_004.Edit(xmlDoc, 3.5);
            //editor_005.Edit(xmlDoc, 3.5);
            //editor_010.Edit(xmlDoc, 1, 4);
            //editor_011.Edit(xmlDoc, 1, 0.5);
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
            //editor_022.Edit(xmlDoc, "_Clay");
            //editor_023.Edit(xmlDoc, 5.00000000000000E+000);
            //editor_024.Edit(xmlDoc, true, 9.00000000000000E-001, 20, 2, 2, true, 2, "_SM490", "SS400（＞40mm)", 2, "SM490");
            //editor_025.Edit(xmlDoc, true, 9.00000000000000E-001, 45, 1, 2, true, 2, "_SM490", "SS400（＜40mm）", 2, "SM490");
            //editor_026.Edit(xmlDoc, "高水位時");
            //editor_027.Edit(xmlDoc, 5.00000000000000E+000, 1.00000000000000E+000, 1, 5, 3);
            //editor_028.Edit(xmlDoc, 1.00000000000000E+000);
            //editor_029.Edit(xmlDoc, "高水位時");
            //editor_030.Edit(xmlDoc, 1.00000000000000E+000, 5.00000000000000E-001);
            //editor_031.Edit(xmlDoc, 5.00000000000000E-001);
            //editor_032.Edit(xmlDoc, 1.00000000000000E+000);

            xmlDoc.Save(@"../../data/edited.f7n");

            MessageBox.Show("＼(^o^)／ｵﾜﾀ");
        }
        */
    }
}
