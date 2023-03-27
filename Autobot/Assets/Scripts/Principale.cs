using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Principale : MonoBehaviour
{
    [SerializeField] int poids;
    [SerializeField] int supporté;
    [SerializeField] int Largeur_route;
    [SerializeField] int largeur_vehicule;
    // Start is called before the first frame update
    void Start()
    {
        // Nom de la prefab
        string vehicule = "FinalVehicle";
        string environement = "FinalEnvironement";
        string vehicule2 = "NewFinalVehicle";
        string environement2 = "NewFinalEnvironement";

        //cherche l'objet finalVehicle dans la scène ParamVehicule
        GameObject myObjectvehicule = GameObject.Find(vehicule);
        GameObject myObjectenvironement = GameObject.Find(environement);
        GameObject myObjectvehicule2 = GameObject.Find(vehicule2);
        GameObject myObjectenvironement2 = GameObject.Find(environement2);

        Scene scene = SceneManager.GetSceneByName("PagePrincipal");

        if(myObjectenvironement != null){
            GameObject obj2 = Instantiate(myObjectenvironement,new Vector3(45,20,0), Quaternion.identity, scene.GetRootGameObjects()[5].transform);
            obj2.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            obj2.name = "FinalEnvironement";
            Destroy(myObjectenvironement);
        }
        if(myObjectvehicule != null){
            GameObject obj1 = Instantiate(myObjectvehicule,new Vector3(60,15,10), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            if (myObjectenvironement != null){
                GameObject inclinaison = GameObject.Find("Inclinaison");
                obj1.transform.Rotate(0,-10,int.Parse(inclinaison.GetComponent<TMP_InputField>().text));
                obj1.transform.Translate(0,int.Parse(inclinaison.GetComponent<TMP_InputField>().text),0);
                obj1.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
            }else{
            obj1.transform.Rotate(0, -10, 0);
            obj1.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
            }
            obj1.name = "FinalVehicle";
            Destroy(myObjectvehicule);
        }
        if(myObjectenvironement2 != null){
            GameObject obj2 = Instantiate(myObjectenvironement2,new Vector3(45,20,0), Quaternion.identity, scene.GetRootGameObjects()[5].transform);
            obj2.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            obj2.name = "FinalEnvironement";
            Destroy(myObjectenvironement2);
        }
        if(myObjectvehicule2 != null){
            GameObject obj1 = Instantiate(myObjectvehicule2,new Vector3(60,15,10), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            if (myObjectenvironement != null){
                GameObject inclinaison = GameObject.Find("Inclinaison");
                obj1.transform.Rotate(0,-10,int.Parse(inclinaison.GetComponent<TMP_InputField>().text));
                obj1.transform.Translate(0,int.Parse(inclinaison.GetComponent<TMP_InputField>().text),0);
                // reduction de la taiille
                obj1.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
            }else{
            obj1.transform.Rotate(0, -10, 0);
            obj1.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
            }
            obj1.name = "FinalVehicle";
            Destroy(myObjectvehicule2);
        }
        // en fonction de la scène actuelle on la décharge
        if(SceneManager.GetActiveScene().name == "ParamVehicule"){
            SceneManager.UnloadSceneAsync("ParamVehicule");
        }
        if(SceneManager.GetActiveScene().name == "ParamEnvironement"){
            SceneManager.UnloadSceneAsync("ParamEnvironement");
        }
    }

    public void simulation()
    {
        // récupère l'objet finalVehicle dans la scène PagePrincipal
        GameObject FinalVec = GameObject.Find("FinalVec");
        GameObject FinalEnv = GameObject.Find("FinalEnv");
        poids = 0;
        supporté = 0;
        Largeur_route = 0;
        largeur_vehicule = 0;

        if (FinalVec.transform.childCount > 0 && FinalEnv.transform.childCount > 0){
            // récupère le premier enfant de finalVehicle dans une variable
            GameObject prefabvec = FinalVec.transform.GetChild(0).gameObject;
            // si le nom est "Camion1(clone)", "Camion2(clone)" ou "Bus(clone)" on ajoute 1000 au poids
            if(prefabvec.transform.GetChild(0).name == "Camion1(Clone)" || prefabvec.transform.GetChild(0).name == "Camion2(Clone)" || prefabvec.transform.GetChild(0).name == "Bus(Clone)"){
                poids += 1000;
                largeur_vehicule = 100;
            }else{
                poids += 250;
                largeur_vehicule = -50;
            }
            // compte le nombre d'enfant de prefab
            for(int i = 0; i < prefabvec.transform.childCount; i++){
                // si le nom de l'enfant est "Carrosserie" on l'affiche
                if(prefabvec.transform.GetChild(i).name == "Roue1(Clone)"){
                    supporté += 2*150;
                }
                if(prefabvec.transform.GetChild(i).name == "Roue2(Clone)"){
                    supporté += 2*250;
                }
                if(prefabvec.transform.GetChild(i).name == "Roue3(Clone)"){
                    supporté += 2*350;
                }
                if(prefabvec.transform.GetChild(i).name == "Conteneur1(Clone)"){
                    poids += 500;
                }
                if(prefabvec.transform.GetChild(i).name == "Conteneur2(Clone)"){
                    poids += 1500;
                }
            }
            GameObject prefabenv = FinalEnv.transform.GetChild(0).gameObject;
            GameObject env = prefabenv.transform.GetChild(0).gameObject;
            // recupère le scale de l'environement en y et fait -1000 pour avoir la largeur de la route
            Largeur_route = (int)(env.transform.localScale.y) - 1000;
        }

        // récupère le gameobject Resultats_Field
        GameObject Resultats_Field = GameObject.Find("Resultats_Field");

        if (largeur_vehicule > Largeur_route){
            Resultats_Field.GetComponent<TMP_InputField>().text = "Véhicule trop large \n largeur du véhicule: "+largeur_vehicule+"cm\n largeur de la route: "+Largeur_route+"cm";
        }
        else{
            Resultats_Field.GetComponent<TMP_InputField>().text = "Véhicule peut passer \n largeur du véhicule: "+largeur_vehicule+"cm\n largeur de la route: "+Largeur_route+"cm";
        }
        if (poids > supporté){
            Resultats_Field.GetComponent<TMP_InputField>().text += "\nVéhicule trop lourd \n poids du véhicule: "+poids+" kg\n poids supporté: "+supporté+"kg";
        }else{
            Resultats_Field.GetComponent<TMP_InputField>().text += "\nVéhicule est supporté \n poids du véhicule: "+poids+" kg\n poids supporté: "+supporté+"kg";
        }

    }

}
