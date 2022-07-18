using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Data.Models
{
    internal interface IStudentRepository
    {
        IEnumerable<StudentModel> GetStudent();
        StudentModel GetStudentByRollno(int Rollno);
        void InsertStudent(StudentModel Stu);
        void DeleteStudent(int Rollno);
        void UpdateStudent(StudentModel Stu);
        void EditStudent(StudentModel Stu);
    }
}
