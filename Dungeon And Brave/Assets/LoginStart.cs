using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadSceneAsync("map");
    }
}
