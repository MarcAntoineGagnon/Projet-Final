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
    public sealed partial class Ajout_Trajet : Page
    {
        public Ajout_Trajet()
        {
            this.InitializeComponent();
            cbDepart.ItemsSource = GestionBD.getInstance().getVille();
            cbArrivee.ItemsSource = GestionBD.getInstance().getVille();
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            int erreur = 0;
            int id = 0;
            string strID = tbId.Text;
            Int32.TryParse(strID, out id);
            int idV = 0;
            string strIDV = tbIdVoiture.Text;
            Int32.TryParse(strIDV, out idV);
            int idC = 0 ;
            string strIDC = tbIdConducteur.Text;
            Int32.TryParse(strIDC, out idC);
            string date = "";
            string heureD = "";
            string heureA = "";
            string VilleD = "";
            string VilleA = "";
            try
            {
                date = dtDate.SelectedDate.Value.ToString("yyyy/MM/dd").Trim(); //ICI
            }

            catch (InvalidOperationException ex)
            {
                erreur++; tbErreurDate.Visibility = Visibility.Visible;
            }
            try
            {
                heureD = tpHeure_Dep.SelectedTime.Value.ToString().Trim();      //ICI
            }

            catch (InvalidOperationException ex)
            {
                erreur++; tbErreurHeure_Dep.Visibility = Visibility.Visible;
            }

            try
            {
                heureA = tpHeure_Arr.SelectedTime.Value.ToString().Trim();      //ICI
            }
            catch (InvalidOperationException ex)
            {
                erreur++; tbErreurHeure_Arr.Visibility = Visibility.Visible;
            }

            try
            {
                VilleD = cbDepart.SelectedValue.ToString();
            }
            catch (InvalidOperationException ex)
            {
                erreur++; tblErreurVille_Dep.Visibility = Visibility.Visible;
            }

            try
            {
                VilleA = cbArrivee.SelectedValue.ToString();
            }
            catch (InvalidOperationException ex)
            {
                erreur++; tblErreurDestination.Visibility = Visibility.Visible;
            }

            

            

            bool arret;
            if (cbArret.IsChecked == true)
                arret = true;
            else 
                arret = false;

            if (id == 0 || strID == "") { erreur++; tblErreurId.Visibility = Visibility.Visible; }

            if (idV == 0 || strIDC == ""){ erreur++; tblErreurIdConducteur.Visibility = Visibility.Visible; }

            if (idC == 0 || strIDV == ""){ erreur++; tblErreurIdVoiture.Visibility = Visibility.Visible; }

            if(erreur == 0)
            {
                GestionBD.getInstance().ajouterTrajet(new Trajet(id, idV, idC, date, heureD, heureA, VilleD, VilleA, arret));
                this.Frame.Navigate(typeof(Afficher_Trajet));
            }
        }

        private void reset()
        {
            tblErreurId.Visibility = Visibility.Collapsed;

            tblErreurIdConducteur.Visibility = Visibility.Collapsed;

            tblErreurIdVoiture.Visibility = Visibility.Collapsed;

            tbErreurDate.Visibility = Visibility.Collapsed;

            tbErreurHeure_Dep.Visibility = Visibility.Collapsed;

            tbErreurHeure_Arr.Visibility = Visibility.Collapsed;

            tblErreurVille_Dep.Visibility = Visibility.Collapsed;

            tblErreurDestination.Visibility = Visibility.Collapsed;
        }

    }
}
