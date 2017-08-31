using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _reworkC_sharp.Models;
using System.IO;
using System.Web.Script.Serialization;

namespace _reworkC_sharp.Services
{
    public class StudentSrv
    {
        public const string Filename = "Student.json";
        //Hàm đọc file json trả về tất cả danh sách của file
       
        // Hàm lấy tất cả sinh viên => danh sách các dối tượng sinh viên
        public List<Student> GetAll()
        {
            //Hàm đọc qua file student.json => lấy về dữ liệu file là 1 chuỗi
            var dataJson = new FileSrv().ReadAllText(Filename);
            //Kiểm tra xem trong file đã có data hay chưa??
            if (string.IsNullOrEmpty(dataJson))
            {
                return new List<Student>();
            }
            //chuyển danh sách string thành danh sách các đối tượng 
            var serializer = new JavaScriptSerializer();
            var listStudent = (List<Student>)serializer.Deserialize<List<Student>>(dataJson);
            return listStudent;
        }

        //public Student Get(int id)
        //{
        //    var listStudent = GetAll();
        //    var student = listStudent.Where(x => x.Id == id).FirstOrDefault();
        //    return student;

        //}

        //Hàm chèn student
        public bool Insert(Student student)
        {
            var listStudent = GetAll();
            student.Id = listStudent.Max(x => x.Id) + 1;
            listStudent.Add(student);
           var serialize = new JavaScriptSerializer();
           var jsonData = serialize.Serialize(listStudent);
            var fileSrv = new FileSrv();
            fileSrv.Write(Filename, jsonData);
            return true;
        }

        public bool Edit(Student student)
        {
            var listStudent = GetAll();
            var studentInList = listStudent.FirstOrDefault(x => x.Id == student.Id);
            if (studentInList != null)
            {
                //lấy ra vị trí
                var index = listStudent.IndexOf(studentInList);
                //xóa vị trí vừa tìm ra khỏi danh sách
                listStudent.RemoveAt(index);
                //chèn student mới vào vị trí vừa xóa của danh sách
                listStudent.Insert(index, student);
                
            }
            var serializer = new JavaScriptSerializer();
            var jsonData = serializer.Serialize(listStudent);           
            new FileSrv().Write(Filename, jsonData);
            return true;
        }

        public bool Delete(Student student)
        {
            var listStudent = GetAll();
            var studentInList = listStudent.FirstOrDefault(x => x.Id == student.Id);
            if (studentInList != null)
            {
                //lấy ra vị trí
                var index = listStudent.IndexOf(studentInList);
                //xóa vị trí vừa tìm ra khỏi danh sách
                listStudent.RemoveAt(index);
            }
            var serializer = new JavaScriptSerializer();
            var jsonData = serializer.Serialize(listStudent);
            new FileSrv().Write(Filename, jsonData);
            return true;
        }

       
    }
}

