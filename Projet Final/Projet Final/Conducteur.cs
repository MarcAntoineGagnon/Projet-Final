using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Conducteur : IEquatable<Conducteur>, INotifyPropertyChanged
    {
        int id;
        string nom;
        string prenom;
        string telephone;
        string email;
        string password;
        double argent;

        public Conducteur(int id, string nom, string prenom, string telephone, string email, string password, double argent)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
            this.argent = argent;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public string Nom { get { return nom; } set { nom = value; this.OnPropertyChanged(); } }

        public string Prenom { get { return prenom; } set { prenom = value; this.OnPropertyChanged(); } }

        public string Telephone { get { return telephone; } set { telephone = value; this.OnPropertyChanged(); } }

        public string Email { get { return email; } set { email = value; this.OnPropertyChanged(); } }

        public string Password { get { return password; } set { password = value; this.OnPropertyChanged(); } }

        public double Argent { get { return argent; } set { argent = value; this.OnPropertyChanged(); } }

        bool IEquatable<Conducteur>.Equals(Conducteur other)
        {
            if (this.id.Equals(other.id) && this.nom.Equals(other.nom) && this.prenom.Equals(other.prenom) && this.telephone.Equals(other.telephone) && this.email.Equals(other.email) && this.password.Equals(other.password) && this.argent.Equals(other.argent))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return id + " " + nom + " " + prenom + " " + telephone + " " + email + " " + password + " " + argent;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
