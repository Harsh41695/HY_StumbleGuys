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
    GameObject win_Loose_Canvas, canvas, winPanel, loosePanel, newCamera;
    bool isCalled=false;
    
    void Update()
    {
        if (isPlayerWin)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
               
                canvas.SetActive(false);
                win_Loose_Canvas.SetActive(true);
                newCamera.SetActive(true);
                winPanel.SetActive(true);
                loosePanel.SetActive(false);
                if (time > 12)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        if (isEnemyWin)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                canvas.SetActive(false);
                win_Loose_Canvas.SetActive(true);
                newCamera.SetActive(true);
                winPanel.SetActive(false);
                loosePanel.SetActive(true);
                if (time >= 9)
                {
                    SceneManager.LoadScene(0);
                }
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
            playerControl.canControl = false;



        }
        if (other.tag == "Enemy")
        {
            //Player Loose //Active Loose Screen.
            isEnemyWin = true;
            playerControl.GetComponent<Animator>().SetTrigger("Defeat");
            playerControl.canControl = false;
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
                        item.GetComponent<Animator>().SetTrigger("Defeat");
                        item.GetComponent<NavMeshAgent>().speed = 0;
                        item.canMove = false;
                    }
                    isCalled=true;

                }
            }
            
        }
    }


}

