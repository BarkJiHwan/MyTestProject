using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<ItemInfo> dropItems; // 드롭 아이템 목록 (유니티 에디터에서 설정)
    public List<float> dropRates; // 아이템별 드롭 확률 (유니티 에디터에서 설정)


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SpawnMonster();
        }
    }

    // 몬스터 생성 메서드
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

