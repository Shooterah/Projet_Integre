using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_moove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //faire tourner la caméra autour du truck_1_Blue
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 20 * Time.deltaTime);
    }
}
