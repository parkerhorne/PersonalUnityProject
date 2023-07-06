using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{

    [SerializeField] private GameObject _inventory;

    [SerializeField] private GameObject _mainUI;

    [SerializeField] private GameObject _pauseMenu;

    // If you set the main UI inactive, the timer stops working.
    private Canvas _mainUICanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_inventory)
        {
            _inventory = GameObject.Find("InventoryUI");
        }

        if (!_mainUI)
        {
            _mainUI = GameObject.Find("UICanvas");
        }

        if (!_pauseMenu)
        {
            _pauseMenu = GameObject.Find("PauseMenu");
        }

        _mainUICanvas = _mainUI.GetComponent<Canvas>();
        _pauseMenu.SetActive(false);
        _inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            _mainUICanvas.scaleFactor = 0;
            _inventory.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _mainUICanvas.scaleFactor = 1;
            _inventory.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _mainUI.SetActive(false);
            _inventory.SetActive(true);
            _pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        _mainUI.SetActive(true);
        _inventory.SetActive(false);
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
