using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace User_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<User> list = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            string path1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fullpath = Path.Combine(path1, "user.txt");
            if (File.Exists(fullpath))
            {
                string jsondata = File.ReadAllText(fullpath);
                list = JsonConvert.DeserializeObject<List<User>>(jsondata);
            }
            if (list != null && list.Count > 0)
            {
                cmbnames.ItemsSource = null;
                listuser.ItemsSource = null;
                cmbnames.DisplayMemberPath = "name";
                cmbnames.ItemsSource = list;
                listuser.ItemsSource = list;
            }
              txtUserCount.Text = (list?.Count ?? 0) + ((list?.Count ?? 0) == 1 ? "user" : "users");
              txtStatus.Text = "Registered users Loaded successfully";
            
            }
        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            
           
           // User user = new User();
           // user.name = txtname.Text;
           // user.email = txtEmail.Text;
           // user.phone = txtPhone.Text;
           // user.locations = txtLocation.Text;
           // list.Add(user);

            list.Add(new User {name=txtname.Text,email=txtEmail.Text,phone=txtPhone.Text,locations=txtLocation.Text});
            string listdatajson = JsonConvert.SerializeObject(list);

            string path1 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fullpath = Path.Combine(path1, "user.txt");
            File.WriteAllText(fullpath, listdatajson);


            cmbnames.ItemsSource = null;
            listuser.ItemsSource = null;
            cmbnames.DisplayMemberPath = "name";
            cmbnames.ItemsSource = list;
            listuser.ItemsSource = list;

            txtUserCount.Text = list.Count + (list.Count == 1 ? "user" : "users");
            txtStatus.Text = txtname.Text + "registered successfully";
             
        }
        private void cmbnames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            User value = cmbnames.SelectedItem as User;
            if (value != null)
            { 
                txtEmail.Text = value.email;
                txtname.Text = value.name;
                txtPhone.Text = value.phone;
                txtLocation.Text = value.locations;
            }
        }

    }
}