
public sealed class CurrentLocationChanged
{
    public Location Location { get; }

    public CurrentLocationChanged(Location location)
    {
        Location = location;
    }
}