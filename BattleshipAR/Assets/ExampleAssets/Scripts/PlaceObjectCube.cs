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

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    public bool placed = false;

    public bool objectSpawned = false;

    private Pose pose;
    private GameObject obj;
    // Start is called before the first frame update
    private void Awake()
    {
        raycastManager= GetComponent<ARRaycastManager>();
        planeManager= GetComponent<ARPlaneManager>();
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
               
                }
        
      
      
    }
}
