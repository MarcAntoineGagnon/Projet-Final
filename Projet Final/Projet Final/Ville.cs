using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Ville : IEquatable<Ville>, INotifyPropertyChanged
    {
        string nom_ville;

        public Ville(string nom_ville)
        {
            this.nom_ville = nom_ville;
        }

        public string Nom_ville { get { return nom_ville; } set { nom_ville = value; this.OnPropertyChanged(); } }

        bool IEquatable<Ville>.Equals(Ville other)
        {
            if(this.nom_ville.Equals(other.nom_ville))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return nom_ville;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
