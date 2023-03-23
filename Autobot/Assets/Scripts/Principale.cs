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
        string nomPrefab = "FinalVehicle";

        // Recupère la couleur actuelle
        string color = Modif_Vehicule.getFinalColor();

        if(color == null){
            color = "Bleu";
        }

        //cherche l'objet finalVehicle dans la scène ParamVehicule
        GameObject myObject = GameObject.Find(nomPrefab);

        if(myObject != null){
            Scene scene = SceneManager.GetSceneByName("PagePrincipal");
            GameObject obj = Instantiate(myObject,new Vector3(100,-20,0), Quaternion.identity, scene.GetRootGameObjects()[4].transform);
            SceneManager.UnloadSceneAsync("ParamVehicule");
            obj.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = Resources.Load("Textures/Palette_"+color) as Texture;
            Destroy(myObject);
        }
    }

}
