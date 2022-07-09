using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string> csvList;

        public Form1()
        {
            InitializeComponent();

            csvList = new List<string>();
            csvList.Add(
                "No, " +
                "堤体延長, " +          // param001
                "堤体幅, " +            // param002
                "左右壁体高さ, " +      // param003
                "矢板の全長, " +        // param004
                "中詰土天端高さ, " +    // param005
                "堤外区間地表面, " +    // param006
                "堤内区間地表面, " +    // param007

                // 引張材
                "引張材間隔, " +        // param008
                "引張材位置, " +        // param009
                //"param010, " +
                //"param011, " +

                // 地層データ
                "在来地盤重量, " +      // param101
                "在来地盤区分, " +      // param102
                "在来地盤N値, " +       // param103
                "在来地盤摩擦角, " +    // param104
                "在来地盤粘着力, " +    // param105
                "在来地盤変形係数, " +  // param106

                "中詰め重量, " +        // param111
                "中詰め区分ja, " +      // param112
//                "中詰め区分, " +      // param113
                "中詰めN値, " +         // param114
                "中詰め摩擦角, " +      // param115
                "中詰め粘着力, " +      // param116

                // 使用する矢板
                "矢板型, " +            // param201
                "矢板材料, " +          // param202

                // タイロッド
                "引張材直径, " +        // param301
                "引張材材料番号, " +    // param302

                "腹起し材質, " +        // param303
                // "param304, " +
                "腹起し番号, " +        // param305

                //"param311, " +
                //"param314, " +

                // 水位
                "堤外側水位_常時, " +   // param401
                "堤内側水位_常時, " +   // param402
                "堤外側水位_地震時, " + // param411
                "堤内側水位_地震時, " + // param412

                //震度
                "震度"                  // param501
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //コントロールを初期化する
            ProgressBar1.Minimum = 20001;
            ProgressBar1.Maximum = 30000;
            ProgressBar1.Value = ProgressBar1.Minimum;

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

                var param002 = Convert.ToDouble(r1.Next(10, 141)) / 10;
                editor_002.Edit(xmlDoc, param002);   // 堤体幅 1m～14m


                var param003 = Convert.ToDouble(r1.Next(20, 101)) / 10;             // 壁体高さ 2m～10m
                var param004 = param003 + Convert.ToDouble(r1.Next(5, 101)) / 10;   // 矢板の全長 壁体高さ + 0.5m～ 10m

                // 堤内側矢板天端高さ
                editor_003.Edit(xmlDoc, param003, param004);
                // 堤外側矢板天端高さ
                editor_004.Edit(xmlDoc, param003, param004);

                // 中詰土天端高さ
                var param005 = param003 - 0.1;//堤内側と堤外側の低い方
                editor_005.Edit(xmlDoc, param005);


                // 堤外区間地表面（現地盤）高G.L.
                var param006 = Convert.ToDouble(r1.Next(0, Math.Max(Convert.ToInt32((param005 / 2) * 10), 0))) / 10;  // 0m ～ 中詰土天端高さの1/2
                // 堤内区間地表面（現地盤）高G.L.
                var param007 = Convert.ToDouble(r1.Next(0, Math.Max(Convert.ToInt32((param005 / 2) * 10), 0))) / 10;  // 0m ～ 中詰土天端高さの1/2
                // どっちかは、0m にする
                if (r1.Next(0, 2) == 0)
                    param006 = 0; // Convert.ToDouble(r1.Next(0, Convert.ToInt32(param005 * 3))) / 10;
                else
                    param007 = 0; // Convert.ToDouble(r1.Next(0, Convert.ToInt32(param005 * 3))) / 10;

                // 堤外区間地表面（現地盤）高G.L.
                editor_012.Edit(xmlDoc, param006);
                // 堤内区間地表面（現地盤）高G.L.
                editor_017.Edit(xmlDoc, param007);


                // 引張材
                var min_h10 = Math.Max(param006, param007);
                // 1段目
                double[] ctc = new double[2] { 0.8, 1.6 };
                var param008 = ctc[r1.Next(0, 2)];                                      // 上段ピッチ 0.8m or 1.6m
                var param009 = Convert.ToDouble(r1.Next(                                // 地表面（現地盤）+ 0.2m ～ 矢板天端高さ - 0.2
                    Convert.ToInt32((min_h10 + 0.2) * 10), 
                    Convert.ToInt32((param005 - 0.2) * 10)
                    )) / 10;    
                editor_010.Edit(xmlDoc, param008,
                                        param009);

                // 2段目
                //var param010 = Convert.ToDouble(r1.Next(2, param001 * 5 + 1)) / 10;     // 下段ピッチ 0.2m～堤体延長/2
                //var param011 = Convert.ToDouble(r1.Next(                                // 地表面（現地盤）+ 0.1m ～ 上段深さ - 0.1
                //    Convert.ToInt32((min_h10 + 0.1) * 10), 
                //    Convert.ToInt32((param009 - 0.1) * 10)
                //    )) / 10;           
                //editor_011.Edit(xmlDoc, param010,
                //                        param011);

                // 地層データ
                string[] soil_jp = new string[2] { "粘性土", "砂質土" };
                string[] soil_en = new string[2] { "_Clay", "_Sandy" };
                // 堤外区間 土質条件
                int param101 = r1.Next(11, 21);         // 土の湿潤重量 11 ～ 20
                var param102 = soil_en[r1.Next(0, 2)];  // 土質
                var param103 = r1.Next(0, 51);          // 平均N値 0 ～ 50
                var param104 = r1.Next(1, 46);          // 内部摩擦角 1 ～ 45°
                var param105 = r1.Next(0, 300);         // 粘着力 0 ～ 300
                var param106 = r1.Next(10, 2000) * 100; // 変形係数 1000 ～ 200000

                editor_013.Edit(xmlDoc,
                    20,             // 層厚 20m(固定
                    param102,       // 土質
                    param103,       // 平均N値 0 ～ 50
                    param101,       // 土の湿潤重量
                    param101 - 10,  // 土の水中重量
                    param101 + 1,   // 土の飽和重量
                    param104,       // 内部摩擦角 1 ～ 45°
                    param105,       // 粘着力 0 ～ 1000
                    0,              // 粘着力 増分 0
                    param106        // 変形係数 1000 ～ 200000
                    );

                // 堤体区間地表面（現地盤）高G.L.
                editor_014.Edit(xmlDoc, 0);  // 中詰土端高さ = 0m

                // 中詰め 土質条件
                int soil_index = r1.Next(0, 2);

                int param111 = r1.Next(11, 21);             // 土の湿潤重量 11 ～ 20
                var param112 = soil_jp[soil_index];         // 土質
                var param113 = soil_en[soil_index];         // 土質
                var param114 = r1.Next(0, 51);              // 平均N値 0 ～ 50
                var param115 = r1.Next(1, 46);              // 内部摩擦角 1 ～ 45°
                var param116 = r1.Next(0, 300);             // 粘着力 0 ～ 300

                editor_015.Edit(xmlDoc,
                    soil_jp[soil_index],
                    soil_en[soil_index],
                    param114,               // 平均N値 0 ～ 50
                    param111,               // 土の湿潤重量
                    param111 - 10,          // 土の水中重量
                    param111 + 1,           // 土の飽和重量
                    param115,               // 内部摩擦角 1 ～ 45°
                    param116,               // 粘着力 0 ～ 1000
                    0                       // 粘着力 増分 0
                    );


                // 堤体区間 土質条件
                editor_016.Edit(xmlDoc,
                    20,
                    param102,       // 土質
                    param103,       // 平均N値 0 ～ 50
                    param101,       // 土の湿潤重量
                    param101 - 10,  // 土の水中重量
                    param101 + 1,   // 土の飽和重量
                    param104,       // 内部摩擦角 1 ～ 45°
                    param105,       // 粘着力 0 ～ 1000
                    0,              // 粘着力 増分 0
                    param106        // 変形係数 1000 ～ 200000
                    );


                // 堤内区間 土質条件
                editor_018.Edit(xmlDoc,
                    20,
                    param102,       // 土質
                    param103,       // 平均N値 0 ～ 50
                    param101,       // 土の湿潤重量
                    param101 - 10,  // 土の水中重量
                    param101 + 1,   // 土の飽和重量
                    param104,       // 内部摩擦角 1 ～ 45°
                    param105,       // 粘着力 0 ～ 1000
                    0,              // 粘着力 増分 0
                    param106        // 変形係数 1000 ～ 200000
                    );

                // 鋼矢板
                // editor_019.Edit(xmlDoc, 0.45, 0.6);  // 有効率

                // 使用する矢板
                var param201 = r1.Next(3, 6);
                editor_020.Edit(xmlDoc, param201); // 3～5

                // 使用する材質
                string[] _SY = new string[2] { "_SY295", "_SY390" };
                var param202 = _SY[r1.Next(0, 2)];
                editor_021.Edit(xmlDoc, param202);

                // 根入れ照査時の地盤の評価
                editor_022.Edit(xmlDoc, param102);

                // 矢板前面の無効層厚
                editor_023.Edit(xmlDoc, 0); // 0m

                // 引張材材料特性
                bool[] _bool = new bool[2] { true, false };

                // 1段目
                // 使用鋼材直径
                var param301 = r1.Next(25, 91);
                                              // 
                // 使用材料番号 
                int[] _No;
                if (param301 < 40)
                    _No = new int[2] { 1, 3 };
                else
                    _No = new int[2] { 2, 4 };
                // 腹起し材質   
                string[] _WALE = new string[2] { "_SS400", "_SM490" };
                // 使用材料番号
                var param302 = r1.Next(0, 2);
                var iNo = _No[param302];
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
                var param303 = r1.Next(0, 2);
                var w1 = _WALE[param303];

                //var param304 = r1.Next(1, 3); // 使用本数  1 ～ 2,

                editor_024.Edit(xmlDoc, false,                  // 引張バネ無効
                                        param008,               // 設置間隔
                                        param301,
                                        iNo,                    // 使用材料番号   
                                        1,                      // param304 使用本数  1 ～ 5, 
                                        false,                  // 引張材バネ直接入力 しない
                                        1,                      // バネ定数 
                                        w1,                     // 腹起し材質  
                                        sNo,
                                        param303 + 1,
                                        w1.Replace("_", "")
                                        );

                // 腹起し番号
                var param305 = r1.Next(1, 11);
                editor_035.Edit(xmlDoc, param305);


                // 2段目
                // 使用鋼材直径
                //var param311 = r1.Next(25, 91);

                //// 使用材料番号 
                //if (param311 < 40)
                //    _No = new int[2] { 1, 3 };
                //else
                //    _No = new int[2] { 2, 4 };
                //// 腹起し材質   
                //_WALE = new string[2] { "_SS400", "_SM490" };
                //// 使用材料番号   
                //iNo = _No[r1.Next(0, 2)];
                //// 
                //sNo = "SS400（＜40mm）";
                //switch (iNo)
                //{
                //    case 2:
                //        sNo = "SS400（＞40mm）";
                //        break;
                //    case 3:
                //        sNo = "SS490（＜40mm）";
                //        break;
                //    case 4:
                //        sNo = "SS490（＞40mm）";
                //        break;
                //}
                //// 腹起し材質  
                ////param303 = r1.Next(0, 2); // 1段目と同じ
                ////w1 = _WALE[param303];     // 1段目と同じ

                //var param314 = r1.Next(1, 3); // 使用本数  1 ～ 2,

                //editor_025.Edit(xmlDoc, false,                  // 引張バネ無効
                //                        param010,                // 設置間隔
                //                        param311,
                //                        iNo,                     // 使用材料番号   
                //                        param314,               // 使用本数  1 ～ 5, 
                //                        false,                  // 引張材バネ直接入力 しない
                //                        1,                      // バネ定数 
                //                        w1,                     // 腹起し材質    
                //                        sNo,
                //                        param303 + 1,
                //                        w1.Replace("_", "")
                //                        );



                // 常時ケース名
                // editor_026.Edit(xmlDoc, "高水位時");

                // 常時の水位

                // 堤外側水位 0m ～ 壁体高さ
                var param401 = Convert.ToDouble(r1.Next(
                    Convert.ToInt32(min_h10 * 10), 
                    Convert.ToInt32(param003 * 10)
                    )) / 10;

                // 堤内側水位 0m ～ 堤内区間地表面（現地盤）高G.L.
                var param402 = Convert.ToDouble(r1.Next(
                    0, 
                    Convert.ToInt32(param007 * 10)
                    )) / 10;

                editor_027.Edit(xmlDoc,  param401, param402);


                // 常時鉛直力
                // editor_028.Edit(xmlDoc, 1.00000000000000E+000);


                // 地震時ケース名
                // editor_029.Edit(xmlDoc, "高水位時");

                // 地震時の水位

                // 堤外側水位 0m ～ 壁体高さ
                var param411 = Convert.ToDouble(r1.Next(
                    Convert.ToInt32(min_h10 * 10),
                    Convert.ToInt32(param003 * 10)
                    )) / 10;

                // 堤内側水位 0m ～ 堤内区間地表面（現地盤）高G.L.
                var param412 = Convert.ToDouble(r1.Next(
                    0,
                    Convert.ToInt32(param007 * 10)
                    )) / 10;

                editor_030.Edit(xmlDoc, param411, param412);


                // 空気中における震度
                var param501 = Convert.ToDouble(r1.Next(1, 6)) / 10;
                editor_031.Edit(xmlDoc, param501); // Kh = 0.1 ～ 0.5

                // 地震時鉛直力
                // editor_032.Edit(xmlDoc, 1.00000000000000E+000);

                string filename = string.Format("Z:/{0}.f7n", i);
                xmlDoc.Save(filename);

                // csvファイルに登録
                this.csvList.Add(
                    i.ToString() + ", " +
                    param001.ToString() + ", " +
                    param002.ToString() + ", " +
                    param003.ToString() + ", " +
                    param004.ToString() + ", " +
                    param005.ToString() + ", " +
                    param006.ToString() + ", " +
                    param007.ToString() + ", " +

                    // 引張材
                    param008.ToString() + ", " +
                    param009.ToString() + ", " +
                    //param010.ToString() + ", " +
                    //param011.ToString() + ", " +

                    // 地層データ
                    param101.ToString() + ", " +
                    param102            + ", " +
                    param103.ToString() + ", " +
                    param104.ToString() + ", " +
                    param105.ToString() + ", " +
                    param106.ToString() + ", " +

                    param111.ToString() + ", " +
                    param112            + ", " +
                    //param113            + ", " +
                    param114.ToString() + ", " +
                    param115.ToString() + ", " +
                    param116.ToString() + ", " +

                    // 使用する矢板
                    param201.ToString() + ", " +
                    param202            + ", " +

                    // タイロッド
                    param301.ToString() + ", " +
                    param302.ToString() + ", " +
                    param303.ToString() + ", " +
                    //param304.ToString() + ", " +
                    param305.ToString() + ", " +

                    //param311.ToString() + ", " +
                    //param314.ToString() + ", " +

                    // 水位
                    param401.ToString() + ", " +
                    param402.ToString() + ", " +
                    param411.ToString() + ", " +
                    param412.ToString() + ", " +

                    //震度
                    param501.ToString()
                );

            }


            // リストの内容をファイル（CSV)に書き込む（上書き）
            var csvFileName = string.Format("Z:/input{0}-{1}.csv", ProgressBar1.Minimum, ProgressBar1.Maximum);
            File.WriteAllLines(csvFileName, this.csvList, Encoding.GetEncoding("shift-jis"));


            Label1.Text = "完了しました。";
            MessageBox.Show("＼(^o^)／ｵﾜﾀ");
        }

    }
}
