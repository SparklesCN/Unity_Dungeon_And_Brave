using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Clicked! Exit!");
        Application.Quit();
    }
}
