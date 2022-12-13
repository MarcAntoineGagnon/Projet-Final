using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing.Workflow;

namespace Projet_Final
{
    internal class Trajet : IEquatable<Trajet>, INotifyPropertyChanged
    {
        int id;
        int id_voiture;
        int id_conducteur;
        string date;
        string heure_depart;
        string heure_arriver;
        string ville_depart;
        string ville_arriver;
        bool arret;

        public Trajet(int id,int id_voiture, int id_conducteur, string date, string heure_depart, string heure_arriver, string ville_depart, string ville_arriver, bool arret)
        {
            this.id = id;
            this.id_voiture = id_voiture;
            this.id_conducteur = id_conducteur;
            this.date = date;
            this.heure_depart = heure_depart;
            this.heure_arriver = heure_arriver;
            this.ville_depart = ville_depart;
            this.ville_arriver = ville_arriver;
            this.arret = arret;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public int Id_voiture { get { return id_voiture; } set { id_voiture = value; this.OnPropertyChanged(); } }

        public int Id_conducteur { get { return id_conducteur; } set { id_conducteur = value; this.OnPropertyChanged(); } }

        public string Date { get { return date; } set { date = value; this.OnPropertyChanged(); } }

        public string Heure_depart { get { return heure_depart; } set { heure_depart = value; this.OnPropertyChanged(); } }

        public string Heure_arriver { get { return heure_arriver; } set { heure_arriver = value; this.OnPropertyChanged(); } }

        public string Ville_depart { get { return ville_depart; } set { ville_depart = value; this.OnPropertyChanged(); } }

        public string Ville_arriver { get { return ville_arriver; } set { ville_arriver = value; this.OnPropertyChanged(); } }

        public bool Arret { get { return arret; } set { arret = value; this.OnPropertyChanged(); } }
        public string CSV()
        {
            return id + ";" + id_voiture + ";" + id_conducteur + ";" + date + ";" + heure_depart + ";" + heure_arriver + ";" + ville_depart + ";" + ville_arriver + ";" + arret;
        }
        bool IEquatable<Trajet>.Equals(Trajet other)
        {
            if (this.id.Equals(other.id) && this.id_voiture.Equals(other.id_voiture) && this.id_conducteur.Equals(other.id_conducteur) && this.date.Equals(other.date) && this.heure_depart.Equals(other.heure_depart) && this.heure_arriver.Equals(other.heure_arriver) && this.ville_depart.Equals(other.ville_depart) && this.ville_arriver.Equals(other.ville_arriver) && this.arret.Equals(other.arret))
                return true;
            else
                return false;
        }       

        public override string ToString()
        {
            return id + "\n" + "numéro de voiture : " + id_voiture + "\n" + "numéro du conducteur : " + id_conducteur + "\n" + "Date : " + date + 
                        "\n" + "Heure de départ : " + heure_depart + "\n" + "Heure d'arrivé : " + heure_arriver + "\n" + "Ville de départ : " + ville_depart +
                        "\n" + "Destination : " + ville_arriver + "\n" + "Arret : " + arret;

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

}
