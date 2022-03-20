using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [Header("Volume setting")]
    [SerializeField] private Text Music_volumeText = null;
    [SerializeField] private Slider Music_volumeSlider = null;
    [SerializeField] private Text Dialog_volumeText = null;
    [SerializeField] private Slider Dialog_volumeSlider = null;
    [SerializeField] private Text Sound_volumeText = null;
    [SerializeField] private Slider Sound_volumeSlider = null;

    public void newGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void loadSaveGame(){
        
    }

    public void exitGame(){
        Application.Quit();
    }

    public void ShowSliderValue()
    {
        Music_volumeText.text = Music_volumeSlider.value.ToString() + "%";
        Dialog_volumeText.text = Dialog_volumeSlider.value.ToString() + "%";
        Sound_volumeText.text = Sound_volumeSlider.value.ToString() + "%";
    }
}
