using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Voiture : IEquatable<Voiture>, INotifyPropertyChanged
    {
        int id;
        string type_vehicule;
        int nb_place;
        double prix_passager;

        public Voiture (int id, string type_vehicule, int nb_place, double prix_passager)
        {
            this.id = id;
            this.type_vehicule = type_vehicule;
            this.nb_place = nb_place;
            this.prix_passager = prix_passager;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public string Type_vehicule { get { return type_vehicule; } set { type_vehicule = value; this.OnPropertyChanged(); } }

        public int Nb_place { get { return nb_place; } set { nb_place = value; this.OnPropertyChanged(); } }

        public double Prix_passager { get { return prix_passager; } set { prix_passager = value; this.OnPropertyChanged(); } }

        bool IEquatable<Voiture>.Equals(Voiture other)
        {
            if (this.id.Equals(other.id) && this.type_vehicule.Equals(other.type_vehicule) && this.nb_place.Equals(other.nb_place) && this.prix_passager.Equals(other.prix_passager))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return id + "\nType de vehicule : " + type_vehicule + "\nNombre de place : " + nb_place + "\nPrix par passager : " + prix_passager;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
