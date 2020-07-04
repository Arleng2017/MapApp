using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MapApp.View
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();

            GameContent.Source = "https://hr-hotel.azurewebsites.net/";
        }
    }
}
