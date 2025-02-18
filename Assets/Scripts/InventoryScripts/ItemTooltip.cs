using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemTypeText;
    public Text itemGradeText;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Text Price;
    public Text RequiredText;
    public Text equipItemText;
    public Image itemImage;

    //����� ����
    //���ڿ� �ȿ��� + �� ��� ȣ���ϰ� �� ��� ���ο� ���ڿ� ��ü�� ����������
    //StringBuilder�� ����ϰ� �Ǹ� ���ο��� �۾��� �̷����� ������
    //�������� ���ڿ��� �о�´ٸ� +�� ����ϴ� �� ���� StringBuilder�� ����ϴ°�
    //���ɸ鿡�� ������ �ִ�.
    private StringBuilder stateBuilder;
    private StringBuilder RequiredBuilder;

    private void Start()
    {
        stateBuilder = new StringBuilder();        
        RequiredBuilder = new StringBuilder();
        gameObject.SetActive(false);
    }
    public void ShowTooltip(ItemInfo itemInfo)
    {
        stateBuilder.Length = 0;//������ ȣ��Ǳ� �� ���� 0���� �ʱ�ȭ
        //�������� ���� ������ ���� �޼ҵ带 �������̵带 ���� ���� ������
        itemInfo.ShowMyInfo(stateBuilder);
        itemInfo.ShowMyInfo(RequiredBuilder);
        itemTypeText.text = itemInfo.itemType.ToString();
        itemGradeText.text = itemInfo.itemGrade.ToString();
        itemNameText.text = itemInfo.name;
        itemDescriptionText.text = "������ ����\n" + itemInfo.itemDescription;
        Price.text = itemInfo.price.ToString();

        RequiredText.text = RequiredBuilder.ToString();
        itemImage.sprite = itemInfo.itemSprite;

        //if (itemInfo is EquipItem equipItem || itemInfo is Armor armor || itemInfo is ConsumItem consumItem)
        //{
        //    itemInfo.ShowMyInfo(stateBuilder);
        //    equipItemText.text = stateBuilder.ToString();
        //}
        equipItemText.text = stateBuilder.ToString();

        gameObject.SetActive(true);
        gameObject.GetComponent<Image>().raycastTarget = false;
        SetRaycastTargetForAllChildren(gameObject, false);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void SetRaycastTargetForAllChildren(GameObject parent, bool value)
    {
        Text[] childImages = parent.GetComponentsInChildren<Text>();

        foreach (var img in childImages)
        {
            img.raycastTarget = value;
        }
    }
    
}