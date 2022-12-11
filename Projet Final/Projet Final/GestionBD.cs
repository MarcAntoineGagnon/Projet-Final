﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq8;Uid=1827906;Pwd=1827906;"); ;
        }
        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        //SECTION ADMIN

        public ObservableCollection<Admin> getAdmin()
        {
            ObservableCollection<Admin> liste = new ObservableCollection<Admin>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from admin";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Admin(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterAdmin(Admin a)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into admin values(@nom, @prenom, @email, @password) ";

                commande.Parameters.AddWithValue("@nom", a.Nom);
                commande.Parameters.AddWithValue("@prenom", a.Prenom);
                commande.Parameters.AddWithValue("@email", a.Email);
                commande.Parameters.AddWithValue("@password", a.Password);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }
            
        }

        //SECTION CONDUCTEUR

        public ObservableCollection<Conducteur> getConducteur()
        {
            ObservableCollection<Conducteur> liste = new ObservableCollection<Conducteur>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from conducteur";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Conducteur(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5), r.GetDouble(0)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterConducteur(Conducteur c)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into conducteur values(@nom, @prenom, @telephone, @email, @password, @argent) ";

                commande.Parameters.AddWithValue("@nom", c.Nom);
                commande.Parameters.AddWithValue("@prenom", c.Prenom);
                commande.Parameters.AddWithValue("@telephone", c.Telephone);
                commande.Parameters.AddWithValue("@email", c.Email);
                commande.Parameters.AddWithValue("@password", c.Password);
                commande.Parameters.AddWithValue("@argent", c.Argent);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }

        }

        public int modifierConducteur(Conducteur c)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "update conducteur set nom = @nom, prenom = @prenom,  telephone = @telephone, email = @email, password = @password, argent = @argent where id = @id";

                commande.Parameters.AddWithValue("@id", c.Id);
                commande.Parameters.AddWithValue("@nom", c.Nom);
                commande.Parameters.AddWithValue("@prenom", c.Prenom);
                commande.Parameters.AddWithValue("@telephone", c.Telephone);
                commande.Parameters.AddWithValue("@email", c.Email);
                commande.Parameters.AddWithValue("@password", c.Password);
                commande.Parameters.AddWithValue("@argent", c.Argent);


                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch (Exception ex)
            {
                con.Close();
                return retour;
            }
        }

        //SECTION PASSAGER

        public ObservableCollection<Passager> getPassager()
        {
            ObservableCollection<Passager> liste = new ObservableCollection<Passager>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from passager";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Passager(r.GetInt32(0), r.GetInt32(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5), r.GetString(0)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterPassager(Passager p)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into passager values(@nom, @prenom, @telephone, @email, @password) ";

                commande.Parameters.AddWithValue("@nom", p.Nom);
                commande.Parameters.AddWithValue("@prenom", p.Prenom);
                commande.Parameters.AddWithValue("@telephone", p.Telephone);
                commande.Parameters.AddWithValue("@email", p.Email);
                commande.Parameters.AddWithValue("@password", p.Password);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }

        }

        public int modifierPassager(Passager p)
        {
            int retour = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "update conducteur set id_trajet = @id_trajet nom = @nom, prenom = @prenom,  telephone = @telephone, email = @email, password = @password, argent = @argent where id = @id";

                commande.Parameters.AddWithValue("@id", p.Id);
                commande.Parameters.AddWithValue("@id_trajet", p.Id_trajet);
                commande.Parameters.AddWithValue("@nom", p.Nom);
                commande.Parameters.AddWithValue("@prenom", p.Prenom);
                commande.Parameters.AddWithValue("@telephone", p.Telephone);
                commande.Parameters.AddWithValue("@email", p.Email);
                commande.Parameters.AddWithValue("@password", p.Password);


                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch (Exception ex)
            {
                con.Close();
                return retour;
            }
        }

        //SECTION TRAJET

        public ObservableCollection<Trajet> getTrajet()
        {
            ObservableCollection<Trajet> liste = new ObservableCollection<Trajet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Trajet(r.GetInt32(0), r.GetInt32(1), r.GetInt32(2), r.GetString(3), r.GetString(4), r.GetString(5), r.GetString(6), r.GetString(7), r.GetBoolean(8)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterTrajet(Trajet t)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into trajet values(@id_voiture, @id_conducteur, @date, @heure_depart, @heure_arrivee, @ville_depart, @ville_arrivee, @arret) ";

                commande.Parameters.AddWithValue("@id_voiture", t.Id_voiture);
                commande.Parameters.AddWithValue("@id_conducteur", t.Id_conducteur);
                commande.Parameters.AddWithValue("@date", t.Date);
                commande.Parameters.AddWithValue("@heure_depart", t.Heure_depart);
                commande.Parameters.AddWithValue("@heure_arrivee", t.Heure_arriver);
                commande.Parameters.AddWithValue("@ville_depart", t.Ville_depart);
                commande.Parameters.AddWithValue("@ville_arrivee", t.Ville_arriver);
                commande.Parameters.AddWithValue("@arret", t.Arret);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }

        }

        //SECTION VILLE

        public ObservableCollection<Ville> getVille()
        {
            ObservableCollection<Ville> liste = new ObservableCollection<Ville>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from ville";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Ville(r.GetString(0)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterVille(Ville v)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into ville values(@nom_ville) ";

                commande.Parameters.AddWithValue("@nom_ville", v.Nom_ville);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }

        }

        //SECTION VOITURE

        public ObservableCollection<Voiture> getVoiture()
        {
            ObservableCollection<Voiture> liste = new ObservableCollection<Voiture>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from voiture";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                liste.Add(new Voiture( r.GetInt32(0),r.GetString(1),r.GetInt32(2), r.GetDouble(3)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajouterVoiture(Voiture v)
        {
            int retour = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into voiture values(@type_vehicule, @nb_place, @prix_passager) ";

                commande.Parameters.AddWithValue("@type_vehicule", v.Type_vehicule);
                commande.Parameters.AddWithValue("@nb_place", v.Nb_place);
                commande.Parameters.AddWithValue("@prix_passager", v.Prix_passager);

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

                return retour;
            }
            catch
            {
                con.Close();
                return retour;
            }

        }
    }
}