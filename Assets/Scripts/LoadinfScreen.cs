using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadinfScreen : MonoBehaviour
{

    [Header("Screens")]
    [SerializeField] private GameObject loadScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("SLider")]
    [SerializeField] private Slider loadinfSlider;



    public void PlayButton(string LoadToLevel)
    {
        mainMenu.SetActive(false);
        loadScreen.SetActive(true);

      StartCoroutine(LoadLevelASync(LoadToLevel));

    }

    // loading asynic Operation ......!

    IEnumerator LoadLevelASync(string LoadToLevel)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(LoadToLevel);
        while (!loadOperation.isDone)
        {
           float progressValue = Mathf.Clamp01(loadOperation .progress / 0.9f);
           loadinfSlider.value = progressValue;
           yield return null;
        }
    }

}
