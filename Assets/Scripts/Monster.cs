using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public string monsterName;
    public int health;
    public List<ItemInfo> dropItems; // 드롭 아이템 목록    

    public List<float> dropRates;
    
    // 아이템별 드롭 확률 조정자 (예시)


    public float CalcDrop(ItemInfo item)
    {
        int index = dropItems.IndexOf(item);
        return index >= 0 ? dropRates[index] : 1.0f;
    }

    private void Update()
    {  
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(100);
        }
    }
    public void DropLoot()
    {
        ItemManager.Instance.MonsterKill(this);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log($"{monsterName} 처치됨");
            DropLoot();
            Destroy(gameObject);
        }
    }
}
