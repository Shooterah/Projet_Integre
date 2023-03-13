using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Modif_Vehicule : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Type;
    [SerializeField] TMP_Dropdown Color;
    [SerializeField] TMP_Dropdown Cargaison;
    [SerializeField]  GameObject prefab;



    // Start is called before the first frame update
    void Start()
    {
        // uniquement si le tag Véhicule n'existe pas
        if (GameObject.FindGameObjectsWithTag("Véhicule").Length == 0)
        {
            // charger une prefab provenant du fichier scenes prefab
            prefab = Resources.Load("Prefabs/bus") as GameObject;
            // instancier la prefab avec un tag Véhicule
            GameObject instance = Instantiate(prefab, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
            instance.tag = "Véhicule";
        }
    }

    public void ModifVéhicule(){
    // supprimer le véhicule précédent
    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Véhicule");
    for (var i = 0; i < gameObjects.Length; i++)
    {
        Destroy(gameObjects[i]);
    }
    // récupère le type de véhicule choisi
    string type = Type.options[Type.value].text;
    // récupère la couleur de véhicule choisi
    string color = Color.options[Color.value].text;

    // charger une prefab provenant du fichier scenes prefab
    prefab = Resources.Load("Prefabs/" + type) as GameObject;
    // instancier la prefab avec un tag Véhicule
    GameObject instance = Instantiate(prefab, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
    instance.tag = "Véhicule";
    // changer la texture du véhicule en fonction de la couleur choisie
    instance.GetComponent<Renderer>().material.mainTexture = Resources.Load("Textures/Palette_"+color) as Texture;
    }
}