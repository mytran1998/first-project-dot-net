using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Helloworld.DAL.Entity
{
   
    public class SinhVien
    {
        public string maSinhVien;
        public string ho;
        public string ten;
        public DateTime ngaySinh;
        public SEX gioiTinh;
        public string queQuan;
        public virtual ICollection<QuaTrinhHocTap> listQuaTrinhHocTap { get; set; }

        public string MaSinhVien { get => maSinhVien; set => maSinhVien = value; }
        public string Ho { get => ho; set => ho = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public SEX GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }

        /// <summary>
        /// Lấy sinh viên ảo
        /// </summary>
        /// <param name="MaSinhVien"></param>
        /// <returns></returns>
        public static SinhVien Get(string MaSinhVien)
        {
            SinhVien sv = new SinhVien
            {
                maSinhVien = MaSinhVien,
                ho = "Tran",
                ten = "Nam My",
                ngaySinh = DateTime.Now.Date,
                queQuan = "Quang Binh",
                gioiTinh = SEX.Male, 
            };
            sv.listQuaTrinhHocTap = QuaTrinhHocTap.GetList(MaSinhVien);
            return sv;
        }

        /// <summary>
        /// Lấy sinh viên từ File datastudent.txt
        /// <param name="maSinhVien"></param>
        /// <returns></returns>
        public static SinhVien GetFromFile(string pathFile ,string maSinhVien)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var arrLines = File.ReadAllLines(pathFile);
            foreach(var line in arrLines)
            {
                if (line.Contains(maSinhVien))
                {
                    var lsValue = line.Split('#');
                    var sinhVien = new SinhVien
                    {
                        maSinhVien = lsValue[0],
                        ho = lsValue[1],
                        ten = lsValue[2],
                        gioiTinh = lsValue[3] == "Male" ? SEX.Male : (lsValue[3] == "Female") ? SEX.Male : SEX.Other,
                        ngaySinh = DateTime.ParseExact(lsValue[4], "yyyy-MM-dd", provider),
                        queQuan = lsValue[5]
                    };
                    if(sinhVien.maSinhVien == maSinhVien)
                    {
                        return sinhVien;
                    }
                }
            }
            return null;
        }
    }

    public enum SEX
    {
        Female, Male, Other
        // 0, 1, 2
    }
}
