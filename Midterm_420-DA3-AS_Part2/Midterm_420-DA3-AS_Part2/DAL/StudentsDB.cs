using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm_420_DA3_AS_Part2.BLL;

namespace Midterm_420_DA3_AS_Part2.DAL
{
    internal class StudentsDB
    {

        public static void SaveRecord(Students student)
        {

            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = connDB;
            cmdInsert.CommandText = "INSERT INTO Student (StudentNumber, LastName, FirstName, PhoneNumber, Email)" +
                              "VALUES(@StudentNumber, @LastName, @FirstName, @PhoneNumber, @Email)";
            cmdInsert.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            cmdInsert.Parameters.AddWithValue("@LastName", student.LastName);
            cmdInsert.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", student.Email);

            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }

        public static List<Students> GetAllRecords()
        {
            List<Students> listS = new List<Students>();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Student", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Students student;

            while (reader.Read())
            {

                student = new Students();

                student.StudentNumber = Convert.ToInt32(reader["StudentNumber"]);
                student.LastName = reader["LastName"].ToString();
                student.FirstName = reader["FirstName"].ToString();
                student.PhoneNumber = reader["PhoneNumber"].ToString();
                student.Email = reader["Email"].ToString();

                listS.Add(student);

            }

            conn.Close();
            return listS;
        }

    
        public static List<Students> SearchLName(string inputStudentLName)
        {
            List<Students> listU = new List<Students>();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelectByStudentsName = new SqlCommand();
            cmdSelectByStudentsName.Connection = conn;
            cmdSelectByStudentsName.CommandText = "SELECT * FROM Student " +
                                                "Where LastName = @LastName";
            cmdSelectByStudentsName.Parameters.AddWithValue("@LastName", inputStudentLName);
            SqlDataReader reader = cmdSelectByStudentsName.ExecuteReader();

            Students student;

            while (reader.Read())
            {
                student = new Students();
                student.StudentNumber = Convert.ToInt32(reader["StudentNumber"]);
                student.LastName = reader["LastName"].ToString();
                student.FirstName = reader["FirstName"].ToString();
                student.PhoneNumber = reader["PhoneNumber"].ToString();
                student.Email = reader["Email"].ToString();
                listU.Add(student);
            }

            conn.Close();
            return listU;
        }

        public static List<Students> SearchSNumber(int inputStudentNumber)
        {
            List<Students> listU = new List<Students>();
            SqlConnection conn = UtilityDB.ConnectDB();
            SqlCommand cmdSelectByStudentsName = new SqlCommand();
            cmdSelectByStudentsName.Connection = conn;
            cmdSelectByStudentsName.CommandText = "SELECT * FROM Student " +
                                                "Where StudentNumber = @StudentNumber";
            cmdSelectByStudentsName.Parameters.AddWithValue("@StudentNumber", inputStudentNumber);
            SqlDataReader reader = cmdSelectByStudentsName.ExecuteReader();

            Students student;

            while (reader.Read())
            {
                student = new Students();
                student.StudentNumber = Convert.ToInt32(reader["StudentNumber"]);
                student.LastName = reader["LastName"].ToString();
                student.FirstName = reader["FirstName"].ToString();
                student.PhoneNumber = reader["PhoneNumber"].ToString();
                student.Email = reader["Email"].ToString();
                listU.Add(student);
            }

            conn.Close();
            return listU;
        }


        public static bool IsUniqueStudentsNumber(int studentNumber)
        {
            List<Students> listU = GetAllRecords();
            foreach (Students u in listU)
            {
                if (u.StudentNumber == studentNumber)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
