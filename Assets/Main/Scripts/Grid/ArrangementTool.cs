using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TowerDefense.Grid.Arrangement
{
    [RequireComponent(typeof(Tilemap))]
    public class ArrangementTool : MonoBehaviour
    {
       
        private Tilemap _tilemapForUnits;
        // Start is called before the first frame update
        void Awake()
        {
            _tilemapForUnits = GetComponent<Tilemap>();
        }

        private void OnMouseDown()
        {
            // get mouse click's position in 2d plane
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           

            // convert mouse click's position to Grid position
            GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();            
            Vector3Int cellPosition = gridLayout.WorldToCell(mousePosition);

            Debug.Log(cellPosition);
        }
    }
}
