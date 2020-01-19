using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class ARPlacementManager : MonoBehaviour
{
    ARRaycastManager m_ARRaycastManager;
    static List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();

    public Camera ARCamera;

    public GameObject cityMapGameObject;

    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
        //print(m_ARRaycastManager);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 4);
        Ray ray = ARCamera.ScreenPointToRay(centerOfScreen);
        
        print(ray + " " + raycast_hits);
        if (m_ARRaycastManager.Raycast(ray, raycast_hits, TrackableType.PlaneWithinPolygon))
        {
            //print("find raycast" + raycast_hits.Count);
            var hitPose = raycast_hits[0].pose;
            //Vector3 positionToBePlaced = hitPose.position;

            cityMapGameObject.transform.position = hitPose.position;
        }
        else
        {

        }
    }
}
