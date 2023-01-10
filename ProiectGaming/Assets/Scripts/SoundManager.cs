using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

}
