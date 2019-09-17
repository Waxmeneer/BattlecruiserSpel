using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarManager : MonoBehaviour {

    private float totalTime = 5f;
    private float timeLeft = 5f;
    public Image timeLeftBar;
    public Button startTurnButton;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        startTurnButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        StartCoroutine(StartTimer());
        startTurnButton.interactable = false;
    }

    private IEnumerator StartTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            timeLeft -= 0.01f;
            timeLeftBar.fillAmount = timeLeft / totalTime;
        }
    }
}