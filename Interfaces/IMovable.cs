

namespace AustralianFall.Interfaces
{
    internal interface IMovable
    {
        float x { get; set; }
        float y { get; set; }
        void updatePosition();
    }
}
