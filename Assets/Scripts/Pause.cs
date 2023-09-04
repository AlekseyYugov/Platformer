using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject m_MenuPause;
    private void Start()
    {
        m_MenuPause.SetActive(false);
    }
    public void ButtonPause()
    {
        if(m_MenuPause.activeSelf == false)
        {
            m_MenuPause.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            m_MenuPause.SetActive(false);
            Time.timeScale = 1.0f;
        }
        
    }
    public void ButtonContinue()
    {
        Time.timeScale = 1.0f;
        m_MenuPause.SetActive(false);        
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
