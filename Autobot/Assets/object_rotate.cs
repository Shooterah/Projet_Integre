using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // fait tourner Truck sur lui même
        transform.Rotate(0, 1, 0);
    }
}
