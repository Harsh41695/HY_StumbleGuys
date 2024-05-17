using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject loadingScreen,playerModel;
    [SerializeField]
    Image slider;
    float progress;
    int levelIndex;
   
    private void Start()
    {
        levelIndex = Random.Range(1, 3);
    }
    public void PlayBtn()
    {
        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress/.9f);
            slider.fillAmount= progress;
            loadingScreen.SetActive(true);
            yield return null;
        }
    }
}
