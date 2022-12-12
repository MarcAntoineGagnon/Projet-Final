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
    public sealed partial class Ajout_Voiture : Page
    {
        public Ajout_Voiture()
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
            string strNb_place = tbNb_place.Text;
            int Nb_place = 0;
            Int32.TryParse(strNb_place, out Nb_place);
            string strPrix = tbPrix.Text;
            int Prix_passager = 0;
            Int32.TryParse(strPrix, out Prix_passager);
            string Type_vehicule = tbType_vehicule.Text;

            if (strID.Trim() == "" || id == 0) { erreur++; tblErrID.Visibility = Visibility.Visible; }

            if (Type_vehicule.Trim() == "") { erreur++; tblErrType.Visibility = Visibility.Visible; }

            if (strNb_place.Trim() == "" || Nb_place == 0) { erreur++; tblErrNb_place.Visibility = Visibility.Visible; }

            if (strPrix.Trim() == "" || Prix_passager == 0) { erreur++; tblErrPrix.Visibility = Visibility.Visible; }

            if (erreur == 0)
            {
                GestionBD.getInstance().ajouterVoiture(new Voiture(id, Type_vehicule, Nb_place, Prix_passager));
                this.Frame.Navigate(typeof(Afficher_Voiture));
            }

        }

        private void reset()
        {
            tblErrID.Visibility = Visibility.Collapsed;

            tblErrType.Visibility = Visibility.Collapsed;
            
            tblErrNb_place.Visibility = Visibility.Collapsed;
            
            tblErrPrix.Visibility = Visibility.Collapsed;
        }
    }
    
}
