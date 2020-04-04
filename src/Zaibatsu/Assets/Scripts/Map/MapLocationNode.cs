using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class MapLocationNode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private TextMeshProUGUI descriptionLabel;
    [SerializeField] private Button button;

    private CurrentGameMap _map;
    private Location _location;
    
    public void Init(CurrentGameMap map, Location l)
    {
        _map = map;
        _location = l;
        nameLabel.text = l.DisplayName;
        descriptionLabel.text = l.Description;
    }
    
    private void Awake()
    {
        button.onClick.AddListener(TravelToLocation);
    }

    private void TravelToLocation()
    {
        if (_map.CanTravelTo(_location))
            Message.Publish(new BeganTravellingToLocation(_map.CurrentLocation, _location));
    }
}
