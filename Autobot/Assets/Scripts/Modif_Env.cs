using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Modif_Env : MonoBehaviour
{
    [SerializeField] GameObject instance;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject particle;
    [SerializeField] TMP_Dropdown Meteo;
    [SerializeField] TMP_Dropdown Etat_route;
    [SerializeField]  TMP_InputField Inclinaison_route;
    [SerializeField]  TMP_InputField Largeur_route;


    // Start is called before the first frame update
    void Start()
    {
         if (GameObject.FindGameObjectsWithTag("Environement").Length == 0)
        {
            // charger une prefab provenant du fichier scenes prefab
            prefab = Resources.Load("Prefabs/Environement") as GameObject;
            // instancier la prefab avec un tag Véhicule
            instance = Instantiate(prefab, new Vector3(-50, -25, 105), Quaternion.identity) as GameObject;
            // rotation de la prefab -100 sur l'axe x
            instance.transform.Rotate(-90, 100, -100);
            instance.tag = "Environement";
            instance.GetComponent<MeshRenderer>().materials = SupprIndesirable(instance);
            Change_meteo_etat(instance, "Soleil","RouteNeuve");
        }
        // inclinaison par défaut
        Inclinaison_route.text = "0";
        // largeur par défaut
        Largeur_route.text = "0";
    }

    public void ModifEnvironement(){
    
    string meteo = Meteo.options[Meteo.value].text;
    string etat_route = Etat_route.options[Etat_route.value].text;
    int inclinaison = int.Parse(Inclinaison_route.text);
    int largeur = int.Parse(Largeur_route.text);
    
    if (largeur < -200 || largeur > 200 ){
        Largeur_route.text = "0";
        largeur = 0;
        largeur = int.Parse(Largeur_route.text);
    }

    if (inclinaison <= 0 || inclinaison > 30 ){
        Inclinaison_route.text = "0";
        inclinaison = 0;
        inclinaison = int.Parse(Inclinaison_route.text);
    }


    // delete la prefab particule
    if (GameObject.FindGameObjectsWithTag("Particule").Length != 0){
    GameObject[] Particule = GameObject.FindGameObjectsWithTag("Particule");
        foreach (GameObject particule in Particule){
            // si la particule est différente de la particule actuelle
            Destroy(particule);
        }
    }
    // delete la prefab environement
    if (GameObject.FindGameObjectsWithTag("Environement").Length != 0){
    GameObject[] Environement = GameObject.FindGameObjectsWithTag("Environement");
        foreach (GameObject environement in Environement){
            Destroy(environement);
        }
    }

    // changer les valeurs de la prefab
    prefab = Resources.Load("Prefabs/Environement") as GameObject;
    instance = Instantiate(prefab, new Vector3(-50, -25, 105), Quaternion.identity) as GameObject;
    instance.transform.Rotate(-90-inclinaison, 100, -100);
    instance.transform.localScale = new Vector3(1000,largeur + 1000, 1000);
    instance.tag = "Environement";
    instance.GetComponent<MeshRenderer>().materials = SupprIndesirable(instance);
    Change_meteo_etat(instance, meteo,etat_route);
    }

    //********************************Fonctions*************************************************//

    public Material[] SupprIndesirable(GameObject instance)
    {
        Material[] materials = instance.GetComponent<MeshRenderer>().materials;
        Material[] newMaterials = new Material[materials.Length - 1];
        int j = 0;
        for (int i = 0; i < materials.Length; i++)
        {
            if (i != 8)
            {
                newMaterials[j] = materials[i];
                j++;
            }
        }
        return newMaterials;
    }
    public void Change_meteo_etat(GameObject instance, string meteo, string etat_route){
        Material[] newprefab = instance.GetComponent<MeshRenderer>().materials;
        particle = Resources.Load("Prefabs/"+meteo) as GameObject;
        GameObject instance2 = Instantiate(particle, new Vector3(-60, 50, 105), Quaternion.identity) as GameObject;
        instance2.transform.Rotate(90, 0, 0);
        instance2.tag = "Particule";
        newprefab[0] = Resources.Load("Textures/rock_"+meteo) as Material;
        newprefab[1] = Resources.Load("Textures/bluegreen_"+meteo) as Material;
        newprefab[2] = Resources.Load("Textures/yellowgreen_"+meteo) as Material;
        newprefab[5] = Resources.Load("Textures/etat_"+etat_route) as Material;
        instance.GetComponent<MeshRenderer>().materials = newprefab;
        }
}
