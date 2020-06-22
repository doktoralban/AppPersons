using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppPersons.Models;
using AppPersons.Views;
using AppPersons.ViewModels;

namespace AppPersons.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class PersonsPage : ContentPage
    {
        PersonsViewModel viewModel;

        public PersonsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PersonsViewModel();
        }

        async void OnPersonSelected(object sender, EventArgs args)
        {
            //var layout = (BindableObject)sender;
            //var item = (Item)layout.BindingContext;
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddPerson_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPersonPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Persons.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}