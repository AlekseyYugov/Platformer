using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_Setting;
    [SerializeField] private Scenes m_Scene;
    private void Start()
    {
        if(m_MainMenu!= null && m_Setting != null)
        {
            m_MainMenu.SetActive(true);
            m_Setting.SetActive(false);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            LoadScene(m_Scene.m_SceneName);
        }
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void Setting()
    {
        if (m_MainMenu != null && m_Setting != null)
        {
            m_Setting.SetActive(true);
            m_MainMenu.SetActive(false);
        }       
    }
    public void Back()
    {
        if (m_MainMenu != null && m_Setting != null)
        {
            m_MainMenu.SetActive(true);
            m_Setting.SetActive(false);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
