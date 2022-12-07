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
                case "iListeTrajet":
                    tblHeader.Text = "Liste Trajet";
                    mainFrame.Navigate(typeof(Afficher_Trajet));
                    break;
                case "iListeConducteur":
                    tblHeader.Text = "Liste Conducteur";
                    mainFrame.Navigate(typeof(Afficher_Conducteur));
                    break;
                case "iListePassager":
                    tblHeader.Text = "Liste Passager";
                    mainFrame.Navigate(typeof(Afficher_Passager));
                    break;
                case "iConnexion":
                    tblHeader.Text = "Liste Connexion";
                    mainFrame.Navigate(typeof(Connexion));
                    break;
                default:
                    break;
            }
        }
    }
}
