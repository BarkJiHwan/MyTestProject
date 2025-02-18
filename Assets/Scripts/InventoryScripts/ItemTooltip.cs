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
        RequiredBuilder.Length = 0;
        //�������� ���� ������ ���� �޼ҵ带 �������̵带 ���� ���� ������
        itemTypeText.text = itemInfo.itemType.ToString();
        itemGradeText.text = itemInfo.itemGrade.ToString();
        itemNameText.text = itemInfo.name;
        itemDescriptionText.text = "������ ����\n" + itemInfo.itemDescription;
        Price.text = itemInfo.price.ToString();

        itemInfo.ItemRequired(RequiredBuilder);
        itemInfo.ShowMyInfo(stateBuilder);
        
        itemImage.sprite = itemInfo.itemSprite;                
        RequiredText.text = RequiredBuilder.ToString();
        if (itemInfo is EquipItem equipItem || itemInfo is Armor armor || itemInfo is ConsumItem consumItem)
        {
            equipItemText.text = stateBuilder.ToString();
        }        

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