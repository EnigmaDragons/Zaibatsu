using TMPro;
using UnityEngine;

public sealed class MapLocationNode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;

    public void Init(Location l)
    {
        nameLabel.text = l.DisplayName;
    }
}
