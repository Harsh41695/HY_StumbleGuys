using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class _CheckWinner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> enemyList = new List<GameObject>();
    bool canRunUpdate;
    [SerializeField]
    GameObject levelEndPanel,winnerBGImg;
    [SerializeField]
    TextMeshProUGUI winLooseTxt;
    float time;
    bool playerWon, enemyWon;
    [SerializeField]
    GameObject ref_Player;
    void Start()
    {
        canRunUpdate = true;
        winnerBGImg.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRunUpdate)
        {
            if (enemyList.Count <= HY_DeathZone.enemyDeathCount)
            {
                Debug.Log("Player Winner");
                playerWon = true;
                //can avtive Panel
                ref_Player.GetComponent<Rigidbody>().isKinematic = true;
                canRunUpdate =false;
            }
            if (HY_DeathZone.enemyDeathCount < 0)
            {
                enemyWon = true;
              
            }
        }
        WhoWon();

    }
    void WhoWon()
    {
        if (playerWon)
        {
            winLooseTxt.text = "QUALIFIED";
            levelEndPanel.SetActive(true);
            winnerBGImg.SetActive(true);
            time += Time.deltaTime;
            if (time > 5)
            {
                    //Complete screen.
                    SceneManager.LoadScene(0);
                
            }
        }
        else if(enemyWon)
        {
            winLooseTxt.text = "DISQUALIFIED";
            levelEndPanel.SetActive(true);
            time += Time.deltaTime;
            if (time > 3)
            {
                
                
                    // Complete screen.
                    SceneManager.LoadScene(0);
                
            }
        }
    }
}
