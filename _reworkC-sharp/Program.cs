using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _reworkC_sharp.Services;
using _reworkC_sharp.Models;

namespace _reworkC_sharp
{
    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chương Trình Xử Lý Thông Tin Sinh Viên Qua file Sinhvien.json");
            Console.WriteLine("**************     **************************     ***************\n");


            Console.WriteLine("<--Chọn chức năng-->\n");
            Console.WriteLine("1.In danh sách sinh viên => nhấn phím P");
            Console.WriteLine("2.Thêm sinh viên vào danh sách => nhấn phím C");
            Console.WriteLine("3.Sửa sinh viên từ danh sách => nhấn phím E");
            Console.WriteLine("4.Xóa sinh viên từ danh sách => nhấn phím D");
            Console.WriteLine("5.Thoát chương trình => nhấn phím bất kỳ. Trừ các phím chức năng ở trên.");
            Console.WriteLine("..................................................................");

            Student student = new Student();

            while (true)
            {
                var key = Console.ReadKey().KeyChar;
                if (key == 'p')
                {
                    PrintAllStudent();
                }
                else if (key == 'c')
                {
                    Create(student);
                }
                else if (key == 'e')
                {
                    Edit(student);
                }
                else if (key == 'd')
                {
                    Delete(student);
                }
                else
                    break;
            }
            Console.ReadKey();

        }

        // Hàm in danh sách sinh viên
        public static void PrintAllStudent()
        {
            Console.WriteLine("Danh sách sinh viên:");
            //Get tat ca sinh vien nam trong file 
            var listStudent = new StudentSrv().GetAll();
            // Quét qua từng sinh viên có trong danh sách
            foreach (var student in listStudent)
            {
                // In ra từng sinh viên cho đến kết thúc danh sách => hàm ReadAllLine -> get từng obj sinh viên.
                Console.WriteLine(string.Format("{0}. Sinh viên {1} {2} tuổi", student.Id, student.Name, student.Age));

            }
            Console.ReadKey();

        }

        public static bool Create(Student student)
        {

            Console.WriteLine("Nhập họ tên:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Nhập tuổi:");
            student.Age = int.Parse(Console.ReadLine());
            new StudentSrv().Insert(student);
            return true;
        }

        public static bool Edit(Student student)
        {
            Console.WriteLine("Nhập id cần sửa: ");
            student.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập tên:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Nhập tuổi:");
            student.Age = int.Parse(Console.ReadLine());
            new StudentSrv().Edit(student);
            return true;
        }

        public static bool Delete(Student student)
        {
            Console.WriteLine("Nhập id cần xóa:");
            student.Id = int.Parse(Console.ReadLine());
            new StudentSrv().Delete(student);
            return true;
        }

    }
}
