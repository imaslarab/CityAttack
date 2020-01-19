using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Photon.Pun;
using TMPro;

public class PlayerSelector : MonoBehaviour
{
    public Transform playerTransform;
    public Button prevBtn;
    public Button nextBtn;

    public int playerSelectionNumber;
    public GameObject[] spinnerTopModels;

    [Header("UI")]
    public TextMeshProUGUI playerModelType_Text;
    public GameObject uiSelection;
    public GameObject uiAfterSelection;

    // Start is called before the first frame update
    void Start()
    {
        playerSelectionNumber = 0;
        uiSelection.SetActive(true);
        uiAfterSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods

    public void NextPlayer() {
        print("next player");
        //print("y=" + playerTransform.rotation.eulerAngles.y);
        //if (playerTransform.rotation.eulerAngles.y % 90 != 0) {
        //    return;
        //}
        playerSelectionNumber += 1;
        if (playerSelectionNumber > 3) {
            playerSelectionNumber = 0;
        }
        nextBtn.enabled = false;
        prevBtn.enabled = false;
        StartCoroutine(Rotate(Vector3.up,playerTransform,90,1.0f));

        CharacterShown();
        print("playerSelectionNumber=" + playerSelectionNumber);
    }


    public void PreviousPlayer() {
        print("prev player");

        playerSelectionNumber -= 1;
        if (playerSelectionNumber < 0) {
            playerSelectionNumber = spinnerTopModels.Length - 1;
        }
        
        nextBtn.enabled = false;
        prevBtn.enabled = false;
        StartCoroutine(Rotate(Vector3.up,playerTransform,-90,1.0f));

        CharacterShown();
        print("playerSelectionNumber=" + playerSelectionNumber);
    }

    private void CharacterShown()
    {
        switch (playerSelectionNumber)
        {
            case 0: playerModelType_Text.text = "Average"; break;
            case 1: playerModelType_Text.text = "Speed++"; break;
            case 2: playerModelType_Text.text = "Ammo++"; break;
            case 3: playerModelType_Text.text = "Health++"; break;
        }
    }

    public void OnReselectButtonClicked() {
        uiSelection.SetActive(true);
        uiAfterSelection.SetActive(false);
    }

    public void OnSelectButtonClicked() {

        uiSelection.SetActive(false);
        uiAfterSelection.SetActive(true);

        //custom property
        //ExitGames.Client.Photon.Hashtable playerSelectionProp = new ExitGames.Client.Photon.Hashtable { {
        //        MultiplayerARTopGame.PLYAER_SELECTION_NUMBER,playerSelectionNumber
        //    }
        //};
        //PhotonNetwork.LocalPlayer.SetCustomProperties(playerSelectionProp);
        PlayerPrefs.SetInt("PLYAER_SELECTION_NUMBER", playerSelectionNumber);
    }

    public void OnBattleButtonClicked() {
        //SceneLoader.Instance.LoadScene("Scene_Gameplay_2");
        SceneLoader.Instance.LoadScene("VR_Game");
        print("game play");
    }

    public void OnBackButtonClicked() {
        SceneLoader.Instance.LoadScene("StartUI");
    }

    #endregion

    IEnumerator Rotate(Vector3 axis, Transform transformToRotate, float angle, float duration = 1.0f) {
        Quaternion originalRotation = transformToRotate.rotation;
        Quaternion finalRotation = transformToRotate.rotation * Quaternion.Euler(axis * angle);

        float elapsedTime = 0.0f;

        while (elapsedTime < duration) {
            transformToRotate.rotation = Quaternion.Slerp(originalRotation,finalRotation,elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transformToRotate.rotation = finalRotation;
        nextBtn.enabled = true;
        prevBtn.enabled = true;
    }
}
