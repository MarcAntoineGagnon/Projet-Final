using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
        }

        private void connexion_Click(object sender, RoutedEventArgs e)
        {
            Errconnexion.Visibility = Visibility.Collapsed;

            string email = tbEmail.Text;
            string password = tbPassword.Password.ToString();
            int type = cbType.SelectedIndex;
            int test = 0;

            if(email != "" && password != "")
            {
                if (type == 0)
                {
                    test = GestionBD.getInstance().connexionAdmin(email, password);
                    if (test != 0)
                        this.Frame.Navigate(typeof(Afficher_Trajet));
                    else
                        Errconnexion.Visibility = Visibility.Visible;
                }
                    
                if(type == 1)
                {
                    test = GestionBD.getInstance().connexionConducteur(email, password);
                    if (test != 0)
                        this.Frame.Navigate(typeof(Afficher_Trajet));
                    else
                        Errconnexion.Visibility = Visibility.Visible;
                }
                    
                if (type == 2)
                {
                    test = GestionBD.getInstance().connexionPassager(email, password);
                    if (test != 0)
                        this.Frame.Navigate(typeof(Afficher_Trajet));
                    else
                        Errconnexion.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Errconnexion.Visibility = Visibility.Visible;
            }
        }
    }
}
