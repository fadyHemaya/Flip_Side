using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howMenu : MonoBehaviour
{
    // Start is called before the first frame updatepublic 
    public GameObject optionMenuUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void backButton()
    {
        this.gameObject.SetActive(false);
        optionMenuUI.gameObject.SetActive(true);

    }
}