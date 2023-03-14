using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class BDD : MonoBehaviour
{
    // Informations de connection à la base de données
    private string host = "127.0.0.1";
    // nom de la base de données
    private string dbname = "projet_integre";
    private string username = "root";
    private string password = "";
    private int port = 3306;

    // Connexion à la base de données
    private MySqlConnection connection;

    // Use this for initialization
    void Start()
    {
    }

    // Fonction pour établir la connexion à la base de données
    public void Connect()
    {
        string connectionString = "Server=" + host + ";Port=" + port + ";Database=" + dbname + ";Uid=" + username + ";Pwd=" + password + ";SslMode=none;";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        print("Connected to database");
    }

    public void Disconnect()
    {
        connection.Close();
        print("Disconnected from database");
    }

    // Fonction pour insérer un utilisateur dans la base de données avec la date d'inscription et une validité de 1 an
    public int Inscription(string nom, string email,string mdp)
    {
        Connect();
        // Initialisation de la commande SQL
        MySqlCommand re = new MySqlCommand();
        re.Connection = connection;
        // verification si l'utilisateur existe deja avec le mail ou le nom de l'entreprise avec des messages d'erreurs en fonction du cas
        re.CommandText = "SELECT * FROM clients WHERE mail = '" + email + "' OR nomEntreprise = '" + nom + "'";
        MySqlDataReader reader = re.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (reader.GetString(1) == nom)
                {   
                    reader.Close();
                    Disconnect();
                    return 1;
                }
                else if (reader.GetString(2) == email)
                {
                    reader.Close();
                    Disconnect();
                    return 2;
                }
            }
        }
        else
        {
            reader.Close();

            // Requête pour insérer un utilisateur
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO clients (nomEntreprise, mail, Mdp, dateInscription, finAbonnement) VALUES ('" + nom + "', '" + email + "', '" + mdp + "', NOW(), DATE_ADD(NOW(), INTERVAL 1 YEAR))";
            cmd.ExecuteNonQuery();
        }
        Disconnect();
        return 3;
    }

    // Fonction pour vérifier si un utilisateur existe dans la base de données avec son nom et son mot de passe
    public bool Connexion(string nom, string mdp)
    {
        Connect();
        // Initialisation de la commande SQL
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;
        // Requête pour vérifier si l'utilisateur existe
        cmd.CommandText = "SELECT * FROM clients WHERE nomEntreprise = '" + nom + "' AND Mdp = '" + mdp + "'";
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Close();
            Disconnect();
            return true;
        }
        else
        {
            reader.Close();
            Disconnect();
            return false;
        }
    }

}