using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class HY_BricksBehaviour : MonoBehaviour
{// Start is called before the first frame update
  
    [SerializeField]
    Material red, white;
    MeshRenderer mr;
    float time;
    bool go;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material = white;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (go)
        {
            time += Time.deltaTime * 1.25f;
            if (transform.localScale.x >= 0f)
            {
                transform.localScale -= new Vector3(time, time, time);
                time = 0f;
            }
            if (transform.localScale.x < 0f)
            {
                transform.localScale = Vector3.zero;
            }
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            mr.material = red;
            if (HY_StartPause.countOver == true)
            {
                StartCoroutine(WaitMan());
            }
            
           

        }
    }
    IEnumerator WaitMan()
    {
        yield return new WaitForSeconds(0.2f);
        go = true;
    }


}
