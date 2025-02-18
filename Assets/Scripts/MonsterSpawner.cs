using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<ItemInfo> dropItems; // ��� ������ ��� (����Ƽ �����Ϳ��� ����)
    public List<float> dropRates; // �����ۺ� ��� Ȯ�� (����Ƽ �����Ϳ��� ����)


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SpawnMonster();
        }
    }

    // ���� ���� �޼���
    public void SpawnMonster()
    {
        GameObject monsterObject = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        Monster monster = monsterObject.GetComponent<Monster>();

        if (monster != null)
        {
            monster.monsterName = "ExampleMonster";
            monster.health = 100;
            monster.dropItems = dropItems;
            monster.dropRates = dropRates;
        }
    }
}

