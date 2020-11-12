using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    bool mute;
    public GameObject mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        mute = false;
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void muteButton()
    {
        mute = !mute;
        if (mute)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
    public void backButton()
    {
        this.gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(true);

    }
}
