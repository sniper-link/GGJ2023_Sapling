using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinionOnDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector2 startLocation;
    Vector2 mouseOffset;
    public MinionIndex minionIndex;

    public void OnDrag(PointerEventData eventData)
    {
        // if not over ui

        
        transform.position = Input.mousePosition + (Vector3)mouseOffset;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        mouseOffset = transform.position - Input.mousePosition;
        Debug.Log(mouseOffset);
        startLocation = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.position = startLocation;
        Vector3 spawnLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(spawnLocation);
        GameManager.GetMinionSpawner().spawnMinion(minionIndex, spawnLocation);
    }
}
