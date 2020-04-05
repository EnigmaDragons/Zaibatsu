
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speechLabel;
    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private Button dismiss;

    private void Awake() => dismiss.onClick.AddListener(Dismiss);
    
    public void Set(string characterName, string speech)
    {
        speechLabel.text = speech;
        nameLabel.text = characterName;
    }

    public void Dismiss()
    {
        gameObject.SetActive(false);
        Message.Publish(new SequenceStepFinished());
    }
}
