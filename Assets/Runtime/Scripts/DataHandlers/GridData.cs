using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Musopia
{
    public class GridData : MonoBehaviour
    {
        private List<ColumnData> _columns = new List<ColumnData>();

        public List<ColumnData> Columns => _columns;

        private void Awake()
        {
            var data = GetComponentsInChildren<ColumnData>(true);
            foreach(var item in data)
            {
                _columns.Add(item);
            }
        }
    }
}
