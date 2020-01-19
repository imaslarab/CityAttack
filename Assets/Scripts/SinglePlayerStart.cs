using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerStart : MonoBehaviour
{
    public GameObject UI_Login;
    public InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        UI_Login.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartGameClicked() {
        UI_Login.SetActive(true);
    }

    public void onEnterName() {
        string name = nameInput.text;
        if (!string.IsNullOrEmpty(name))
        {
            PlayerPrefs.SetString("player", name);
            SceneLoader.Instance.LoadScene("Scene_PlayerSelection_2");
        }
        else {
            print("name should not be blank");
        }

    }
}
