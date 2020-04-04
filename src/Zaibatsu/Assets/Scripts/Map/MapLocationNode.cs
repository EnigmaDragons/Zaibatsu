using TMPro;
using UnityEngine;

public sealed class MapLocationNode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private TextMeshProUGUI descriptionLabel;

    public void Init(Location l)
    {
        nameLabel.text = l.DisplayName;
        descriptionLabel.text = l.Description;
    }
}
