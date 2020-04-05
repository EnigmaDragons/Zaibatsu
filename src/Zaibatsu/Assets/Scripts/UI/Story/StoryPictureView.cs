using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryPictureView : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button dismiss;

    private void Awake() => dismiss.onClick.AddListener(Dismiss);
    
    public void Set(Sprite img, string txt)
    {
        image.sprite = img;
        text.text = txt;
    }

    public void Dismiss()
    {
        gameObject.SetActive(false);
        Message.Publish(new SequenceStepFinished());
    }
}
