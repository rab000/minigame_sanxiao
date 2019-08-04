using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(RectTransform))]
//public class UISafeFit : MonoBehaviour
//{
//    float x_scale;
//    float y_scale;
//    private void Awake()
//    {
//        // x_scale = (Screen.width - Screen.safeArea.width) / Screen.width;
//        // y_scale = (Screen.height - Screen.safeArea.height) / Screen.height;
//
//        // var x_move_scale = Screen.safeArea.x / Screen.width;
//        // var y_move_scale = Screen.safeArea.y / Screen.height;
//
//        // var rect = transform as RectTransform;
//        // rect.sizeDelta = new Vector2(-720*x_scale, -1280*y_scale);
//        // rect.anchoredPosition += new Vector2(720 * x_move_scale, -640 * y_move_scale);
//
//        float _safeAreaWidth = Screen.safeArea.width;
//        if (Screen.width <= Screen.safeArea.width)
//        {
//            _safeAreaWidth = Screen.width;
//        }
//
//        float _safeAreaheight = Screen.safeArea.height;
//        if (Screen.height <= Screen.safeArea.height)
//        {
//            _safeAreaheight = Screen.height;
//        }
//
//
//        x_scale = (Screen.width - _safeAreaWidth) / Screen.width;
//        y_scale = (Screen.height - _safeAreaheight) / Screen.height;
//
//        var x_move_scale = Screen.safeArea.x / Screen.width;
//        var y_move_scale = Screen.safeArea.y / Screen.height;
//        var rect = transform as RectTransform;
//        rect.sizeDelta = new Vector2(-720 * x_scale, -1280 * y_scale);
//        rect.anchoredPosition += new Vector2(720 * x_move_scale, -640 * y_move_scale);
//    }
//
//
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UISafeFit : MonoBehaviour
{
    public static bool is_banner = false;
    public bool showBanner;
    float x_scale;
    float y_scale;
    private RectTransform rect;
    private float safeAreaHeight;
    private bool isShowBanner;

    private void Awake()
    {
        // x_scale = (Screen.width - Screen.safeArea.width) / Screen.width;
        // y_scale = (Screen.height - Screen.safeArea.height) / Screen.height;

        // var x_move_scale = Screen.safeArea.x / Screen.width;
        // var y_move_scale = Screen.safeArea.y / Screen.height;

        // var rect = transform as RectTransform;
        // rect.sizeDelta = new Vector2(-720*x_scale, -1280*y_scale);
        // rect.anchoredPosition += new Vector2(720 * x_move_scale, -640 * y_move_scale);

        float _safeAreaWidth = Screen.safeArea.width;
        if (Screen.width <= Screen.safeArea.width)
        {
            _safeAreaWidth = Screen.width;
        }

        float _safeAreaheight = Screen.safeArea.height;
        if (Screen.height <= Screen.safeArea.height)
        {
            _safeAreaheight = Screen.height;
        }

        x_scale = (Screen.width - _safeAreaWidth) / Screen.width;
        y_scale = (Screen.height - _safeAreaheight) / Screen.height;

        safeAreaHeight = (Screen.height - _safeAreaheight) / 2 - Screen.safeArea.y;

        var x_move_scale = Screen.safeArea.x / Screen.width;
        var y_move_scale = Screen.safeArea.y / Screen.height;
        //Debug.Log("x_move_scale========" + x_move_scale);
        //Debug.Log("y_move_scale========" + y_move_scale);
        //Debug.Log("Screen.safeArea.x========" + Screen.safeArea.x);
        //Debug.Log("Screen.safeArea.y========" + Screen.safeArea.y);
        rect = transform as RectTransform;
        rect.sizeDelta = new Vector2(-720 * x_scale, -1280 * y_scale * 0.6f);
        rect.anchoredPosition += new Vector2(720 * x_move_scale, -640 * y_move_scale * 0.6f);

    }

    private void OnDestroy()
        {
        }
    }