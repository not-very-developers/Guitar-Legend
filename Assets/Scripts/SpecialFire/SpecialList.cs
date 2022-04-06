using System.Collections.Generic;
using UnityEngine;

public class SpecialList : MonoBehaviour
{
    private Dictionary<string, GameObject> _specialFires;
    [SerializeField] private GameObject testFire;

    public void Start()
    {
        _specialFires = new Dictionary<string, GameObject>(new Dictionary<string, GameObject>
            {{"wasd", testFire}});
    }

    public bool TryGet(string kod, out GameObject fire) => _specialFires.TryGetValue(kod, out fire);
}