using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_PrefabBomb;

    private Bomb bomb;

    private void Update()
    {
        bomb = GameObject.FindObjectOfType<Bomb>();
        if (bomb == null)
        {
            Instantiate(m_PrefabBomb,transform.position, Quaternion.identity);
        }
    }
}
