using System.Collections.Generic;
using System.Collections.Specialized;

using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

using System.Collections;


[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaceObjectCube : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject prefab1;
    [SerializeField]
    private GameObject prefab2;
    [SerializeField]
    private GameObject prefab3;
    [SerializeField]
    private GameObject prefab4;
    [SerializeField]
    private GameObject prefab5;
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject prefabMain;
    [SerializeField]

    public MainMenuScript script;

    public bool placed;
    //public bool placed2;
    //public bool placed3;
    //public bool placed4;
    //public bool placed5;

    //private bool objectSpawned = false;


    private Vector3 rotationSpeed = new Vector3(5, 5, 5);


    private GameObject obj;
    //private GameObject obj2;
    //private GameObject obj3;
    //private GameObject obj4;
    //private GameObject obj5;

    private Pose pose;
    

    //private Pose pose2;


    //private Pose pose3;


    //private Pose pose4;
  

    //private Pose pose5;

    private int i;

    Vector3 scale = new Vector3(1, 1, 1);

    // Start is called before the first frame update

    

    private void Awake()
    {
        raycastManager= GetComponent<ARRaycastManager>();
        planeManager= GetComponent<ARPlaneManager>();
        script = GetComponent<MainMenuScript>();

    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {

                if (i == 0)
                {
                    foreach (ARRaycastHit hit in hits)
                    {
                        if (placed == false)
                        {
                            pose = hit.pose;
                            obj = Instantiate(prefab, new Vector3(pose.position.x, pose.position.y, pose.position.z), pose.rotation);
                            obj.transform.localScale = new Vector3(0.2f, 0.01f, 0.2f);
                            objectSpawned = true;
                            placed = true;
                        }
                      
                        if (objectSpawned == true)
                        {
                            obj.transform.position = hit.pose.position;
                        }
                      
                     }
               
                    prefabMain = prefab;

                    
                }
                if (i == 1)
                {
                    prefabMain = prefab1;

                    scale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                }
                if (i == 2)
                {
                    prefabMain = prefab2;
                    scale = new Vector3(0.0015f, 0.0015f, 0.0015f);

                }
                if (i == 3)
                {
                    prefabMain = prefab3;
                    scale = new Vector3(0.0015f, 0.0015f, 0.0015f);

                }
                if (i == 4)
                {
                    prefabMain = prefab4;

                    scale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                }
                if (i == 5)
                {
                    prefabMain = prefab5;
                    scale = new Vector3(0.0015f, 0.0015f, 0.0015f);

                }
                if (i == 6)
                {

        
                    placed = true;
                  

                }

               

                if (placed == false)
                {
                    pose = hit.pose;
                    obj = Instantiate(prefabMain, new Vector3(pose.position.x, pose.position.y + 0.0035f, pose.position.z), pose.rotation);
                    obj.transform.localScale = scale;
                    //objectSpawned = true;
                    i++;
                 
                }
                



                //if (placed2 == false)
                //{

                //    pose2 = hit.pose;
                //    obj2 = Instantiate(prefab2, new Vector3(pose2.position.x, pose2.position.y + 0.0035f, pose2.position.z), pose2.rotation);
                //    obj2.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                //    //objectSpawned = true;
                //    placed2 = true;
                //    placed3 = false;
                //}
                //if (placed3 == false)
                //{
                //    pose3 = hit.pose;
                //    obj3 = Instantiate(prefab3, new Vector3(pose3.position.x, pose3.position.y + 0.0035f, pose3.position.z), pose3.rotation);
                //    obj3.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                //    //objectSpawned = true;
                //    placed3 = true;
                //    placed4 = false;
                //}
                //if (placed4 == false)
                //{
                //    pose4 = hit.pose;
                //    obj4 = Instantiate(prefab4, new Vector3(pose4.position.x, pose4.position.y + 0.0035f, pose4.position.z), pose4.rotation);
                //    obj4.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                //    //objectSpawned = true;

                //    placed5 = false;
                //}
                //if (placed5 == false)
                //{
                //    pose5 = hit.pose;
                //    obj5 = Instantiate(prefab5, new Vector3(pose5.position.x, pose5.position.y + 0.0035f, pose5.position.z), pose5.rotation);
                //    obj5.transform.localScale = new Vector3(0.0015f, 0.0015f, 0.0015f);
                //    //objectSpawned = true;
                //    placed5 = true;

                //}

                //if (objectSpawned == true)
                //{
                //    obj.transform.position = new Vector3(hit.pose.position.x, hit.pose.position.y + 0.0035f, hit.pose.position.z);
                //    objectSpawned =false;
                //}


            }

        }
       
    }


    public void Rotate()
    {
        Debug.Log("Rotate Called");
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        

    }


}
