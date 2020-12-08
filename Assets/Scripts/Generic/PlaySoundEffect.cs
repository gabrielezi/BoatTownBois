using UnityEngine;

namespace Generic
{
    public class PlaySoundEffect : MonoBehaviour
    {
        [SerializeField] private string soundEffectName;
        
        public void Play()
        {
            SoundManager.Instance.PlaySound(soundEffectName);
        }
    }
}
