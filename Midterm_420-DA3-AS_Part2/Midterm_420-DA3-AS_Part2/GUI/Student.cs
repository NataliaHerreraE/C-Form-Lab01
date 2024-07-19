using Midterm_420_DA3_AS_Part2.VALIDATION;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Midterm_420_DA3_AS_Part2.BLL;
using Midterm_420_DA3_AS_Part2.DAL;

namespace Midterm_420_DA3_AS_Part2.GUI
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            int input = 0;
            input = Convert.ToInt32(txtStudentNum.Text.Trim());
            if ((!student.IsUniqueUniqueName(input)))
            {
                MessageBox.Show("username already exists, please enter other", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentNum.Clear();
                txtStudentNum.Focus();
                return;
            }

            string input2 = "";
            input2 = txtStudentNum.Text.Trim();
            if (!Validator.IsValidID(input2))
            {
                MessageBox.Show("Invalid StudentNumber ID, must be 7-digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentNum.Clear();
                txtStudentNum.Focus();
                return;
            }
            input2 = txtLastName.Text.Trim();
            if (!Validator.IsValidName(input2))
            {
                MessageBox.Show("Invalid Last Name, please enter another.", "Invalid");
                txtLastName.Clear();
                txtLastName.Focus();
                return;
            }

            input2 = txtFirstName.Text.Trim();
            if (!Validator.IsValidName(input2))
            {
                MessageBox.Show("Invalid First Name, please enter another.", "Invalid");
                txtFirstName.Clear();
                txtFirstName.Focus();
                return;
            }

            input2 = txtEmail.Text.Trim();
            if (!Validator.IsValidEmail(input2))
            {
                MessageBox.Show("Invalid Email Format, Please enter another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Clear();
                txtEmail.Focus();
                return;
            }

            input2 = txtPhoneNum.Text.Trim();
            if (!Validator.IsValidPhoneNumberFormat(input2))
            {
                MessageBox.Show("Invalid Phone Number Format" + "\nPlease try again: for example, (514)555-5555", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNum.Clear();
                txtPhoneNum.Focus();
                return;
            }

            student.StudentNumber = Convert.ToInt32(txtStudentNum.Text.Trim());
            student.LastName = txtLastName.Text.Trim();
            student.FirstName = txtFirstName.Text.Trim();
            student.PhoneNumber = txtPhoneNum.Text.Trim();
            student.Email = txtEmail.Text.Trim();
            student.SaveStudent(student);
            MessageBox.Show("New Student has been saved successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            List<Students> listU = new List<Students>();

            string searchCriteria = comBoxSearchBy.SelectedItem.ToString();
            string searchText = txtSearchBy.Text.Trim(); 

            
            if (searchCriteria == "StudentNumber" && int.TryParse(searchText, out int studentNumber))
            {
                listU = StudentsDB.SearchSNumber(studentNumber); 
            }
            else if (searchCriteria == "LastName")
            {
                listU = student.SearchUser(searchText);
            }
            else
            {
                MessageBox.Show("Please select a valid search criteria and ensure the input format is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DisplayInfo(listU, listViewUser);
        }

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            Students student = new Students();
            List<Students> listU = student.GetAllStudents();
            DisplayInfo(listU, listViewUser);
        }
        private void DisplayInfo(List<Students> listU, ListView listV)
        {
            listV.Items.Clear(); 

            if (listU.Count != 0)
            {
                foreach (Students student in listU)
                {
                    ListViewItem item = new ListViewItem(student.StudentNumber.ToString());
                    item.SubItems.Add(student.LastName);
                    item.SubItems.Add(student.FirstName);
                    item.SubItems.Add(student.PhoneNumber);
                    item.SubItems.Add(student.Email);

                    listV.Items.Add(item); 
                }
            }
            else
            {
                MessageBox.Show("No Students in the database.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this app? ", "Exit ", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void comBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
