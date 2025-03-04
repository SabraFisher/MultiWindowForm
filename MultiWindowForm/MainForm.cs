namespace MultiWindowForm
{
    public partial class MainForm : Form
    {
        private NewCustomerForm _customerForm;
        private List<Customer> _customerList;
        public MainForm()
        {
            InitializeComponent();
            _customerForm = new NewCustomerForm(this);
            _customerList = new List<Customer>();
            _customerList.Add(new Customer
            {
                Name = "Jesse",
                Email = "jesse.harlan@centralia.edu",
                PhoneNumber = "555-2722"
            });

            ReloadDataGrid();
            //targets datagrid view to select whole row when only cell is selected
            dgvCustomers.Rows[0].Selected = true;
        }

        private void ReloadDataGrid()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _customerList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _customerForm.ShowDialog();
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
            ReloadDataGrid();
        }

        public void EditCustomer(int id, Customer updatedCustomer)
        {
            MessageBox.Show("Mainform is editing the custome now.");
            //find customer out of the list by id
            var cust = _customerList.Find(x => x.CustomerId == id);

            if (cust != null)
            {
                //found one, process the customer
                cust.Name = updatedCustomer.Name;
                cust.PhoneNumber = updatedCustomer.PhoneNumber;
                cust.Email = updatedCustomer.Email;

                ReloadDataGrid();
            }
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {

            //if (_customerForm)
            //{ 
            //    _customerForm = new NewCustomerForm(this); 
            //}

            // get the row out of the data grid view
            Customer cust;

            // get the position of the first selected item from the data grid view
            var index = dgvCustomers.SelectedRows[0].Index;

            // gets the exact customer out of the array
            cust = _customerList[index];

            // load the customer into the form
            _customerForm.LoadCustomer(cust);

            // show that we are editing not creating new customer on list
            _customerForm.ToggleEdit(true);


            // show the form
            _customerForm.Show();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = true;
        }
    }
}
