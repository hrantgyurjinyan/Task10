using System.Collections.ObjectModel;
using System.Windows;

namespace Task10
{
    public class MainViewModel
    {
        public ObservableCollection<Person> People { get; set; }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
        }

        // Add a new person to the collection
        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        // Remove a person from the collection by Id
        public void RemovePerson(int id)
        {
            var personToRemove = People.FirstOrDefault(p => p.Id == id);
            if (personToRemove != null)
            {
                People.Remove(personToRemove);
            }
            else
            {
                MessageBox.Show("Person with specified Id not found.");
            }
        }

        // Sort people by age (Bubble Sort)
        public void SortByAge()
        {
            for (int i = 0; i < People.Count - 1; i++)
            {
                for (int j = 0; j < People.Count - 1 - i; j++)
                {
                    if (People[j].Age > People[j + 1].Age)
                    {
                        var temp = People[j];
                        People[j] = People[j + 1];
                        People[j + 1] = temp;
                    }
                }
            }
        }

        // Sort people by name (Bubble Sort)
        public void SortByName()
        {
            for (int i = 0; i < People.Count - 1; i++)
            {
                for (int j = 0; j < People.Count - 1 - i; j++)
                {
                    if (string.Compare(People[j].Name, People[j + 1].Name) > 0)
                    {
                        var temp = People[j];
                        People[j] = People[j + 1];
                        People[j + 1] = temp;
                    }
                }
            }
        }

        // Search for a person by name
        public Person SearchByName(string name)
        {
            return People.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Search for a person by age
        public Person SearchByAge(int age)
        {
            return People.FirstOrDefault(p => p.Age == age);
        }
    }
}

