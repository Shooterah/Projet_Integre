using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Modif_Env : MonoBehaviour
{
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
            GameObject instance = Instantiate(prefab, new Vector3(-50, -25, 105), Quaternion.identity) as GameObject;
            // rotation de la prefab -100 sur l'axe x
            instance.transform.Rotate(-100, 0, 0);
            instance.tag = "Environement";

            // delet array element 8 4 3
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
            instance.GetComponent<MeshRenderer>().materials = newMaterials;
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
     
    if (GameObject.FindGameObjectsWithTag("Particule").Length != 0){
    GameObject[] Particule = GameObject.FindGameObjectsWithTag("Particule");
    foreach (GameObject particule in Particule){
        Destroy(particule);
    }}
    // récupération de la prefab environement
    prefab = GameObject.FindWithTag("Environement");
    Material[] newprefab = prefab.GetComponent<MeshRenderer>().materials;
    //fait spawn neige 
    if (meteo == "Neige"){

        particle = Resources.Load("Prefabs/"+meteo) as GameObject;
        GameObject instance2 = Instantiate(particle, new Vector3(-60, 60, 105), Quaternion.identity) as GameObject;
        //scale de la particule
        instance2.transform.localScale = new Vector3(10,10,10);
        instance2.transform.Rotate(90, 0, 0);
        instance2.tag = "Particule";

        newprefab[0] = Resources.Load("Textures/"+meteo) as Material;
        newprefab[1] = Resources.Load("Textures/"+meteo) as Material;
        newprefab[2] = Resources.Load("Textures/"+meteo) as Material;
        prefab.GetComponent<MeshRenderer>().materials = newprefab;
       }
    if (meteo == "Soleil"){

        newprefab[0] = Resources.Load("Textures/rock") as Material;
        newprefab[1] = Resources.Load("Textures/bluegreen") as Material;
        newprefab[2] = Resources.Load("Textures/yellowgreen") as Material;
        prefab.GetComponent<MeshRenderer>().materials = newprefab;
    }
    if (meteo == "Pluie"){
        particle = Resources.Load("Prefabs/"+meteo) as GameObject;
        GameObject instance2 = Instantiate(particle, new Vector3(-60, 60, 105), Quaternion.identity) as GameObject;
        //scale de la particule
        instance2.transform.localScale = new Vector3(10,10,10);
        instance2.transform.Rotate(90, 0, 0);
        instance2.tag = "Particule";

        newprefab[0] = Resources.Load("Textures/rock_pluie") as Material;
        newprefab[1] = Resources.Load("Textures/bluegreen") as Material;
        newprefab[2] = Resources.Load("Textures/yellowgreen_pluie") as Material;
        prefab.GetComponent<MeshRenderer>().materials = newprefab;
    }
    }
}
