using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Home : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fonction qui permet de load la scène "Mentions_Légale"
    public void OnClickMentionsLegales()
    {
        SceneManager.LoadScene("Mentions_Légale");
    }

      public void OnClickPagePrinc()
    {
        SceneManager.LoadScene("PagePrincipal");
    }

      public void OnClickParamVehicule()
    {
        SceneManager.LoadScene("ParamVehicule");
    }

    
      public void OnClickParamEnvironement()
    {
        SceneManager.LoadScene("ParamEnvironement");
    }

    // Fonction qui permet de load la scène "Accueil"
    public void OnClickRetourMentions()
    {
        Debug.Log("Accueil");
        SceneManager.LoadScene("Accueil");
    }

    public void OnClickConnexion()
    {
        SceneManager.LoadScene("Connexion");
    }

    public void OnClickInscription()
    {
        SceneManager.LoadScene("Inscription");
    }

     public void OnClickParametres()
    {
        SceneManager.LoadScene("Parametres");
    }

         public void OnClickPco()
    {
        SceneManager.LoadScene("ProblemeCo");
    }
}
