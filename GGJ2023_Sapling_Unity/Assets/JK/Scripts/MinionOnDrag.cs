using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinionOnDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector2 startLocation;
    Vector2 mouseOffset;
    public MinionIndex minionIndex;
    public Text waterCostText;
    public Text poopCostText;

    private void Start()
    {
        waterCostText.text = GameManager.GetMinionWaterCost(minionIndex).ToString();
        poopCostText.text = GameManager.GetMinionPoopCost(minionIndex).ToString();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // if not over ui
        if (GameManager.CanSpawnMinion(minionIndex))
        {
            transform.position = Input.mousePosition + (Vector3)mouseOffset;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.CanSpawnMinion(minionIndex))
        {
            //Debug.Log("begin drag");
            mouseOffset = transform.position - Input.mousePosition;
            //Debug.Log(mouseOffset);
            startLocation = transform.position;
        }
            
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.CanSpawnMinion(minionIndex))
        {
            //Debug.Log("end drag");
            transform.position = startLocation;
            Vector3 spawnLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(spawnLocation);
            GameManager.UseMinionCost(minionIndex);
            GameManager.GetMinionSpawner().spawnMinion(minionIndex, spawnLocation);
        }
            
    }
}
