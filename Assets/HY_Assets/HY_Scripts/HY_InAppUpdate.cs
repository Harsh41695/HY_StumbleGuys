using Google.Play.AppUpdate;
using Google.Play.Common;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class HY_InAppUpdate : MonoBehaviour
{
    [SerializeField] private GameObject updatePanel;
    AppUpdateManager appUpdateManager;
    //bool update = false;
    [SerializeField]
    private string playStoreUrlLink = "https://play.google.com/store/apps/details?id=com.mailtoalbatrossgamingstudios.PawSomeAdventure&pli=1";
   
    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.appUpdateManager = new AppUpdateManager();
        }

        StartCoroutine(CheckForPlayStoreUpdate());

        
    }
    IEnumerator CheckForPlayStoreUpdate()
    {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appupdateInfoOperation =
        appUpdateManager.GetAppUpdateInfo();

        yield return appupdateInfoOperation;

        if (appupdateInfoOperation.IsSuccessful)
        {
            var appupdateInfoResult = appupdateInfoOperation.GetResult();
            //float size=appupdateInfoResult.TotalBytesToDownload * 1000000;
            if (appupdateInfoResult.UpdateAvailability == UpdateAvailability.UpdateAvailable)
            {
                updatePanel.SetActive(true);
            }
            else
            {
                updatePanel.SetActive(false);
            }
        }
    }
    public void UpdateButton()
    {
        Application.OpenURL(playStoreUrlLink);
    }
    public void NotNow()
    {
        updatePanel.SetActive(false);
        //or Application Quit.
    }
}