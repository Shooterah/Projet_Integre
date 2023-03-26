using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;


public class Modif_Vehicule : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Type;
    [SerializeField] TMP_Dropdown Color;
    [SerializeField] TMP_Dropdown Cargaison;
    [SerializeField] TMP_Dropdown T_Roue;
    [SerializeField]  GameObject prefab;
    [SerializeField]  GameObject conteneur;
    [SerializeField]  GameObject roues;
    [SerializeField]  TMP_InputField nb_roue;

    // Voir fonction creer
    public List<GameObject> objectsToGroup;

    private static string FinalColor = "bleu";


    // Start is called before the first frame update
    void Start()
    {
        //********************************************Récuperation pour sauvegarde de l'environement********************************************//
        // uniquement si l'objet Environement de la scene est vide
    
        string env = "FinalEnvironement";
        if(GameObject.Find("NewFinalEnvironement") == null && GameObject.Find(env) != null){ 
            GameObject myObjectenv = GameObject.Find(env);
            Scene scene = SceneManager.GetSceneByName("ParamVehicule");
            GameObject obj1 = Instantiate(myObjectenv,new Vector3(100000,-20000,0), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            SceneManager.UnloadSceneAsync("PagePrincipal");
            obj1.name = "NewFinalEnvironement";
        }else{
            SceneManager.UnloadSceneAsync("PagePrincipal");  
        }
    }

    public void ModifVéhicule(){

    //********************************************Supprimer les objets précédents********************************************//
    // supprimer le véhicule précédent
    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Véhicule");
    for (var i = 0; i < gameObjects.Length; i++)
    {
        Destroy(gameObjects[i]);
    }
    // supprimer les roues précédentes
    GameObject[] gameObjects2 = GameObject.FindGameObjectsWithTag("Roue");
    for (var i = 0; i < gameObjects2.Length; i++)
    {
        Destroy(gameObjects2[i]);
    }

    //********************************************Récupérer les valeurs choisies********************************************//
    // récupère le type de véhicule choisi
    string type = Type.options[Type.value].text;
    // récupère la couleur de véhicule choisi
    string color = Color.options[Color.value].text;
    // récupère la cargaison de véhicule choisi
    string cargaison = Cargaison.options[Cargaison.value].text;
    // récupère le nombre de roue choisi
    int nb = int.Parse(nb_roue.text);
    // récupère le type de roue choisi
    string t_roue = T_Roue.options[T_Roue.value].text;


    //**************************************faire apparaitre le véhicule choisi avec la couleur**************************************//

    // charger une prefab provenant du fichier scenes prefab
    prefab = Resources.Load("Prefabs/" + type) as GameObject;
    // instancier la prefab avec un tag Véhicule
    GameObject instance = Instantiate(prefab, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
    instance.tag = "Véhicule";
    // changer la texture du véhicule en fonction de la couleur choisie
    instance.GetComponent<Renderer>().material.mainTexture = Resources.Load("Textures/Palette_"+color) as Texture;


    //******************************Faire apparaitre la cargaison si le véhicule choisi est un camion******************************//
    if(type != "Camion1" && type != "Camion2"){
        cargaison = "Conteneur0";
    }

    if(cargaison != "Conteneur0"){
        // charger une prefab provenant du fichier scenes prefab
        conteneur = Resources.Load("Prefabs/" + cargaison) as GameObject;
        // instancier la prefab avec un tag Véhicule
        if(cargaison == "Conteneur1"){
            GameObject instance2 = Instantiate(conteneur, new Vector3(-50, 0, 105), Quaternion.identity) as GameObject;
            instance2.tag = "Véhicule";
        }else if(cargaison == "Conteneur2"){
            GameObject instance2 = Instantiate(conteneur, new Vector3(-55,5, 105), Quaternion.identity) as GameObject;
            instance2.tag = "Véhicule";
        }
    }
    // si le véhicule choisi est un camion alors on peut avoir 4 a 8 roues
        if(type == "Camion1" || type == "Camion2"){
            // si le nombre de roue est inférieur a 4 alors on met 4
            if(nb < 4){
                nb = 4;
            }
            // si le nombre de roue est supérieur a 8 alors on met 8
            if(nb > 8){
                nb = 8;
            }
        }else{
            // si le nombre de roue est inférieur a 4 alors on met 4
            if(nb < 4){
                nb = 4;
            }
            // si le nombre de roue est supérieur a 4 alors on met 4
            if(nb > 4){
                nb = 4;
            }
        }
        //********************************************Faire apparaitre les roues***************************************************//

        // charger une prefab provenant du fichier scenes prefab
        roues = Resources.Load("Prefabs/" + t_roue) as GameObject;
        // instancier la prefab avec un tag roue 
        if(nb == 6){
            if(type == "Camion1"){
            GameObject instance3 = Instantiate(roues, new Vector3(-22, -14, 90), Quaternion.identity) as GameObject;
            instance3.tag = "Roue";
            GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
            instance4.tag = "Roue";
            GameObject instance5 = Instantiate(roues, new Vector3(-42, -15, 90), Quaternion.identity) as GameObject;
            instance5.tag = "Roue";
            }else if(type == "Camion2"){
            GameObject instance3 = Instantiate(roues, new Vector3(-18, -14, 90), Quaternion.identity) as GameObject;
            instance3.tag = "Roue";
            GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
            instance4.tag = "Roue";
            GameObject instance5 = Instantiate(roues, new Vector3(-39, -14, 90), Quaternion.identity) as GameObject;
            instance5.tag = "Roue";
            }
        }else if(nb == 8){
            if(type == "Camion1"){
            GameObject instance3 = Instantiate(roues, new Vector3(-22, -14, 90), Quaternion.identity) as GameObject;
            instance3.tag = "Roue";
            GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
            instance4.tag = "Roue";
            GameObject instance5 = Instantiate(roues, new Vector3(-42, -15, 90), Quaternion.identity) as GameObject;
            instance5.tag = "Roue";
            GameObject instance6 = Instantiate(roues, new Vector3(-71, -16, 90), Quaternion.identity) as GameObject;
            instance6.tag = "Roue";
        }else if(type == "Camion2"){
                GameObject instance3 = Instantiate(roues, new Vector3(-18, -14, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
                GameObject instance5 = Instantiate(roues, new Vector3(-39, -14, 90), Quaternion.identity) as GameObject;
                instance5.tag = "Roue";
                GameObject instance6 = Instantiate(roues, new Vector3(-68, -15, 90), Quaternion.identity) as GameObject;
                instance6.tag = "Roue";
        }
        }else{
            // si le nombre est autre que 6 ou 8 alors on fait apparaitre 4 roues
            // on change le texte de l'input field nb de roue
            nb_roue.text = "4";
            // addapter les roues en fonction du véhicule
            if(type == "Bus"){
                GameObject instance3 = Instantiate(roues, new Vector3(-32, -11, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-81, -11, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }else if(type == "Camion1"){
                GameObject instance3 = Instantiate(roues, new Vector3(-22, -14, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }else if(type == "Camion2"){
                GameObject instance3 = Instantiate(roues, new Vector3(-18, -14, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-82, -14, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
            else if (type == "Voiture1")
            {
                GameObject instance3 = Instantiate(roues, new Vector3(-35, -6, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-68, -6, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
            else if (type == "Voiture2")
            {
                GameObject instance3 = Instantiate(roues, new Vector3(-32, -4, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-69, -4, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
            else if (type == "Voiture3")
            {
                GameObject instance3 = Instantiate(roues, new Vector3(-35, -5, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-67, -4, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
            else if (type == "Voiture4")
            {
                GameObject instance3 = Instantiate(roues, new Vector3(-29, -12, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-89, -12, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
            else if (type == "Camionnette")
            {
                GameObject instance3 = Instantiate(roues, new Vector3(-34, -11, 90), Quaternion.identity) as GameObject;
                instance3.tag = "Roue";
                GameObject instance4 = Instantiate(roues, new Vector3(-67, -11, 90), Quaternion.identity) as GameObject;
                instance4.tag = "Roue";
            }
        }
        FinalVehicle();
    }


    // Creation d'un prefabrique depuis les objets courants de la page
    public void FinalVehicle()
    {
        // detruit l'objet avec le nom FinalVehicle si il existe
        if (GameObject.Find("FinalVehicle") != null){
            Destroy(GameObject.Find("FinalVehicle"));
        }

        string nomPrefab = "FinalVehicle";

        // Stock la derniere couleur connue
        FinalColor = Color.options[Color.value].text;
    
        // Trouver tous les GameObjects avec les tags Véhicules et roue
        GameObject[] objetsVehicules = GameObject.FindGameObjectsWithTag("Véhicule");
        GameObject[] objetsRoues = GameObject.FindGameObjectsWithTag("Roue");

        // Fusion des tableaux
        GameObject[] objectsToGroup = new GameObject[objetsVehicules.Length + objetsRoues.Length];
        objetsVehicules.CopyTo(objectsToGroup, 0);
        objetsRoues.CopyTo(objectsToGroup, objetsVehicules.Length);

        // L'ekement avec recevant les objets apres fusion
        GameObject groupObject = new GameObject(nomPrefab);

        // Définir le GameObject parent comme parent des objets groupés
        foreach (GameObject obj in objectsToGroup)
        {
            obj.transform.parent = groupObject.transform;
        }
    }

    public static string getFinalColor(){
        return FinalColor;
    }


}