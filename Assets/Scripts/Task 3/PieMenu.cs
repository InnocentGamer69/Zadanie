using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PieMenu : MonoBehaviour
{
    [SerializeField] private List<Button> pieMenuBttons;
    
    public Vector3 LastMousePosition;

    private Vector3 mousePosition;

    void Update()
    {
        mousePosition = Input.mousePosition;
        if (LastMousePosition.x > mousePosition.x)
        {
            if(LastMousePosition.y < mousePosition.y)
            {
                highlight(0);
                stopHighlight(0);
            }
            if(LastMousePosition.y > mousePosition.y)
            {
                highlight(2);
                stopHighlight(2);
            }
        }
        if (LastMousePosition.x < mousePosition.x)
        {
            if (LastMousePosition.y < mousePosition.y)
            {
                highlight(1);
                stopHighlight(1);
            }
            if (LastMousePosition.y > mousePosition.y)
            {
                highlight(3);
                stopHighlight(3);
            }
        }

    }
    private void highlight(int button)
    {
        pieMenuBttons[button].image.color = pieMenuBttons[button].colors.highlightedColor;
    }
    private void stopHighlight(int button)
    {
        for (int i = 0; i < pieMenuBttons.Count; i++)
        {
            if (i != button)
            {
                pieMenuBttons[i].image.color = pieMenuBttons[i].colors.normalColor;
            }
        }
    }
    
    public void UnselectAll()
    {
        for (int i = 0; i < pieMenuBttons.Count; i++)
        {
            pieMenuBttons[i].image.color = pieMenuBttons[i].colors.normalColor;
        }
    }
}
