using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppPersons.Models;



namespace AppPersons.Views
{
    [DesignTimeVisible(false)]
    public partial class NewPersonPage : ContentPage
    {
        public Person Item { get; set; }

        public NewPersonPage()
        {
            InitializeComponent();

            Item = new Person
            {
                TcNo = "",
                AdSoyad= ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPerson", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }



    }
}