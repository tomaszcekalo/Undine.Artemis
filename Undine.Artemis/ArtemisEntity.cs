using Artemis;
using System;
using Undine.Core;

namespace Undine.Artemis
{
    public class ArtemisEntity : IUnifiedEntity
    {
        public Entity Entity { get; set; }

        public void AddComponent<A>(in A component) where A : struct
        {
            Entity.AddComponent(new ArtemisComponentWrapper<A>() { Value = component });
        }

        public ref A GetComponent<A>() where A : struct
        {
            return ref Entity.GetComponent<ArtemisComponentWrapper<A>>().Value;
        }

        public void DeleteComponent<A>() where A : struct
        {
            Entity.RemoveComponent<ArtemisComponentWrapper<A>>();
        }

        public void RemoveComponent<A>() where A : struct
        {
            Entity.RemoveComponent<ArtemisComponentWrapper<A>>();
        }

        public bool HasComponent<A>() where A : struct
        {
            return Entity.HasComponent<ArtemisComponentWrapper<A>>();
        }
    }
}