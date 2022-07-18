using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace School_Data.Models
{
    public class StudentRepository : IStudentRepository
    {
        private DataClasses1DataContext _dataContext;
        private object s;

        public int Rollno { get; private set; }

        public StudentRepository()
        {
            _dataContext = new DataClasses1DataContext();
        }
        public IEnumerable<StudentModel> GetStudent()
        {
            IList<StudentModel> StuList = new List<StudentModel>();
            var query = from StudentModel in _dataContext.Student_news
                        select StudentModel;
            var Stu = query.ToList();
            foreach (var res in query)
            {
                StuList.Add(new StudentModel()
                {
                    Rollno = res.Rollno,
                    Name = res.Name,
                    Class = (int)res.Class,
                    Marks = (int)res.Marks,
                    Subject = res.Subject,
                    Mobile = (int)res.Mobile
                }); ;
            }
            return StuList;
        }

        public StudentModel GetStudentByRollno(int Rollno)
        {
            var query = from u in _dataContext.Student_news.Where(u => u.Rollno == Rollno)
                        select u;
            var user = query.FirstOrDefault();
            var model = new StudentModel()
            {
                Rollno = user.Rollno,
                Name = user.Name,
                Subject = user.Subject,
                Mobile = (int)user.Mobile,
                Marks = (int)user.Marks,
                Class = (int)user.Class

            };
            return model;
        }

        public void InsertStudent(StudentModel Stu)
        {
            var user = new Student_new()
            {
                Rollno = Stu.Rollno,
                Name = Stu.Name,
                Class = Stu.Class,
                Marks = Stu.Marks,
                Subject = Stu.Subject,
                Mobile = Stu.Mobile
            };
            _dataContext.Student_news.InsertOnSubmit(user);
            _dataContext.SubmitChanges();
        }

        public void DeleteStudent(int Rollno)
        {
            Student_new user = _dataContext.Student_news.Where(u => u.Rollno == Rollno).SingleOrDefault();
            _dataContext.Student_news.DeleteOnSubmit(user);
            _dataContext.SubmitChanges();
        }

         
        public void EditStudent(StudentModel Stu)
        {
            var user = new Student_new()
            {
                Rollno = Stu.Rollno,
                Name = Stu.Name,
                Class = Stu.Class,
                Marks = Stu.Marks,
                Subject = Stu.Subject,
                Mobile = Stu.Mobile
            };
            _dataContext.Student_news.InsertOnSubmit(user);
            _dataContext.SubmitChanges();
        }

        public void UpdateStudent(StudentModel Stu)
        {
            //var user = new Student_new();
            Student_new userData = _dataContext.Student_news.Where(u => u.Rollno == Stu.Rollno).SingleOrDefault();
            userData.Name = Stu.Name;
            userData.Rollno = Stu.Rollno;
            userData.Class = Stu.Class;
            userData.Marks = Stu.Marks;
            userData.Subject = Stu.Subject;
            userData.Mobile = Stu.Mobile;
            _dataContext.Student_news.GetModifiedMembers(userData);
            _dataContext.SubmitChanges();
        }



        /*  public void UpdateStudent(StudentModel Stu)
          {
              throw new NotImplementedException();
          }*/

    }
































        /*
                public void DeleteStudent(int Rollno)
                {
                    throw new NotImplementedException();
                }*/

        /* public IEnumerable<Student_new> GetStudent()
         {
             throw new NotImplementedException();
         }

         public Student_new GetStudentByRollno(int Rollno)
         {
             throw new NotImplementedException();
         }*/

        /* public void InsertStudent(Student_new Stu)
         {
             throw new NotImplementedException();
         }

         public void UpdateStudent(Student_new Stu)
         {
             throw new NotImplementedException();
         }*/
        /*
                StudentModel IStudentRepository.GetStudentByRollno(int Rollno)
                {
                    throw new NotImplementedException();
                }*/

        /* public void InsertStudent(StudentModel Stu)
         {
             throw new NotImplementedException();
         }

         public void UpdateStudent(StudentModel Stu)
         {
             throw new NotImplementedException();
         }*/

        /*   private class StudentDataContext
         *//*  {
               internal object Where(Func<object, bool> value)
               {
                   throw new NotImplementedException();
               }
           }*/
    }
