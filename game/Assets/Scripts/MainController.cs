using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [Header("Volume setting")]
    [SerializeField] private Text music_volume_text;
    [SerializeField] private Slider music_volume_slider;
    [SerializeField] private Text dialog_volume_text;
    [SerializeField] private Slider dialog_volume_slider;
    [SerializeField] private Text sound_volume_text;
    [SerializeField] private Slider sound_volume_slider;
    
    [Header("Save Setting")]
    [SerializeField] public float save_font_audio_volume;
    [SerializeField] public float save_sound_audio_volume;

    void Start()
    {
        Get_Setting();
        ShowSliderValue();
    }

    private void newGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Load_Save_Game()
    {
        
    }

    private void exitGame()
    {
        Application.Quit();
    }

    private void ShowSliderValue()
    {
        music_volume_text.text = Mathf.Round(music_volume_slider.value * 100) + "%";
        dialog_volume_text.text = Mathf.Round(dialog_volume_slider.value * 100) + "%";
        sound_volume_text.text = Mathf.Round(sound_volume_slider.value * 100) + "%";

        Save_Setting();
    }

    public void Save_Setting()
    {
        string key = "save_setting";
        SaveDataSetting setting = new SaveDataSetting();

        setting.save_font_audio_volume = music_volume_slider.value;
        setting.save_sound_audio_volume = sound_volume_slider.value;

        string value = JsonUtility.ToJson(setting);
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public void Load_Setting()
    {
        string key = "save_setting";
        if (PlayerPrefs.HasKey(key)) 
        {
            string value = PlayerPrefs.GetString(key);
            
            SaveDataSetting setting = JsonUtility.FromJson<SaveDataSetting>(value);
            save_font_audio_volume = setting.save_font_audio_volume;
            save_sound_audio_volume = setting.save_sound_audio_volume;
        }
        else 
            Debug.LogError("There is no save data!");
    }

    public void Get_Setting()
    {
        Load_Setting();
        music_volume_slider.value = save_font_audio_volume;
        sound_volume_slider.value = save_sound_audio_volume;
    }
}

public class SaveDataSetting {
    public float save_font_audio_volume;
    public float save_sound_audio_volume;
}
