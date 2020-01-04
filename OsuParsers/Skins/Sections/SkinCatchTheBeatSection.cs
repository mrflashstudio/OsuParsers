using System.Drawing;

namespace OsuParsers.Skins.Sections
{
    public class SkinCatchTheBeatSection
    {
        public Color HyperDash { get; set; } = Color.Red;

        private Color? hyperDashFruit = null;
        public Color HyperDashFruit
        {
            get => hyperDashFruit ?? HyperDash;
            set => hyperDashFruit = value;
        }

        private Color? hyperDashAfterImage = null;
        public Color HyperDashAfterImage
        {
            get => hyperDashAfterImage ?? HyperDash;
            set => hyperDashAfterImage = value;
        }
    }
}
