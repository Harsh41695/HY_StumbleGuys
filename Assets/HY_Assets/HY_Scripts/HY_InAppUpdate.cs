using UnityEngine;
using System.Collections;
using Google.Play.AppUpdate;
using Google.Play.Common;
using Unity.VisualScripting;

public class HY_InAppUpdate : MonoBehaviour
{
    [SerializeField] private GameObject updatePanel;
    AppUpdateManager appUpdateManager;
    bool update = false;
    [SerializeField]
    private string playStoreUrlLink;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.appUpdateManager = new AppUpdateManager();
        }

        StartCoroutine(CheckForUpdate());
    }
#if !Unity_Editor
    IEnumerator CheckForUpdate()
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
#endif
}




