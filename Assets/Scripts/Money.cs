using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text m_TextMoney;
    
    public static int m_Money = 0;

    //public int MoneyProp
    //{
    //    get
    //    {
    //        return m_Money;
    //    }
    //    set
    //    {
    //        m_Money = value;
    //    }
    //}

    private void Update()
    {
        m_TextMoney.text = m_Money.ToString();
    }
}
