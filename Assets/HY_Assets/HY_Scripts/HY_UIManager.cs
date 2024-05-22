using UnityEngine;

public class HY_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject exitPanel, shopPanel, missionPanel, playerModel;


    void Start()
    {
        exitPanel.SetActive(false);
        shopPanel.SetActive(false);
        missionPanel.SetActive(false);
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
    public void ShopBtn()
    {
        shopPanel.SetActive(true);
        playerModel.SetActive(false);
    }
    public void MissionBtn()
    {
        missionPanel.SetActive(true);
        playerModel.SetActive(false);
    }
    public void HomeBtn()
    {
        shopPanel.SetActive(false);
        playerModel.SetActive(true);
    }
    public void MissionExitBtn()
    {
        missionPanel.SetActive(false);
        playerModel.SetActive(true);

    }

}
