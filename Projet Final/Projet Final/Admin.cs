using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Admin : IEquatable<Admin>, INotifyPropertyChanged
    {
        int id;
        string nom;
        string prenom;
        string email;
        string password;

        public Admin(int id, string nom, string prenom, string email, string password)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.password = password;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public string Nom { get { return nom; } set { nom = value; this.OnPropertyChanged(); } }

        public string Prenom { get { return prenom; } set { prenom = value; this.OnPropertyChanged(); } }

        public string Email { get { return email; } set { email = value; this.OnPropertyChanged(); } }

        public string Password { get { return password; } set { password = value; this.OnPropertyChanged(); } }

        bool IEquatable<Admin>.Equals(Admin other)
        {
            if ( this.id.Equals(other.id) && this.nom.Equals(other.nom) && this.prenom.Equals(other.prenom) && this.email.Equals(other.Email) && this.password.Equals(other.password))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return id + "\nNom : " + nom + "\nPrenom" + prenom + "\nEmail : " + email;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
