using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm_420_DA3_AS_Part2.DAL;
using Midterm_420_DA3_AS_Part2.GUI;

namespace Midterm_420_DA3_AS_Part2.BLL
{
    internal class Students
    {
        private int studentNumber;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string email;

        
        public int StudentNumber { get => studentNumber; set => studentNumber = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        


        public Students(int studentNumber, string lastName, string firstName, string phoneNumber, string email)
        {
            this.StudentNumber = studentNumber;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.PhoneNumber = phoneNumber;
            this.email = email;
        }

        public Students()
        {
            //studentNumber = Convert.ToInt32(string.Empty);
            lastName = string.Empty;
            firstName = string.Empty;
            phoneNumber = string.Empty;
            email = string.Empty;
        }

        public void SaveStudent(Students student)
        {
            StudentsDB.SaveRecord(student);
        }

        public List<Students> GetAllStudents()
        {
            return StudentsDB.GetAllRecords();
        }

        public List<Students> SearchUser(string studentLName)
        {
            return StudentsDB.SearchLName(studentLName);
        }

        public bool IsUniqueUniqueName(int studentNumber) => StudentsDB.IsUniqueStudentsNumber(studentNumber);

    }
}
