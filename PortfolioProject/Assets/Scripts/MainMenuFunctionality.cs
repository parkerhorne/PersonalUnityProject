using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFunctionality : MonoBehaviour
{
    private GameObject _mainMenu;
    private GameObject _selectMenu;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu = GameObject.Find("MainMenuCanvas");
        _selectMenu = GameObject.Find("CharSelectCanvas");
        _selectMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSelectMenu()
    {
        _mainMenu.SetActive(false);
        _selectMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        _mainMenu.SetActive(true);
        _selectMenu.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
