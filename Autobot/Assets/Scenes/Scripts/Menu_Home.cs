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
        Debug.Log("Mentions Légale");
        SceneManager.LoadScene("Mentions_Légale");
    }

   

    // Fonction qui permet de load la scène "Accueil"
    public void OnClickRetourMentions()
    {
        Debug.Log("Accueil");
        SceneManager.LoadScene("Accueil");
    }
}
