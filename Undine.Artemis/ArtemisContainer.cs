using Artemis;
using Artemis.Manager;
using Undine.Core;

namespace Undine.Artemis
{
    public class ArtemisContainer : EcsContainer
    {
        private EntityWorld entityWorld;

        public ArtemisContainer()
        {
            this.entityWorld = new EntityWorld();
            //this.entityWorld.InitializeAll(true);
        }

        public override void AddSystem<A>(UnifiedSystem<A> system)
        {
            var systemToAdd = new ArtemisSystem<A>()
            {
                System = system,
            };
            entityWorld.SystemManager.SetSystem(systemToAdd, GameLoopType.Update);
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            var systemToAdd = new ArtemisSystem<A, B>()
            {
                System = system,
            };
            entityWorld.SystemManager.SetSystem(systemToAdd, GameLoopType.Update);
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            var systemToAdd = new ArtemisSystem<A, B, C>()
            {
                System = system,
            };
            entityWorld.SystemManager.SetSystem(systemToAdd, GameLoopType.Update);
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            var systemToAdd = new ArtemisSystem<A, B, C, D>()
            {
                System = system,
            };
            entityWorld.SystemManager.SetSystem(systemToAdd, GameLoopType.Update);
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            return new ArtemisEntity()
            {
                Entity = entityWorld.CreateEntity()
            };
        }

        public override void DeleteEntity(IUnifiedEntity entity)
        {
            var entityToDelete = entity as ArtemisEntity;
            if(entityToDelete is not null)
            {
                entityWorld.DeleteEntity(entityToDelete.Entity); 
            }
        }

        public override ISystem GetSystem<A>(UnifiedSystem<A> system)
        {
            var systemToAdd = new ArtemisSystem<A>()
            {
                System = system
            };
            entityWorld.SystemManager.SetSystem(systemToAdd, GameLoopType.Draw);
            return systemToAdd;
        }

        public override ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            return new ArtemisSystem<A, B>()
            {
                System = system
            };
        }

        public override ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            return new ArtemisSystem<A, B, C>()
            {
                System = system
            };
        }

        public override ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            return new ArtemisSystem<A, B, C, D>()
            {
                System = system
            };
        }

        public override void Init()
        {
            base.Init();
            entityWorld.InitializeAll();
            entityWorld.PoolCleanupDelay = 0;
        }

        public override void Run()
        {
            entityWorld.Update();
        }
    }
}