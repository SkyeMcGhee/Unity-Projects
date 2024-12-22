using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject inventory;
   public ArrayList images = new ArrayList();
    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       canvas.SetActive(false);
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) ) 
        {
            canvas.SetActive(!canvas.active);        
        }
        if ( playerController.getPickups() == true && Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(!inventory.active);
        }

    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("Quit called");
    }

  
}
