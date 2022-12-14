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
    public sealed partial class Ajout_Ville : Page
    {
        public Ajout_Ville()
        {
            this.InitializeComponent();
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            int erreur = 0;
            string Ville = tbVille.Text;

            if (Ville.Trim() == "") { erreur++; tblErrVille.Visibility = Visibility.Visible; }

            if (erreur == 0)
            {
                GestionBD.getInstance().ajouterVille(new Ville( Ville));
                this.Frame.Navigate(typeof(Afficher_Conducteur));
            }

        }

        private void reset()
        {
            tblErrVille.Visibility = Visibility.Collapsed;
        }
        }
    }
