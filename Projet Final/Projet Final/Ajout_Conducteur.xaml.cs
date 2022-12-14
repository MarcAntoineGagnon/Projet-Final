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
    public sealed partial class Ajout_Conducteur : Page
    {
        public Ajout_Conducteur()
        {
            this.InitializeComponent();
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            reset();

            int erreur = 0;
            string strID = tbID.Text;
            int id = 0;
            Int32.TryParse(strID, out id);
            string nom = tbNom.Text;
            string prenom = tbPrenom.Text;
            string adresse = tbAdresse.Text;
            string telephone = tbTelephone.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            double argent = 0;

            if (strID.Trim() == "" || id == 0)  { erreur++; tblErrID.Visibility = Visibility.Visible; }

            if(nom.Trim() == "")                { erreur++; tblErrNom.Visibility = Visibility.Visible; }

            if(prenom.Trim() == "")             { erreur++; tblErrPrenom.Visibility = Visibility.Visible; }

            if(adresse.Trim() == "")            { erreur++; tblErrAdresse.Visibility = Visibility.Visible; }

            if(telephone.Trim() == "")          { erreur++; tblErrTelephone.Visibility = Visibility.Visible; }

            if(email.Trim() == "")              { erreur++; tblErrEmail.Visibility = Visibility.Visible; }

            if(password.Trim() == "")           { erreur++; tblErrPassword.Visibility = Visibility.Visible; }

            if(erreur == 0)
            {
                GestionBD.getInstance().ajouterConducteur(new Conducteur(id, nom, prenom, adresse, telephone, email, password, argent));
                this.Frame.Navigate(typeof(Afficher_Conducteur));
            }
        }

        private void reset()
        {
            tblErrID.Visibility = Visibility.Collapsed;

            tblErrNom.Visibility = Visibility.Collapsed;

            tblErrPrenom.Visibility = Visibility.Collapsed;

            tblErrAdresse.Visibility = Visibility.Collapsed;

            tblErrTelephone.Visibility = Visibility.Collapsed;

            tblErrEmail.Visibility = Visibility.Collapsed;

            tblErrPassword.Visibility = Visibility.Collapsed;
        }
    }
}
