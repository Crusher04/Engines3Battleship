using System.Collections.Generic;
using System.Collections.Specialized;

using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


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

    public MainMenu script;

    public bool placed;


    private Vector3 rotationSpeed = new Vector3(5, 5, 5);


    private GameObject obj;


    private Pose pose;
    



    private int i;
    private float height = -0.0025f;
    Vector3 scale = new Vector3(1, 1, 1);

    // Start is called before the first frame update

    

    private void Awake()
    {
        raycastManager= GetComponent<ARRaycastManager>();
        planeManager= GetComponent<ARPlaneManager>();
        script = GetComponent<MainMenu>();

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
                    prefabMain = prefab;
                    scale = new Vector3(0.2f, 0.02f, 0.2f);
                    
                }
                if (i == 1)
                {
                    prefabMain = prefab1;
                    height = -0.012f;
                    scale = new Vector3(0.0025f, 0.0025f, 0.0025f);
                    scale = scale / 2 ;
                }
                if (i == 2)
                {
                    prefabMain = prefab2;
                    scale = new Vector3(0.0045f, 0.0045f, 0.0045f);
                    height = -0.018f;
                    scale = scale / 2; 
                    
                }
                if (i == 3)
                {
                    prefabMain = prefab3;
                    scale = new Vector3(0.0060f, 0.0060f, 0.0060f);
                    height = -0.02f;
                    scale = scale / 2; 
                }
                if (i == 4)
                {
                    prefabMain = prefab4;
                    height = -0.01f;
                    scale = new Vector3(0.0035f, 0.0035f, 0.0035f);
                    scale = scale / 2; 
                }
                if (i == 5)
                {
                    prefabMain = prefab5;
                    scale = new Vector3(0.0050f, 0.0050f, 0.0050f);
                    height = -0.018f;
                    scale = scale / 2;
                }
                if (i == 6)
                {

        
                    placed = true;
                  

                }

               

                if (placed == false)
                {
                    pose = hit.pose;
                    obj = Instantiate(prefabMain, new Vector3(pose.position.x, pose.position.y + height, pose.position.z), pose.rotation);
                    obj.transform.localScale = scale;
       
                    i++;
                 
                }
                



               

            }

        }
       
    }


   /* public void Rotate()
    {
        Debug.Log("Rotate Called");
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        

    }
*/

}
