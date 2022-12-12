using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        internal static string connecter = "Personne";
        internal static int id = 0;
        public MainWindow()
        {
            this.InitializeComponent();
            tblHeader.Text = "Liste Trajet";
            mainFrame.Navigate(typeof(Afficher_Trajet));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iAjoutTrajet":
                    tblHeader.Text = "Ajout Trajet";
                    mainFrame.Navigate(typeof(Ajout_Trajet));
                    break;
                case "iListeTrajet":
                    tblHeader.Text = "Liste Trajet";
                    mainFrame.Navigate(typeof(Afficher_Trajet));
                    break;
                case "iListeAdmin":
                    tblHeader.Text = "Liste Administrateur";
                    mainFrame.Navigate(typeof(Afficher_Admin));
                    break;
                case "iAjoutAdmin":
                    tblHeader.Text = "Ajout Administrateur";
                    mainFrame.Navigate(typeof(Ajout_Admin));
                    break;
                case "iAjoutConducteur":
                    tblHeader.Text = "Ajout Conducteur";
                    mainFrame.Navigate(typeof(Ajout_Conducteur));
                    break;
                case "iListeConducteur":
                    tblHeader.Text = "Liste Conducteur";
                    mainFrame.Navigate(typeof(Afficher_Conducteur));
                    break;
                case "iAjoutPassager":
                    tblHeader.Text = "Ajout Passager";
                    mainFrame.Navigate(typeof(Ajout_Passager));
                    break;
                case "iListePassager":
                    tblHeader.Text = "Liste Passager";
                    mainFrame.Navigate(typeof(Afficher_Passager));
                    break;
                case "iListeVille":
                    tblHeader.Text = "Liste Ville";
                    mainFrame.Navigate(typeof(Afficher_Ville));
                    break;
                case "iAjoutVille":
                    tblHeader.Text = "Ajout Ville";
                    mainFrame.Navigate(typeof(Ajout_Ville));
                    break;
                case "iListeVoiture":
                    tblHeader.Text = "Liste Voiture";
                    mainFrame.Navigate(typeof(Afficher_Voiture));
                    break;
                case "iAjoutVoiture":
                    tblHeader.Text = "Ajout Voiture";
                    mainFrame.Navigate(typeof(Ajout_Voiture));
                    break;
                case "iConnexion":
                    tblHeader.Text = "Liste Connexion";
                    mainFrame.Navigate(typeof(Connexion));
                    break;
                case "iDeconnexion":
                    connecter = "Personne";
                    id = 0;
                    break;
                default:
                    break;
            }
        }
    }
}
