using System.Collections;
using System.Collections.Generic;
using TowerDefense.Grid.Arrangement;
using UnityEngine;

namespace TowerDefense.UI
{
    //Временный класс
    public class PanelSelectorAnimator : MonoBehaviour
    {
        [SerializeField]
        ArrangementTool _arrangementTool;

        private void Awake()
        {
            _arrangementTool.TileHasBeenSelected += OnTileSelected;
        }
        private void Start()
        {
            Disappear();
        }
        public void OnTileSelected()
        {            
            Appear();
        }
        private void Appear()
        {
            gameObject.SetActive(true);
        }
        public void Disappear()
        {
            gameObject.SetActive(false);
        }
    }
}
