using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string m_Group;
    [SerializeField] private string m_Key;
    [SerializeField] private Text m_TextPersent;

    private void Start()
    {
        if (PlayerPrefs.HasKey(m_Key))
        {
            audioMixer.SetFloat(m_Group, Mathf.Log10(PlayerPrefs.GetFloat(m_Key)) * 20);
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat(m_Key);
            m_TextPersent.text = (gameObject.GetComponent<Slider>().value * 100).ToString("F0") + "%";
        }
    }
    public void SetVolume()
    {
        audioMixer.SetFloat(m_Group, Mathf.Log10(gameObject.GetComponent<Slider>().value) * 20);
        m_TextPersent.text = (gameObject.GetComponent<Slider>().value * 100).ToString("F0") + "%";
        PlayerPrefs.SetFloat(m_Key, gameObject.GetComponent<Slider>().value);
        PlayerPrefs.Save();
    }
}
