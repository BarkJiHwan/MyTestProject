using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{
    public string monsterName;
    public int health;
    public List<ItemInfo> dropItems; // ��� ������ ���    

    public List<float> dropRates;
    
    // �����ۺ� ��� Ȯ�� ������ (����)


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
            Debug.Log($"{monsterName} óġ��");
            DropLoot();
            Destroy(gameObject);
        }
    }
}
