using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _reworkC_sharp.Services
{
    public class FileSrv
    {
        // lấy về tất cả các dòng của file => chuỗi

        public string ReadAllText(string filename)
        {
            //Kiểm tra file có tồn tại ??
            if (!File.Exists(filename))
            {
                var f = File.Create(filename);
                f.Close();
            }
           return File.ReadAllText(filename);
        }


        // lấy vè tất cả các dòng của file => danh sách chuỗi

        public List<string> ReadAllLine(string filename)
        {
            //Kiểm tra file có tồn tại ??
            if (!File.Exists(filename))
            {
                var f = File.Create(filename);
                f.Close();
            }
            return File.ReadAllLines(filename).ToList();
        }

        public void Write(string FileName,string FileToWrite )
        {
            File.WriteAllText(FileName, FileToWrite);
        }
    }
}
