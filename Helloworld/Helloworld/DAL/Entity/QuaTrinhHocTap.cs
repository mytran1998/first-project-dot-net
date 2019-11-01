using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld.DAL.Entity
{
    public class QuaTrinhHocTap
    {
        private int stt;
        public string maQuaTrinhHocTap;
        public int tuNam;
        public int denNam;
        public string thoiGianHoc
        {
            get
            {
                return string.Format("{0} -> {1}", tuNam, denNam);
            }
        }
        public string hocTai;
        public string maSinhVien;
        public virtual SinhVien SinhVien { get; set; }

        public string MaQuaTrinhHocTap { get => maQuaTrinhHocTap; set => maQuaTrinhHocTap = value; }
        public int TuNam { get => tuNam; set => tuNam = value; }
        public int DenNam { get => denNam; set => denNam = value; }
        public string HocTai { get => hocTai; set => hocTai = value; }
        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public int Stt { get => stt; set => stt = value; }

        /// <summary>
        /// Lấy danh sách quá trình học tập của sinh viên
        /// </summary>
        /// <param name="maSinhVien"> Mã sinh viên học sinh viên cần lấy</param>
        /// <returns>Danh sách quá trình học tập</returns>
        public static List<QuaTrinhHocTap> GetList(string MaSinhVien)
        {
            List<QuaTrinhHocTap> listQuaTrinhHocTaps = new List<QuaTrinhHocTap>();
            for (int i = 0; i < 5; i++) {
                QuaTrinhHocTap quaTrinhHocTap = new QuaTrinhHocTap {
                    maQuaTrinhHocTap = i.ToString(),
                    tuNam = 1990 + i,
                    denNam = 1990 + i + 1,
                    hocTai = "Phan Boi Chau",
                    maSinhVien = MaSinhVien 
                };
                listQuaTrinhHocTaps.Add(quaTrinhHocTap);
            }
            return listQuaTrinhHocTaps;
        }

        /// <summary>
        /// Lấy quá trình học tập từ file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="maSinhVien"></param>
        /// <returns></returns>
        public static List<QuaTrinhHocTap> getQthtFromFile(string path, string maSinhVien)
        {
            List<QuaTrinhHocTap> list = new List<QuaTrinhHocTap>();
            var arrLines = File.ReadAllLines(path);
            int sott = 1;
            foreach(var line in arrLines)
            {
                if (line.Contains(maSinhVien))
                {
                    var lsValue = line.Split('|');
                    QuaTrinhHocTap qtht = new QuaTrinhHocTap
                    {
                        stt = sott,
                        maQuaTrinhHocTap = lsValue[1],
                        tuNam = Int32.Parse(lsValue[2]),
                        denNam = Int32.Parse(lsValue[3]),
                        hocTai = lsValue[4]
                    };
                    list.Add(qtht);
                    sott += 1;
                }
            }
            return list != null ? list : null;
        }

        public static int getMaqTHTFinal(string pathDataQTHT, string maSv)
        {
            List<QuaTrinhHocTap> list = QuaTrinhHocTap.getQthtFromFile(pathDataQTHT, maSv);
            return Int32.Parse(list[list.Count - 1].maQuaTrinhHocTap);
        }

        public static void deleteQTHT(string pathDataQTHT, string maQTHT)
        {
            string[] lines = File.ReadAllLines(pathDataQTHT);

            // Xóa hết
            File.WriteAllText(pathDataQTHT, "");

            // Ghi lại nếu không trùng mã 
            using (StreamWriter writer = new StreamWriter(pathDataQTHT))
            {
                foreach (string line in lines)
                {
                      var lsValue = line.Split('|');
                      // Lấy mã quá trình học tập
                      string maQuaTrinhHocTap = lsValue[1];
                      if (!maQuaTrinhHocTap.Contains(maQTHT))
                      {
                            writer.WriteLine(line);
                      }
                }
                writer.Flush();
                writer.Close();
            }
        }

        public static void updateQTHT(string pathDataQTHT, string maSV, string maQTHT, int tuNam, int denNam, string hocTai)
        {
            // Lấy dữ liệu
            string[] data = File.ReadAllLines(pathDataQTHT);
            // Xóa hết
            File.WriteAllText(pathDataQTHT, "");

            using(StreamWriter writer = new StreamWriter(pathDataQTHT))
            {
                foreach(string line in data)
                {   
                    var lsValue = line.Split('|');
                    // Lấy mã quá trình học tập     
                    if (lsValue[0].Contains(maSV))
                    {
                        string maQuaTrinhHocTap = lsValue[1];
                        if (maQuaTrinhHocTap.Contains(maQTHT))
                        {
                            writer.WriteLine(maSV + "|" + maQTHT + "|" + tuNam + "|" + denNam + "|" + hocTai);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                      
                }
                writer.Flush();
                writer.Close();
            }
        }

        public static void addQTHT(string pathDataQTHT, string maSV, int tuNam, int denNam, string hocTai)
        {
            int maQTHT = getMaqTHTFinal(pathDataQTHT, maSV) + 1;
            using (StreamWriter writer = new StreamWriter(pathDataQTHT, true))
            {
                writer.WriteLine(maSV + "|" + maQTHT + "|" + tuNam + "|" + denNam + "|" + hocTai);
                writer.Flush();
                writer.Close();
            }
        }
    }
}
