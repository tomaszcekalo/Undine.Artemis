using Artemis.Interface;

namespace Undine.Artemis
{
    public class ArtemisComponentWrapper<T> : IComponent
        where T : struct
    {
        public T Value;
    }
}