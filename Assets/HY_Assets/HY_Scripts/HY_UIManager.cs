using UnityEngine;
public class HY_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject exitPanel, shopPanel, missionPanel, playerModel, settingPanel,
        selectedDailyMissionBtn, unSelectedDailyMissionBtn,//Mission buttons
        selectedWeeklyMissionBtn, unSelectedWeeklyMissionBtn,//Weekly Buttons
        selectAchivementBtn, unSelectedAchivementBtn,//Achivement Buttons
        dailyMissionPanel, weeklyMissionPanel, achivementPanel;// Panel references
    bool isAnyOtherPanelActive;

    void Start()
    {
        exitPanel.SetActive(false);
        shopPanel.SetActive(false);
        missionPanel.SetActive(false);

    }

    public void ExitCross()//
    {
        exitPanel.SetActive(true);
    }
    public void ContinuePlayBtn()//
    {
        exitPanel.SetActive(false);
    }
    public void ExitBtn()//
    {
        Application.Quit();
    }
    public void ShopBtn()//
    {
        isAnyOtherPanelActive = true;

        shopPanel.SetActive(true);
        playerModel.SetActive(false);
    }
    public void MissionBtn()//
    {
        isAnyOtherPanelActive = true;

        missionPanel.SetActive(true);
        playerModel.SetActive(false);
    }
    public void HomeBtn()//
    {
        isAnyOtherPanelActive = false;
        shopPanel.SetActive(false);
        playerModel.SetActive(true);
    }
    public void MissionExitBtn()//
    {
        isAnyOtherPanelActive = false;
        missionPanel.SetActive(false);
        playerModel.SetActive(true);

    }
    public void DailyMissionBtn()
    {
        dailyMissionPanel.SetActive(true);
        weeklyMissionPanel.SetActive(false);
        achivementPanel.SetActive(false);
        //////////////////////////////////////////
        selectedDailyMissionBtn.SetActive(true);
        selectedWeeklyMissionBtn.SetActive(false);
        selectAchivementBtn.SetActive(false);
        unSelectedDailyMissionBtn.SetActive(false);
        unSelectedWeeklyMissionBtn.SetActive(true);
        unSelectedAchivementBtn.SetActive(true);

    }
    public void WeeklyMissionBtn()
    {
        dailyMissionPanel.SetActive(false);
        weeklyMissionPanel.SetActive(true);
        achivementPanel.SetActive(false);
        /////////////////////////////////////////
        selectedDailyMissionBtn.SetActive(false);
        selectedWeeklyMissionBtn.SetActive(true);
        selectAchivementBtn.SetActive(false);
        unSelectedDailyMissionBtn.SetActive(true);
        unSelectedWeeklyMissionBtn.SetActive(false);
        unSelectedAchivementBtn.SetActive(true);
    }
    public void AchivementBtn()
    {
        dailyMissionPanel.SetActive(false);
        weeklyMissionPanel.SetActive(false);
        achivementPanel.SetActive(true);
        /////////////////////////////////////////
        selectedDailyMissionBtn.SetActive(false);
        selectedWeeklyMissionBtn.SetActive(false);
        selectAchivementBtn.SetActive(true);
        unSelectedDailyMissionBtn.SetActive(true);
        unSelectedWeeklyMissionBtn.SetActive(true);
        unSelectedAchivementBtn.SetActive(false);
    }

    public void SettingBtn()
    {
        isAnyOtherPanelActive = true;
        playerModel.SetActive(false);
        settingPanel.SetActive(true);

    }
    bool isAnyPanelOpen()
    {
        if (shopPanel.activeInHierarchy || missionPanel.activeInHierarchy)
        {
            return true;
        }
        return false;
    }
    public void SettingExit()
    {
        settingPanel.SetActive(false);

        if (isAnyPanelOpen())
        {
            playerModel.SetActive(false);
        }
        else
        {
            playerModel.SetActive(true);
        }

    }
}
