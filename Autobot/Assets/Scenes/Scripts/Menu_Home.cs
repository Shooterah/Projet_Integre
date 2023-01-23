using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Home : MonoBehaviour
{

    // Camera donnée par Unity
    public new Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fonction appelée lors du clic sur le bouton "Mention Légales", on translate la caméra vers la droite de 275.
    public void OnClickMentionsLegales()
    {
        camera.transform.Translate(275, 0, 0);
        // on affiche dans la console Unity le message "Mentions Légales"
        Debug.Log("Mentions Légales");
    }

    // Fonction appelée lors du clic sur le bouton "Retour", on translate la caméra vers la gauche de 275.
    public void OnClickRetourMentions()
    {
        camera.transform.Translate(-275, 0, 0);
        // on affiche dans la console Unity le message "Retour"
        Debug.Log("Retour");
    }
}
