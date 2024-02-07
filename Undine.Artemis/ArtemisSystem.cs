using Artemis;
using Artemis.System;
using Undine.Core;

namespace Undine.Artemis
{
    public class ArtemisSystem<A>
        : EntityComponentProcessingSystem<ArtemisComponentWrapper<A>>, ISystem
        where A : struct
    {
        public ArtemisSystem()
            : base(Aspect.All(typeof(ArtemisComponentWrapper<A>)))
        {
        }

        public UnifiedSystem<A> System { get; set; }

        public override void Process(Entity entity, ArtemisComponentWrapper<A> component1)
        {
            System.ProcessSingleEntity(entity.Id, ref component1.Value);
        }

        public void ProcessAll()
        {
            Process();
        }
    }

    public class ArtemisSystem<A, B>
        : EntityComponentProcessingSystem<ArtemisComponentWrapper<A>, ArtemisComponentWrapper<B>>, ISystem
        where A : struct
        where B : struct
    {
        public ArtemisSystem()
            : base(Aspect.All(typeof(ArtemisComponentWrapper<A>), typeof(ArtemisComponentWrapper<B>)))
        {
        }

        public UnifiedSystem<A, B> System { get; set; }

        public override void Process(Entity entity, ArtemisComponentWrapper<A> component1, ArtemisComponentWrapper<B> component2)
        {
            System.ProcessSingleEntity(entity.Id, ref component1.Value, ref component2.Value);
        }

        public void ProcessAll()
        {
            Process();
        }
    }

    public class ArtemisSystem<A, B, C>
        : EntityComponentProcessingSystem<ArtemisComponentWrapper<A>, ArtemisComponentWrapper<B>, ArtemisComponentWrapper<C>>, ISystem
        where A : struct
        where B : struct
        where C : struct
    {
        public ArtemisSystem()
            : base(Aspect.All(typeof(ArtemisComponentWrapper<A>), typeof(ArtemisComponentWrapper<B>), typeof(ArtemisComponentWrapper<C>)))
        {
        }

        public UnifiedSystem<A, B, C> System { get; set; }

        public override void Process(
            Entity entity,
            ArtemisComponentWrapper<A> component1,
            ArtemisComponentWrapper<B> component2,
            ArtemisComponentWrapper<C> component3)
        {
            System.ProcessSingleEntity(entity.Id, ref component1.Value, ref component2.Value, ref component3.Value);
        }

        public void ProcessAll()
        {
            Process();
        }
    }

    public class ArtemisSystem<A, B, C, D>
        : EntityComponentProcessingSystem<ArtemisComponentWrapper<A>, ArtemisComponentWrapper<B>, ArtemisComponentWrapper<C>, ArtemisComponentWrapper<D>>, ISystem
        where A : struct
        where B : struct
        where C : struct
        where D : struct
    {
        public ArtemisSystem()
            : base(Aspect.All(
                typeof(ArtemisComponentWrapper<A>),
                typeof(ArtemisComponentWrapper<B>),
                typeof(ArtemisComponentWrapper<C>),
                typeof(ArtemisComponentWrapper<D>)))
        {
        }

        public UnifiedSystem<A, B, C, D> System { get; set; }

        public override void Process(
            Entity entity,
            ArtemisComponentWrapper<A> component1,
            ArtemisComponentWrapper<B> component2,
            ArtemisComponentWrapper<C> component3,
            ArtemisComponentWrapper<D> component4)
        {
            System.ProcessSingleEntity(entity.Id, ref component1.Value, ref component2.Value, ref component3.Value, ref component4.Value);
        }

        public void ProcessAll()
        {
            Process();
        }
    }
}