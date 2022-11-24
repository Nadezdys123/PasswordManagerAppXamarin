using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PasswordManagerApp.Models;

namespace PasswordManagerApp.Views
{

    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(usernameEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text)
                && !string.IsNullOrWhiteSpace(webEntry.Text) && !string.IsNullOrWhiteSpace(noteEntry.Text))
            {
                await App.Database.SavePersonAsync(new DataClass
                {
                    Title = nameEntry.Text,
                    Username = usernameEntry.Text,
                    Password = passwordEntry.Text,
                    Webpage = webEntry.Text,
                    Note = noteEntry.Text,
                    //Age = int.Parse(ageEntry.Text)
                });

                //nameEntry.Text = ageEntry.Text = string.Empty;
                //listView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}