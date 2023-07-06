using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public List<Weapon> weapons;

    public List<Spell> spells;

    public List<Item> items;

    private int _maxWeapons;

    private int _maxSpells;

    private int _maxItems;
    // Start is called before the first frame update
    void Start()
    {
        _maxWeapons = 3;
        _maxSpells = 2;
        _maxItems = 6;
       Knife knife = gameObject.AddComponent<Knife>();
       Bomb bomb = gameObject.AddComponent<Bomb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
