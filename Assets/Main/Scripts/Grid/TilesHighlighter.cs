#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TowerDefense.Grid.HighLight
{

    [ExecuteInEditMode]
    [RequireComponent(typeof(Tilemap))]
    public class TilesHighlighter : MonoBehaviour
    {
        [SerializeField]
        private bool _isHighLighted;

        [SerializeField]
        private Color _gizmoColor;

        [SerializeField]
        private int _sizeOfCell = 1;

        [SerializeField]
        private float _offsetX = 0f;

        [SerializeField]
        private float _offsetY = 0f;

        private Tilemap _tilemap;
        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        private void OnDrawGizmosSelected()
        {
            if (_isHighLighted)
            {
                Gizmos.color = _gizmoColor;
                var bounds = _tilemap.cellBounds;
                TileBase[] allTiles = _tilemap.GetTilesBlock(bounds);
                foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
                {
                    Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
                    Vector3 place = _tilemap.CellToWorld(localPlace);
                    if (_tilemap.HasTile(localPlace))
                    {
                        Vector3 rectPos = new Vector3(pos.x + 0.5f + transform.localPosition.x + _offsetX, pos.y + 0.5f + transform.localPosition.y + _offsetY, 0);
                        Vector3 size = new Vector3(_sizeOfCell, _sizeOfCell, _sizeOfCell);
                        Gizmos.DrawCube(rectPos, size);
                    }
                }

            }

        }
    }
}
#endif