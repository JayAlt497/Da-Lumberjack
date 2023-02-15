using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//////////////////////////////
// Written by: Jayden Alton //
// Associate writing:       //
// Last Modified: 2/14/2023 //
//////////////////////////////
///
public class Camera : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera will follow the user
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
