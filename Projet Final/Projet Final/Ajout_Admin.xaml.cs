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
    public sealed partial class Ajout_Admin : Page
    {
        public Ajout_Admin()
        {
            this.InitializeComponent();
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            reset();
            string strID = tbID.Text;
            int id = 0;
            Int32.TryParse(strID, out id);
            string nom = tbNom.Text;
            string prenom = tbPrenom.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;

            if(nom.Trim() != "" && prenom.Trim() != "" && email.Trim() != "" && password.Trim() != "" && id != 0)
            {
                GestionBD.getInstance().ajouterAdmin(new Admin(id, nom, prenom, email, password));
                this.Frame.Navigate(typeof(Afficher_Admin));
            }
            else
            {
                if (strID.Trim() == "" || id == 0)
                    tblErrID.Visibility = Visibility.Visible;
                if (nom.Trim() == "")
                    tblErrNom.Visibility = Visibility.Visible;
                if (prenom.Trim() == "")
                    tblErrPrenom.Visibility = Visibility.Visible;
                if (email.Trim() == "")
                    tblErrEmail.Visibility = Visibility.Visible;
                if (password.Trim() == "")
                    tblErrPassword.Visibility = Visibility.Visible;
            }
        }

        private void reset()
        {
            tblErrID.Visibility = Visibility.Collapsed;
            tblErrNom.Visibility = Visibility.Collapsed;
            tblErrPrenom.Visibility = Visibility.Collapsed;
            tblErrEmail.Visibility = Visibility.Collapsed;
            tblErrPassword.Visibility = Visibility.Collapsed;
        }
    }
}
