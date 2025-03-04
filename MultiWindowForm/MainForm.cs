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
                PhoneNumber = "3605552722"
            });
            ReloadDataGrid();
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
            var cust = _customerList.Find(x => x.CustomerId == id);

            if (cust != null)
            {
                cust.Name = updatedCustomer.Name;
                cust.PhoneNumber = updatedCustomer.PhoneNumber;
                cust.Email = updatedCustomer.Email;
            }
            
            ReloadDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Customer cust;
            var index = dgvCustomers.SelectedRows[0].Index;
            cust = _customerList[index];
            _customerForm.LoadCustomer(cust);
            _customerForm.ToggleEdit(true);
            _customerForm.Show();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = true;
            ReloadDataGrid();
        }
    }
}
