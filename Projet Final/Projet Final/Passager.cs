using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    internal class Passager : IEquatable<Passager>, INotifyPropertyChanged
    {
        int id;
        int id_trajet;
        string nom;
        string prenom;
        string adresse;
        string telephone;
        string email;
        string password;

        public Passager(int id, int id_trajet, string nom, string prenom, string adresse, string telephone, string email, string password)
        {
            this.id = id;
            this.id_trajet = id_trajet;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
        }

        public int Id { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public int Id_trajet { get { return id_trajet; } set { id_trajet = value; this.OnPropertyChanged(); } }

        public string Nom { get { return nom; } set { nom = value; this.OnPropertyChanged(); } }

        public string Prenom { get { return prenom; } set { prenom = value; this.OnPropertyChanged(); } }

        public string Adresse { get { return adresse; } set { adresse = value; this.OnPropertyChanged(); } }

        public string Telephone { get { return telephone; } set { telephone = value; this.OnPropertyChanged(); } }

        public string Email { get { return email; } set { email = value; this.OnPropertyChanged(); } }

        public string Password { get { return password; } set { password = value; this.OnPropertyChanged(); } }

        bool IEquatable<Passager>.Equals(Passager other)
        {
            if (this.id.Equals(other.id) && this.id_trajet.Equals(other.id_trajet) && this.nom.Equals(other.nom) && this.prenom.Equals(other.prenom) && this.telephone.Equals(other.telephone) && this.email.Equals(other.email) && this.password.Equals(other.password))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return id + "\nNuméros de trajet : " + id_trajet + "\nNom : " + nom + "\nPrenom : " + prenom + "\nAdresse : " + adresse + "\n#Telephone : " + telephone + "\nEmail : " + email;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
