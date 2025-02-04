using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Task3 : MonoBehaviour
{
    [SerializeField] private GameObject pieMenu;
    [SerializeField] Texture2D cursor;
    
    private Vector3 mousePosition;

    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mouseX = mousePosition.x;
        mouseY = mousePosition.y;

        if (Input.GetMouseButtonDown(1) && !pieMenu.activeInHierarchy)   
        {
            pieMenu.transform.position = new Vector3(mouseX, mouseY);
            pieMenu.GetComponent<PieMenu>().LastMousePosition = mousePosition;
            pieMenu.SetActive(true);
            Cursor.visible = false;
        }
        else if(Input.GetMouseButtonDown(1) && pieMenu.activeInHierarchy)
        {
            pieMenu.GetComponent<PieMenu>().UnselectAll();
            pieMenu.SetActive(false);
            Cursor.visible = true;
        }

    }
}
