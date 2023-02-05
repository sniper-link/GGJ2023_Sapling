using System.Collections;
using System.Collections.Generic;
using UnityEngine;

     public void OnDrag(PointerEventData eventData)
     {
         if (!beingPlaced) return;
 
         if (beingPlaced == true)
         {
             var pos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0f));
             t$$anonymous$$s.transform.position = new Vector3(pos.x, pos.y, 0);
         }
     }
 
     public void OnEndDrag(PointerEventData eventData)
     {
         if (!beingPlaced) return;
 
         if (cannotPlaceTower == false || collisionCount == 0)
         {
             gameController.placingTower = false;
             uiController.cancelTowerButton.SetActive(false);
             gameController.gameMusic.PlayOneShot(gameController.towerPlace, 1f);
             beingPlaced = false; //place tower
             towerRange.$$anonymous$$deRangeCircle();
             gameController.addEnergy(-towerCost);            
         }
     }
 
     public void OnPointerDown(PointerEventData eventData)
     {
         if (beingPlaced == false)
         {
             if (gameController.placingTower)
                 gameController.stopTowerBeingPlaced();
             calculateDPS();
             uiController.towerPanel.GetComponent<TowerPanelController>().showTowerPanel(t$$anonymous$$s);
         }
     }
