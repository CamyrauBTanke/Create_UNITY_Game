using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [Header("Volume setting")]
    [SerializeField] private Text Music_volumeText;
    [SerializeField] private Slider Music_volumeSlider;
    [SerializeField] private Text Dialog_volumeText;
    [SerializeField] private Slider Dialog_volumeSlider;
    [SerializeField] private Text Sound_volumeText;
    [SerializeField] private Slider Sound_volumeSlider;

    [Header("Save Setting")]
    [SerializeField] private float save_FONT_audio;

    void Start(){
        GetComponent<AudioSource>();
        ShowSliderValue();
    }

    private void newGame(){
        SceneManager.LoadScene("SampleScene");
    }

    private void loadSaveGame(){
        
    }

    private void exitGame(){
        Application.Quit();
    }

    private void ShowSliderValue(){
        Music_volumeText.text = Mathf.Round(Music_volumeSlider.value * 100) + "%";
        Dialog_volumeText.text = Mathf.Round(Dialog_volumeSlider.value * 100) + "%";
        Sound_volumeText.text = Mathf.Round(Sound_volumeSlider.value * 100) + "%";
    }
}
