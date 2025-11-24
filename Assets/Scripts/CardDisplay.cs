using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public new Text name;
    public Text Description;
    public Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        name.text = card.name;
        Description.text = card.description;
        image.sprite = card.photo;

    }

}
