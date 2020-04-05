using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThoughtView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button dismiss;

    private void Awake() => dismiss.onClick.AddListener(Dismiss);
    
    public void Set(string txt)
    {
        text.text = txt;
    }

    public void Dismiss()
    {
        gameObject.SetActive(false);
        Message.Publish(new SequenceStepFinished());
    }
}
