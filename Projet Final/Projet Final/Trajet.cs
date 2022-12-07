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
        string date;
        string heure_depart;
        string heure_arriver;
        string type_vehicule;
        double prix_passager;
        bool arret;

        public Trajet(int id, string date, string heure_depart, string heure_arriver, string type_vehicule, double prix_passager, bool arret)
        {
            this.id = id;
            this.date = date;
            this.heure_depart = heure_depart;
            this.heure_arriver = heure_arriver;
            this.type_vehicule = type_vehicule;
            this.prix_passager = prix_passager;
            this.arret = arret;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public string Date { get { return date; } set { date = value; this.OnPropertyChanged(); } }

        public string Heure_depart { get { return heure_depart; } set { heure_depart = value; this.OnPropertyChanged(); } }

        public string Heure_arriver { get { return heure_arriver; } set { heure_arriver = value; this.OnPropertyChanged(); } }

        public string Type_vehicule { get { return type_vehicule; } set { type_vehicule = value; this.OnPropertyChanged(); } }

        public double Prix_passager { get { return prix_passager; } set { prix_passager = value; this.OnPropertyChanged(); } }

        public bool Arret { get { return arret; } set { arret = value; this.OnPropertyChanged(); } }

        bool IEquatable<Trajet>.Equals(Trajet other)
        {
            if (this.id.Equals(other.id) && this.date.Equals(other.date) && this.heure_depart.Equals(other.heure_depart) && this.heure_arriver.Equals(other.heure_arriver) && this.type_vehicule.Equals(other.type_vehicule) && this.prix_passager.Equals(other.prix_passager) && this.arret.Equals(other.arret))
                return true;
            else
                return false;
        }       

        public override string ToString()
        {
            return id + " " + date + " " + heure_depart + " " + heure_arriver + " " + type_vehicule + " " + prix_passager + " "  + arret;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

}
