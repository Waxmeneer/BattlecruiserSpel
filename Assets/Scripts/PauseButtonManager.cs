using UnityEngine.UI;
using UnityEngine;

public class PauseButtonManager : MonoBehaviour {

    bool isPaused = false;
    public Button pauseButton;

    void Start()
    {
        pauseButton.onClick.AddListener(OnClick);
    }

    //Invert isPaused condition and calls for pause
    void OnClick()
    {
        {
            isPaused = !isPaused;
            TogglePause();
        }
    }

    //Toggles pause based on isPaused condition
    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
