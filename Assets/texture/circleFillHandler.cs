using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFillHandler : MonoBehaviour
{
    [Range(0, 100)]
    public float maxFillValue = 100;
    public float fillValue = 0;
    public Image circleFillImage;
    public RectTransform handlerEdgeImage;
    public RectTransform fillHandler;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // 檢查右鍵按下
        {
            fillValue += Time.deltaTime * maxFillValue; // 每秒填充 maxFillValue 的量
            fillValue = Mathf.Clamp(fillValue, 0, maxFillValue); // 確保填充值在合理範圍內
        }
        if (Input.GetMouseButtonUp(1))
        {
            fillValue = 0;
        }
        FillCircleValue(fillValue);
    }

    void FillCircleValue(float value)
    {
        float fillAmount = (value / maxFillValue);
        circleFillImage.fillAmount = fillAmount;
        float angle = fillAmount * 360;
        fillHandler.localEulerAngles = new Vector3(0, 0, -angle);
        handlerEdgeImage.localEulerAngles = new Vector3(0, 0, angle);
    }
}