using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoSingleton<SoundPlayer>
{
    [SerializeField] private new AudioSource audio;
    private GameObject obj;
    private new void Awake()
    { 
        if(GameObject.Find("SoundPlayer") != gameObject)
        {
            obj = GameObject.Find("SoundPlayer");
        }

        if (obj != null)
        {
            Destroy(gameObject);
        }
        base.Awake();
        audio.Play();

    }
}


