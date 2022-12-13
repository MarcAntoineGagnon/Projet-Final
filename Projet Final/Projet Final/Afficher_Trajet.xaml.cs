using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Afficher_Trajet : Page
    {
        public Afficher_Trajet()
        {
            this.InitializeComponent();
            lvTrajet.ItemsSource = GestionBD.getInstance().getTrajet();
            if(MainWindow.connecter == "Conducteur")
            {
                lvTrajet.ItemsSource = GestionBD.getInstance().getTrajetConducteur(MainWindow.id);
            }
            if(MainWindow.connecter == "Admin")
            {
                totalCompagnie.Text = GestionBD.getInstance().TotalCompagnie();
            }
        }

        private async void CSV_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.connecter == "Admin")
            {
                var picker = new Windows.Storage.Pickers.FileSavePicker();

                /******************** POUR WINUI3 ***************************/
                var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(GestionBD.getInstance().Fenetre);
                WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);
                /************************************************************/

                picker.SuggestedFileName = "trajet liste";
                picker.FileTypeChoices.Add("Fichier csv", new List<string>() { ".csv" });

                //crée le fichier
                Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

                var liste = lvTrajet.ItemsSource as ObservableCollection<Trajet>;
                var l = liste.ToList();

                // La fonction ToString de la classe Client retourne: nom + ";" + prenom

                await Windows.Storage.FileIO.WriteLinesAsync(monFichier, l.ConvertAll(x => x.CSV()), Windows.Storage.Streams.UnicodeEncoding.Utf8);
            }


        }
    }
}
