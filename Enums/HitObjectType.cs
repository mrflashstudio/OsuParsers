namespace OsuBeatmapParser.Enums
{
    enum HitObjectType
    {
        Circle = 1 << 0,
        Slider = 1 << 1,
        NewCombo = 1 << 2,
        Spinner = 1 << 3,
        ColourHax = 112, //TODO: combo offset
        Hold = 1 << 7
    }
}
