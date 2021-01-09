using System;
using System.Collections;
using System.Collections.Generic;
using TowerDefense.GamePool;
using TowerDefense.ScriptableObjects.Towers;
using TowerDefense.Units.Tower;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace TowerDefense.Grid.Arrangement
{
    [RequireComponent(typeof(Tilemap))]
    public class ArrangementTool : MonoBehaviour
    {
        public Action TileHasBeenSelected;        
        private Tilemap _tilemapForUnits;
        private Camera _camera;

        private Vector3 _newTowerPosition;
        // Start is called before the first frame update
        void Awake()
        {
            _tilemapForUnits = GetComponent<Tilemap>();
            _camera = Camera.main;
        }
        public void CreateTower(TowerInfo info)
        {
            Tower newTower = PoolFacade.Instance.Take<Tower>();
            newTower.Info = info;
            newTower.transform.position = _newTowerPosition;
        }
        private void OnMouseDown()
        {            
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);            
            GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();            
            Vector3Int cellPosition = gridLayout.WorldToCell(mousePosition);
            _newTowerPosition = cellPosition + _tilemapForUnits.tileAnchor;
           
            TileHasBeenSelected?.Invoke();
        }
    }
}
