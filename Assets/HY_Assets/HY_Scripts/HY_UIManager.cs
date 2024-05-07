using UnityEngine;

public class HY_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject exitPanel;

    void Start()
    {
        exitPanel.SetActive(false);
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

}
