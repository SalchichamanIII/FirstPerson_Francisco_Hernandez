using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausaUI; // Panel del men� de pausa

    private bool estaPausado = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estaPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        menuPausaUI.SetActive(true); 
        Time.timeScale = 0f; 
        estaPausado = true;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void Reanudar()
    {
        menuPausaUI.SetActive(false); 
        Time.timeScale = 1f; 
        estaPausado = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    public void Salir()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1);
    }
}
