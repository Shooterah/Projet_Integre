using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class TestDB : MonoBehaviour
{
    // Informations de connection à la base de données
    private string host = "127.0.0.1";
    private string dbname = "projet_integre";
    private string username = "root";
    private string password = "";
    private int port = 3306;

    // Connexion à la base de données
    private MySqlConnection connection;

    // Use this for initialization
    void Start()
    {

        // Connexion à la base de données
        Connect();

        // Exécution de la fonction pour sélectionner toutes les données de toutes les tables
        SelectAll();
    }

    // Fonction pour établir la connexion à la base de données
    private void Connect()
    {
        string connectionString = "Server=" + host + ";Port=" + port + ";Database=" + dbname + ";Uid=" + username + ";Pwd=" + password + ";SslMode=none;";
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    // Fonction pour sélectionner toutes les données de toutes les tables
    public void SelectAll() {

        // Initialisation de la commande SQL
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;

        // Récupération de la liste des tables
        List<string> tables = GetTables();

        Debug.Log("Tables: " + tables.Count);

        // Boucle pour exécuter une requête SELECT sur toutes les tables
        foreach (string table in tables) {
            cmd.CommandText = "SELECT * FROM " + table;
            MySqlDataReader reader = cmd.ExecuteReader();
            Debug.Log("Table : " + table);
            string row = "";
            for (int i = 0; i < reader.FieldCount; i++) {
                row += reader.GetName(i) + " ";
            }
            Debug.Log(row);
            while (reader.Read()) {
                row = "";
                for (int i = 0; i < reader.FieldCount; i++) {
                    row += reader[i].ToString() + " ";
                }
                Debug.Log(row);
            }
            reader.Close();
        }
    }

    // Fonction pour récupérer la liste des tables de la base de données
    public List<string> GetTables()
    {
        // Liste des tables
        List<string> tables = new List<string>();
        // Chaine de connexion à la base de données
        string connString = "Server=" + host + ";Database=" + dbname + ";Uid=" + username + ";Pwd=" + password + ";port=" + port;
        // Connexion à la base de données
        using (MySqlConnection conn = new MySqlConnection(connString))
        {
            conn.Open();
            // Requête pour récupérer la liste des tables
            string query = "SHOW TABLES";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Ajout de chaque table dans la liste
                        tables.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();
        }
        // Retourne la liste des tables
        return tables;
    }

}