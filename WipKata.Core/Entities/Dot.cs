using WipKata.Core.Types;

namespace WipKata.Core.Entities
{
    public class Dot
    {
        public Dot(HandlerType type)
        {
            Type = type;
        }

        public HandlerType Type { get; }

        public bool HasSticker { get; set; }
    }
}