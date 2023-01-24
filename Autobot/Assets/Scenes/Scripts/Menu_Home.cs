using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Home : MonoBehaviour
{

    // Camera donnée par Unity
    public new Camera camera;

    // Vitesse de la caméra (Duration de la translation d'un point A vers un point B)
    public float duration = 0.5f;

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
        // On démarre une coroutine qui va se charger de déplacer la caméra vers la position cible
        StartCoroutine(MoveCamera(camera.transform.position + new Vector3(275, 0, 0), duration));
        // on affiche dans la console Unity le message "Mentions Légales"
        Debug.Log("Mentions Légales");
    }

    // Fonction qui vas faire le mouvement de la caméra fluide qui prend en paramètre la destination et la durée de la transition
    IEnumerator MoveCamera(Vector3 targetPosition, float duration)
    {
        // On récupère la position initiale de la caméra
        Vector3 initialPosition = camera.transform.position;

        // On initialise le temps écoulé à 0
        float elapsedTime = 0;

        // Tant que le temps écoulé est inférieur à la durée de la transition
        while (elapsedTime < duration)
        {
            // On utilise la fonction "Lerp" pour effectuer une transition fluide vers la position cible
            camera.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);

            // On augmente le temps écoulé de Time.deltaTime (temps écoulé depuis la dernière frame)
            elapsedTime += Time.deltaTime;

            // On attend jusqu'à la prochaine frame avant de continuer la boucle
            yield return null;
        }
        // On s'assure que la caméra arrive à la position cible
        camera.transform.position = targetPosition;
    }

    // Fonction appelée lors du clic sur le bouton "Retour", on translate la caméra vers la gauche de 275.
    public void OnClickRetourMentions()
    {
        // On démarre une coroutine qui va se charger de déplacer la caméra vers la position cible
        StartCoroutine(MoveCamera(camera.transform.position + new Vector3(-275, 0, 0), duration));
        // on affiche dans la console Unity le message "Retour"
        Debug.Log("Retour");
    }
}
