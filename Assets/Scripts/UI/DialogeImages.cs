using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogImages : MonoBehaviour
{
    [SerializeField] private List<Sprite> partnersImages;
    [SerializeField] private Image partner;

    public void OpenClosePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
    public void ChangeImagePartner(int id)
    {
        partner.sprite = partnersImages[id];
    }
}
