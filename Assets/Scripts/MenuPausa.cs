using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausaUI; // Panel del menú de pausa
    [SerializeField] private AudioSource musicaFondo;

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
        if (musicaFondo != null)
        {
            musicaFondo.Pause();
        }
    }

    public void Reanudar()
    {
        menuPausaUI.SetActive(false); 
        Time.timeScale = 1f; 
        estaPausado = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        if (musicaFondo != null)
        {
            musicaFondo.UnPause();
        }
    }

    public void Salir()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1);
    }
}
