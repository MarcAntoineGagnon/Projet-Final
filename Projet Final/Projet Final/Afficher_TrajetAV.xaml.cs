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
    public sealed partial class Afficher_TrajetAV : Page
    {
        public Afficher_TrajetAV()
        {
            this.InitializeComponent();
            lvTrajetAV.ItemsSource = GestionBD.getInstance().getTrajetAV();
        }

        private void reservation_Click(object sender, RoutedEventArgs e)
        {
            Trajet t = lvTrajetAV.SelectedItem as Trajet;
            int nb_place = GestionBD.getInstance().NbPlace(t);
            int nb_passager = GestionBD.getInstance().NbPassager(t);

            if (MainWindow.connecter == "Passager" && lvTrajetAV.SelectedIndex != -1 && nb_passager < nb_place)
            {
                GestionBD.getInstance().modifierPassager(t, MainWindow.id);
            }
        }
    }
}
