using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject m_PrefabBomb;

    private GameObject bomb;

    private void Update()
    {
        //bomb = GameObject.FindObjectOfType<Bomb>();
        if (bomb == null || Vector2.Distance(gameObject.transform.position, bomb.transform.position) > 5f)
        {
            bomb = Instantiate(m_PrefabBomb,transform.position, Quaternion.identity);
        }
    }
}
