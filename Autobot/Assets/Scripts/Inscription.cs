using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;


public class Inscription : MonoBehaviour
{
    [SerializeField] BDD bdd;
    [SerializeField] TMP_InputField Mdp;
    [SerializeField] TMP_InputField Nom;
    [SerializeField] TMP_InputField Email;

    public void TryInscription(){
        int res = 0;
        if (Mdp.text != "" && Nom.text != "" && Email.text != ""){
            res = bdd.Inscription(Nom.text, Email.text, Mdp.text);
        }
        // si retour de la fonction inscription = 0 alors on affiche un message de confirmation et on retourne à la page de connexion
        // sinon on affiche un message d'erreur
        if(res == 3){
            // afficher message de confirmation et retourner à la page de connexion
            SceneManager.LoadScene("Connexion");
        }
        else if(res == 1){
            // afficher message d'erreur
            Debug.Log("Erreur lors de l'inscription nom existant");
        }
        else if(res == 2){
            // afficher message d'erreur
            Debug.Log("Erreur lors de l'inscription email existant");
        }

    }
}
