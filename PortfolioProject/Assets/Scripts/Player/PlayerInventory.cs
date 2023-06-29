using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public List<Weapon> weapons;

    public List<Spell> spells;

    public List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
       Knife knife = gameObject.AddComponent<Knife>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
