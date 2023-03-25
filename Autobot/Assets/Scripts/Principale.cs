using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principale : MonoBehaviour
{
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

        if(myObjectvehicule != null){
            SceneManager.UnloadSceneAsync("ParamVehicule");
            GameObject obj1 = Instantiate(myObjectvehicule,new Vector3(50,0,0), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            obj1.name = "FinalVehicle";
            Destroy(myObjectvehicule);
        }
        if(myObjectenvironement != null){
            SceneManager.UnloadSceneAsync("ParamEnvironement");
            GameObject obj2 = Instantiate(myObjectenvironement,new Vector3(50,0,0), Quaternion.identity, scene.GetRootGameObjects()[5].transform);
            obj2.name = "FinalEnvironement";
            Destroy(myObjectenvironement);
        }
        if(myObjectvehicule2 != null){
            GameObject obj1 = Instantiate(myObjectvehicule2,new Vector3(50,0,0), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            obj1.name = "FinalVehicle";
            Destroy(myObjectvehicule2);
        }
        if(myObjectenvironement2 != null){
            GameObject obj2 = Instantiate(myObjectenvironement2,new Vector3(50,0,0), Quaternion.identity, scene.GetRootGameObjects()[5].transform);
            obj2.name = "FinalEnvironement";
            Destroy(myObjectenvironement2);
        }
    }

}
