using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Principale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Nom de la prefab
        string nomPrefab = "FinalVehicle";

        // Recupère la couleur actuelle
        string color = Modif_Vehicule.getFinalColor();

        if(color == null){
            color = "Bleu";
        }

        // charger une prefab provenant du fichier scenes prefab
        GameObject prefab = Resources.Load("Prefabs/" + nomPrefab) as GameObject;
        
        if(prefab != null){

            // instancier la prefab
            GameObject instance = Instantiate(prefab, new Vector3(50, 0, 0), Quaternion.identity) as GameObject;

            // changer la texture du véhicule en fonction de la couleur
            // Recupere la prefab, puis recupere la premiere valeur (carosserie)
            // Enfin change sa couleur en fonction de la couleur instanciée par la dernière fenetre (cf. Modif_Vehicule) 
            instance.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = Resources.Load("Textures/Palette_"+color) as Texture;


        }
    }

}
