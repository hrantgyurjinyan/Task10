using System.Windows;


namespace Task10
{

        public partial class MainWindow : Window
        {
            private MainViewModel _viewModel;

            public MainWindow()
            {
                InitializeComponent();
                _viewModel = new MainViewModel();
                DataContext = _viewModel;
            }

            private void AddPerson_Click(object sender, RoutedEventArgs e)
            {
                if (int.TryParse(idTextBox.Text, out int id) &&
                    !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                    int.TryParse(ageTextBox.Text, out int age))
                {
                    _viewModel.AddPerson(new Person { Id = id, Name = nameTextBox.Text, Age = age });
                    idTextBox.Clear();
                    nameTextBox.Clear();
                    ageTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter valid values for ID, Name, and Age.");
                }
            }

            private void SortByName_Click(object sender, RoutedEventArgs e)
            {
                _viewModel.SortByName();
            }

            private void SortByAge_Click(object sender, RoutedEventArgs e)
            {
                _viewModel.SortByAge();
            }

            private void SearchByName_Click(object sender, RoutedEventArgs e)
            {
                string name = searchBox.Text;
                var result = _viewModel.SearchByName(name);
                if (result != null)
                {
                    MessageBox.Show($"Person found - ID: {result.Id}, Name: {result.Name}, Age: {result.Age}");
                }
                else
                {
                    MessageBox.Show("Person not found.");
                }
            }

            private void SearchByAge_Click(object sender, RoutedEventArgs e)
            {
                if (int.TryParse(searchAgeBox.Text, out int age))
                {
                    var result = _viewModel.SearchByAge(age);
                    if (result != null)
                    {
                        MessageBox.Show($"Person found - ID: {result.Id}, Name: {result.Name}, Age: {result.Age}");
                    }
                    else
                    {
                        MessageBox.Show("Person not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid age.");
                }
            }
        }
    


}

