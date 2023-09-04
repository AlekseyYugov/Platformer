using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text m_TextMoney;    
    public static int m_Money = 0;
    private void Update()
    {
        m_TextMoney.text = m_Money.ToString();
    }
}
