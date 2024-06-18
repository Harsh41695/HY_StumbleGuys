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
    private string appStroeUrlLink = "";
    private string currentUrl;
    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.appUpdateManager = new AppUpdateManager();
        }

        StartCoroutine(CheckForPlayStoreUpdate());

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            StartCoroutine(CheckForAppStoreUpdate());
        }
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

    /// if IPhone..
    private IEnumerator CheckForAppStoreUpdate()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(appStroeUrlLink))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string serverVersion = www.downloadHandler.text;
                string currentVersion = Application.version;

                if (serverVersion != currentVersion)
                {
                    // Update is available, prompt user to update
                    PromptUpdate();
                }
                else
                {
                    Debug.Log("No update available.");
                }
            }
            else
            {
                Debug.LogError("Error checking for update: " + www.error);
            }
        }
    }
    //Panel set active.
    private void PromptUpdate()
    {
        // Implement your logic to prompt the user to update here
        // This could involve showing a message to the user
        Debug.Log("Update available. Please update the app.");
    }

}