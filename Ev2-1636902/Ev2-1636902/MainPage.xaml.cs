using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ev2_1636902
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ricardo")
            {
                if (txtPassword.Text == "1226")
                {
                    DisplayAlert("Success", "Bienvenido al sistema " + txtUsuario.Text, "Continue");
                    Navigation.PushAsync(new Campeones());
                }
                else
                {
                    DisplayAlert("Alert", "Error, Contraseña incorrecta para el usuario asignado", "Ok");
                }
            }
            else
            {
                DisplayAlert("Alert", "Error, el usuario no existe o no es correcto", "Ok");
            }
        }


    }
}
