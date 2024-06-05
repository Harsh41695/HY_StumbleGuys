using UnityEngine;

public class HY_ImageMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float x = 5, speed = 6;
    RectTransform rectTransform;
    [SerializeField] private GameObject pos;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        MoveRight();
        if (rectTransform.position.x <= -5)
        {
            rectTransform.position = new Vector3(x, rectTransform.position.y, rectTransform.position.z);
            rectTransform.position = pos.transform.position;

        }
    }
    void MoveRight()
    {
        rectTransform.position += Vector3.right * (-speed) * Time.deltaTime;
    }
}
