using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Mesh))]


public class PlacementRotation : MonoBehaviour
{

    private Mesh placementObject;


    [SerializeField]

    private Vector3 rotationSpeed = new Vector3(1, 1, 1);


    void Awake()
    {

        placementObject = GetComponent<Mesh>();

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);


    }
}
