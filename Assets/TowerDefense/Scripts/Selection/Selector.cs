using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    public GameObject[] towers;

    //Keep track of towers we spawn
    private GameObject[] holograms;
    //Current prefab selected
    private int currentIndex = 0;

    void DrawRay(Ray ray)
    {
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 1000f);
    }
    
    
    void onDrawGizmos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray playerRay = new Ray(transform.position, transform.forward);

        Gizmos.color = Color.white;
        DrawRay(mouseRay);
        Gizmos.color = Color.red;
        DrawRay(playerRay);
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Perform Raycast
        if(Physics.Raycast(mouseRay, out hit))
        {
            //Try getting a placeable script
            Placeable p = hit.transform.GetComponent < Placeable>();
            if (p)
            {
                print(p);
            }
        }
    }

    /// 
       public void SelectTower(int index)
    {
        //Is index in range of prefabs
        if (index >= 0 && index < towers.Length)
        {
            // Set current index
            currentIndex = index;
        }
    }
}
