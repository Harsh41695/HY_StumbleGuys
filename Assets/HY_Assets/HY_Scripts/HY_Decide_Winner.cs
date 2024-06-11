using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class HY_Decide_Winner : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPlayerWin, isEnemyWin;
    public float time;
    [SerializeField]
    HY_Player_Control playerControl;
    [SerializeField]
    HY_NavMeshEnemy[] enemyRef;
    [SerializeField]
    GameObject levelEndPanel, winnerBGImg;
    [SerializeField]
    TextMeshProUGUI winLooseTxt;
    bool isCalled = false;

    void Update()
    {
        if (isPlayerWin)
        {
            winLooseTxt.text = "QUALIFIED";
            levelEndPanel.SetActive(true);
            winnerBGImg.SetActive(true);
            time += Time.deltaTime;
            if (time > 5)
            {
                SceneManager.LoadScene(0);
            }

        }
        if (isEnemyWin)
        {
            winLooseTxt.text = "DISQUALIFIED";
            levelEndPanel.SetActive(true);
            time += Time.deltaTime;
            if (time >= 3)
            {
                SceneManager.LoadScene(0);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Player Win //Active Win Screen.
            isPlayerWin = true;
            playerControl.GetComponent<Animator>().SetTrigger("Victory");
            if (isCalled == false)
            {
                foreach (var item in enemyRef)
                {
                    item.GetComponent<NavMeshAgent>().speed = 0;
                    item.GetComponent<Animator>().SetTrigger("Defeat");
                    item.rndSpeed = 0;
                    item.canMove = false;
                }
                isCalled = true;
            }
            HY_Player_Control.canControl = false;



        }
        if (other.tag == "Enemy")
        {
            //Player Loose //Active Loose Screen.
            isEnemyWin = true;
            playerControl.GetComponent<Animator>().SetTrigger("Defeat");
            HY_Player_Control.canControl = false;
            // other.GetComponent<Animator>().SetTrigger("Victory");
            other.gameObject.GetComponent<HY_NavMeshEnemy>().touchedFinishLine = true;
            if (isCalled == false)
            {
                foreach (var item in enemyRef)
                {
                    if (item.touchedFinishLine)
                    {
                        item.GetComponent<Animator>().SetTrigger("Victory");
                    }
                    else
                    {
                        if (item.isActiveAndEnabled)
                        {
                            item.GetComponent<Animator>().SetTrigger("Defeat");
                            item.GetComponent<NavMeshAgent>().speed = 0;
                            item.canMove = false;
                        }
                    }
                    isCalled = true;
                }
            }

        }
    }


}

