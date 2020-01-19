using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlacementAndARPlaneDetection : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;
    ARPlacementManager m_ARPlacementManager;

    public GameObject adjustButton;
    public GameObject placeButton;

    public GameObject gameUIObj;
    //public GameObject exitButton;

    private void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
        m_ARPlacementManager = GetComponent<ARPlacementManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        placeButton.SetActive(true);
        adjustButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setAllPlanesActiveDeactive(bool value)
    {
        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

    public void DisableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = false;
        m_ARPlacementManager.enabled = false;
        setAllPlanesActiveDeactive(false);

        placeButton.SetActive(false);
        adjustButton.SetActive(true);

        // make gameUIObj visible
        gameUIObj.SetActive(true);

        //searchForGameButton.SetActive(true);

        //informUIPanel_Text.text = "Great! You placed the Arena!";
    }

    public void enableARPlacementAndPlaneDetection()
    {
        m_ARPlaneManager.enabled = true;
        m_ARPlacementManager.enabled = true;
        setAllPlanesActiveDeactive(true);

        placeButton.SetActive(true);
        adjustButton.SetActive(false);
        //searchForGameButton.SetActive(false);
        gameUIObj.SetActive(false);
        //informUIPanel_Text.text = "Move Phone to detect planes and place Arena!";
    }
}
