using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HY_StartPause : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Sprite[] sprite;
    [SerializeField]
    Image img;
    public GameObject Enemies, Panel;
    public static bool countOver;
    void Start()
    {
        if (Enemies != null)
        {
            Enemies.SetActive(false);
        }
        countOver = false;
        StartCoroutine(StartCount());
        
    }
    IEnumerator StartCount()
    {

        img.sprite = sprite[2];
        yield return new WaitForSeconds(1);
        img.sprite = sprite[1];
        yield return new WaitForSeconds(1);
        img.sprite = sprite[0];
        yield return new WaitForSeconds(1);
        countOver = true;
        Time.timeScale = 1;
        if (Enemies != null)
        {
            Enemies.SetActive(true);
        }
        img.gameObject.SetActive(false);
        Panel.SetActive(false);


    }
}
