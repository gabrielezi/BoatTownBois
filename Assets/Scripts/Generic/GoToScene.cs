using UnityEngine;
using UnityEngine.SceneManagement;

namespace Generic
{
    public class GoToScene : MonoBehaviour
    {
        [SerializeField] private int scene;
        
        public void Change()
        {
            SceneManager.LoadScene(scene);
        }
    }
}
