using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHealthPointPlayer : MonoBehaviour
{
    [SerializeField] private Text textPercentHealth;
    [SerializeField] private Image progressbarHealth;
    [SerializeField] private Player player;

    [SerializeField] private Text textPercentMana;
    [SerializeField] private Image progressbarMana;

    private void Update()
    {
        progressbarHealth.fillAmount = player.CurrentHealthPoint / player.MaxHealthPoint;
        textPercentHealth.text = player.CurrentHealthPoint.ToString() + "%";

        progressbarMana.fillAmount = player.CurrentManaPoint / player.MaxManaPoint;
        textPercentMana.text = player.CurrentManaPoint.ToString() + "%";
    }
}
