
public sealed class LocationNameDisplay : LocationReactiveUiText
{
    protected override string GetValue(Location location) => location.DisplayName;
}