using System.Collections.Generic;
using UnityEngine;

namespace GuitarLegeng.Special
{
    public class SpecialList : MonoBehaviour
    {
        private Dictionary<string, GameObject> _specialFires;
        [SerializeField] private GameObject testFire;
    
        private void Start()
        {
            _specialFires = new Dictionary<string, GameObject>(new Dictionary<string, GameObject>
                {{"wasd", testFire}});
        }
    
        internal bool TryGet(string kod, out GameObject fire) => _specialFires.TryGetValue(kod, out fire);
    }
}
