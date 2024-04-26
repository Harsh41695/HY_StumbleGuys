using UnityEngine;
using UnityEngine.SceneManagement;

public class HY_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject inGamePanel, homeScreenPanel,exitPanel;
    [SerializeField]
    GameObject enmy1, enmy2;

    void Start()
    {
        inGamePanel.SetActive(false);
        homeScreenPanel.SetActive(true);
        exitPanel.SetActive(false);
        enmy1.SetActive(false);
        enmy2.SetActive(false);
    }

    // Update is called once per frame
   
    public void Play()
    {
        inGamePanel.SetActive(true);
        homeScreenPanel.SetActive(false); 
        enmy1.SetActive(true);
        enmy2.SetActive(true);
    }
    public void ExitCross()
    {
        exitPanel.SetActive(true);
    }
    public void ContinuePlayBtn()
    {
        exitPanel.SetActive(false);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void LevelCompleteExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
