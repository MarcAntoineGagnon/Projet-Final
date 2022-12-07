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
        string nomVille;

        public Ville(string nomVille)
        {
            this.nomVille = nomVille;
        }

        public string NonVille { get { return nomVille; } set { nomVille = value; this.OnPropertyChanged() } }

        bool IEquatable<Ville>.Equals(Ville other)
        {
            if(this.nomVille.Equals(other.nomVille))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return nomVille;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
