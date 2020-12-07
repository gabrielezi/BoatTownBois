using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToCredits : MonoBehaviour
{
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(2);
    }
}
