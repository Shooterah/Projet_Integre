using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class Connexion : MonoBehaviour
{
    [SerializeField] BDD bdd;
    [SerializeField] TMP_InputField Mdp;
    [SerializeField] TMP_InputField Nom;

    // Update is called once per frame
    public void TryConnexion()
    {
        bool res = false;
        if (Mdp.text != "" && Nom.text != ""){
            res = bdd.Connexion(Nom.text,Mdp.text);
        }
        // si retour de la fonction inscription = 0 alors on affiche un message de confirmation et on retourne à la page de connexion
        // sinon on affiche un message d'erreur
        if(res){
            // afficher message de confirmation et retourner à la page de connexion
            SceneManager.LoadScene("PagePrincipal");
        }
        else if(!res){
            // afficher message d'erreur
            Debug.Log("Erreur lors de la connexion");
        }
    }
}
