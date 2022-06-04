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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(@"data/master.f7n");

            Random r1 = new System.Random();

            // 堤体
            var param001 = r1.Next(10, 31); // 高さ 10m～30m
            editor_001.Edit(xmlDoc, param001);       // 堤体延長

            editor_002.Edit(xmlDoc, r1.Next(10, 101)/10);   // 堤体幅 1m～10m

            // 堤内側矢板天端高さ
            var param003 = r1.Next(10, 101) / 10; // 高さ 1m～10m
            editor_003.Edit(xmlDoc, param003);

            // 堤外側矢板天端高さ
            var param004 = r1.Next(10, 101) / 10; // 高さ 1m～10m
            editor_004.Edit(xmlDoc, param004);

            // 中詰土天端高さ
            var param005 = r1.Next(10, Math.Min(param003, param004) * 10 + 1) / 10; // 高さ 1m～堤内側と堤外側の低い方
            editor_005.Edit(xmlDoc, param005);

            // 引張材
            var max_h10 = Math.Min(param003, param004);

            var pich_10 = r1.Next(2, param001 * 5 + 1) / 10;                // 上段ピッチ 0.2m～堤体延長/2
            editor_010.Edit(xmlDoc, pich_10,       
                                    r1.Next(2, max_h10 * 10) / 10);         // 上段深さ   0.2m～矢板天端高さ
            var pich_11 = r1.Next(2, param001 * 5 + 1) / 10;                // 上段ピッチ 0.2m～堤体延長/2
            editor_011.Edit(xmlDoc, pich_11,                                
                                    r1.Next(2, max_h10 * 10) / 10);         // 下段深さ   0.2m～矢板天端高さ

            // 地層データ
            // 堤外区間地表面（現地盤）高G.L.
            editor_012.Edit(xmlDoc, r1.Next(0, param004 * 10 + 1) / 10);  // 0m ～ 堤外側矢板天端高さ

            // 堤外区間 土質条件
            string[] soil_jp = new string[2] { "粘性土", "砂質土" };
            string[] soil_en = new string[2] { "_Clay", "_Sandy" };
            int r = r1.Next(10, 21);        // 土の湿潤重量 10 ～ 20

            editor_013.Edit(xmlDoc,
                100,                        // 層厚 100m(固定
                soil_en[r1.Next(0, 2)],     // 土質
                r1.Next(0, 51),             // 平均N値 0 ～ 50
                r,                          // 土の湿潤重量
                r - 10,                     // 土の水中重量
                r + 1,                      // 土の飽和重量
                r1.Next(0, 51),             // 内部摩擦角 0 ～ 50°
                r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                0,                          // 粘着力 増分 0
                r1.Next(10, 2000)*100       // 変形係数 1000 ～ 200000
                );

            // 堤内区間地表面（現地盤）高G.L.
            editor_014.Edit(xmlDoc, r1.Next(0, param005 * 10 + 1) / 10);  // 0m ～ 中詰土端高さ

            // 堤内区間 中詰め 土質条件
            int soil_index = r1.Next(0, 2);
            editor_015.Edit(xmlDoc,
                soil_jp[soil_index],
                soil_en[soil_index],
                r1.Next(0, 51),             // 平均N値 0 ～ 50
                r,                          // 土の湿潤重量
                r - 10,                     // 土の水中重量
                r + 1,                      // 土の飽和重量
                r1.Next(0, 51),             // 内部摩擦角 0 ～ 50°
                r1.Next(0, 1000),           // 粘着力 0 ～ 1000
                0                          // 粘着力 増分 0
                );


            // 堤内区間 土質条件
            editor_016.Edit(xmlDoc,
                100,
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

            // 堤内区間地表面（現地盤）高G.L.
            editor_017.Edit(xmlDoc, r1.Next(0, param003 * 10 + 1) / 10);  // 0m ～ 堤内側矢板天端高さ

            // 堤内区間 土質条件
            editor_018.Edit(xmlDoc,
                100,
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
                                    0,                      // バネ定数 
                                    w1,                     // 腹起し材質  
                                    sNo,
                                    jNo + 1 ,
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
                                    0,                      // バネ定数 
                                    w1,                     // 腹起し材質    
                                    sNo,
                                    jNo + 1,
                                    w1.Replace("_", "")
                                    );

            // 常時ケース名
            // editor_026.Edit(xmlDoc, "高水位時");

            // 常時の水位
            editor_027.Edit(xmlDoc,
                r1.Next(0, param004 * 10 + 1) / 10,     // 堤外側水位 0m ～ 堤外側矢板天端高さ
                r1.Next(0, param003 * 10 + 1) / 10      // 堤内側水位 0m ～ 堤内側矢板天端高さ
                );

            // 常時鉛直力
            // editor_028.Edit(xmlDoc, 1.00000000000000E+000);


            // 地震時ケース名
            // editor_029.Edit(xmlDoc, "高水位時");

            // 地震時の水位
            editor_030.Edit(xmlDoc,
                r1.Next(0, param004 * 10 + 1) / 10,     // 堤外側水位 0m ～ 堤外側矢板天端高さ
                r1.Next(0, param003 * 10 + 1) / 10      // 堤内側水位 0m ～ 堤内側矢板天端高さ
                );

            // 空気中における震度
            editor_031.Edit(xmlDoc, r1.Next(1, 6) / 10); // Kh = 0.1 ～ 0.5

            // 地震時鉛直力
            // editor_032.Edit(xmlDoc, 1.00000000000000E+000);

            xmlDoc.Save(@"../../data/edited.f7n");

            MessageBox.Show("＼(^o^)／ｵﾜﾀ");
        }
    }
}
