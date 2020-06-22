using AppPersons.Models;
using AppPersons.Services;
using AppPersons.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace AppPersons.ViewModels
{
    public  class PersonsViewModel:BaseViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }
        public Command LoadPersonsCommand { get; set; }

        public PersonsViewModel()
        {
            Title = "BrowsePersonS";
            Persons = new ObservableCollection<Person>();
            LoadPersonsCommand = new Command(async () => await ExecuteLoadPersonsCommand());

            MessagingCenter.Subscribe<NewPersonPage, Person>(this, "AddPerson", async (obj, prs) =>
            {
                var newPerson = prs as Person;
                Persons.Add(newPerson);
                PrsDataStrore pd = new PrsDataStrore();
               await pd.AddPersonAsync(newPerson);

                //await DataStorePerson.AddPersonAsync(newPerson);
            });
        }

        async Task ExecuteLoadPersonsCommand()
        {
            IsBusy = true;

            try
            {
                Persons.Clear();

                //Persons.Add(new Person { TcNo = "11111111111", AdSoyad = "Ali bey" });
                //Persons.Add(new Person { TcNo = "22222222222", AdSoyad = "Ayşe hanım" });

                var sx = await new PrsDataStrore().GetPersonsAsync(true);
                foreach (var p in sx)
                {
                    Persons.Add(p);
                }

                //var prsS = await DataStorePerson.GetPersonsAsync(true);

                //foreach (var item in items)
                //{
                //    Items.Add(item);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}