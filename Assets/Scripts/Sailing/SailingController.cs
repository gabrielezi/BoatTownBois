using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sailing
{
    public class SailingController : MonoBehaviour
    {
        [SerializeField]
        private GameObject map;
        
        public void LoadEndIsland()
        {
            SceneManager.LoadScene(4);
        }

        public void OpenMap()
        {
            map.SetActive(true);
        }

        public void CloseMap()
        {
            map.SetActive(false);
        }
    }
}
