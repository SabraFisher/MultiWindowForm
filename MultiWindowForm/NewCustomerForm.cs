using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformTodo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MultiWindowForm
{
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount;
        private bool IsEditing;
        private int CurrentSelectionId;
        
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
            CurrentSelectionId = -1;
        }

        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
            _mainForm.EditCustomer(0, new Customer());
        }

        private void CreateCustomer()
        {
            if (!EntryIsValid())
            {
                MessageBox.Show("Invalid entry, please try again.");
                return;
            }

            Customer customer = new Customer
            {
                CustomerId = CustomerCount,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            };

            _mainForm.AddCustomer(customer);

            CustomerCount++;
        }

        private void EditCustomer()
        {
            if (!EntryIsValid())
            {
                MessageBox.Show("Invalid entry, please try again.");
                return;
            }

            _mainForm.EditCustomer(CurrentSelectionId, new Customer
            {
                CustomerId = CurrentSelectionId,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            });

            CurrentSelectionId = -1;
            ToggleEdit(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                EditCustomer();
            }
            else 
            {
                CreateCustomer();
            }
            ClearForm();
            Hide();
            
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";

        }

        public void LoadCustomer(Customer customer)
        {
            CurrentSelectionId = customer.CustomerId;
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhoneNumber.Text = customer.PhoneNumber;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private bool EntryIsValid()
        {
            bool validEntry = true;

            if (Validators.IsEmptyText(txtName) || Validators.IsTextNull(txtName))
            {
                MessageBox.Show("Name required. Please try again.");
                return !validEntry;
            }

            if (Validators.IsEmptyText(txtEmail) || Validators.IsTextNull(txtEmail))
            {
                MessageBox.Show("Email required. Please try again.");
                return !validEntry;
            }

            if (Validators.IsEmptyText(txtPhoneNumber))
            {
                MessageBox.Show("Phone number required. Please try again.");
                return !validEntry;
            }

            if (!Validators.IsCorrectLength(txtPhoneNumber, 10))
            {
                MessageBox.Show("Phone number must be 10 digits.");
                return !validEntry;
            }

            return validEntry;
        }
    }
}
