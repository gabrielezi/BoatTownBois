using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private Text dayText;
    [SerializeField]
    private Text islandNameText;
    [SerializeField]
    private Text coinsText;

    public void UpdateDayText(string text)
    {
        dayText.text = text;
    }
    public void UpdateIslandNameText(string text)
    {
        islandNameText.text = text;
    }
    public void UpdateCoinsText(string text)
    {
        coinsText.text = text;
    }
}
