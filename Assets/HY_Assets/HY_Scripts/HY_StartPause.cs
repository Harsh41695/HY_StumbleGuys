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
    public GameObject Enemies,Panel;
    void Start()
    {
        Enemies.SetActive(false);
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

        Time.timeScale = 1;
        Enemies.SetActive(true);
        img.gameObject.SetActive(false); 
        Panel.SetActive(false);


    }
}
