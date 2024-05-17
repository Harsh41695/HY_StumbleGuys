using UnityEngine;
using UnityEngine.EventSystems;

public class HY_OnPointerDown : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    HY_Player_Control player_Ref;
    public void OnPointerDown(PointerEventData eventData)
    {
        player_Ref.MobileJumpBtn();
        Debug.Log("Jump Called");
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (player_Ref == null)
        {
            player_Ref = FindAnyObjectByType<HY_Player_Control>();
        }

    }

   
}
