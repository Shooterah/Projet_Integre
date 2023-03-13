using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class type_vehicul : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Type;
    [SerializeField]  GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        // véhicule par défaut
        prefab = Resources.Load("Prefabs/bus") as GameObject;
        GameObject instance = Instantiate(prefab, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
        instance.tag = "Véhicule";
    }

    public void ChoixVéhicule(){
    // supprime les élements de la scène ayant le tag Véhicule si il y en a
    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Véhicule");
    for (var i = 0; i < gameObjects.Length; i++)
    {
        Destroy(gameObjects[i]);
    }

    // récupère le type de véhicule choisi
    string type = Type.options[Type.value].text;
    // charger une prefab provenant du fichier scenes prefab
    prefab = Resources.Load("Prefabs/" + type) as GameObject;
    // instancier la prefab avec un tag Véhicule
    GameObject instance = Instantiate(prefab, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
    instance.tag = "Véhicule";
    }
}
