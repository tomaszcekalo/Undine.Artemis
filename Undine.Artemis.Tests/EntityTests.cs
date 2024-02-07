using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Undine.Artemis.Tests.Components;
using Undine.Core;

namespace Undine.Artemis.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void ComponentCanBeAdded()
        {
            var container = new ArtemisContainer();
            var mock = Substitute.For<UnifiedSystem<AComponent>>();
            container.AddSystem(mock);
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
        }

        [TestMethod]
        public void ComponentCanBeRetrieved()
        {
            var container = new ArtemisContainer();
            var mock = Substitute.For<UnifiedSystem<AComponent>>();
            container.AddSystem(mock);
            container.Init();
            var entity = (ArtemisEntity)container.CreateNewEntity();
            entity.AddComponent(new AComponent());

            ref var component = ref entity.GetComponent<AComponent>();
            Assert.IsNotNull(component);
        }
        [TestMethod]
        public void ComponentCanBeRemoved()
        {
            var container = new ArtemisContainer();
            var mock = Substitute.For<UnifiedSystem<AComponent>>();
            container.AddSystem(mock);
            container.Init();
            var entity = (ArtemisEntity)container.CreateNewEntity();
            entity.AddComponent(new AComponent());

            ref var component = ref entity.GetComponent<AComponent>();
            entity.RemoveComponent<AComponent>();
            container.Run();
            Assert.IsFalse(entity.HasComponent<AComponent>());
        }
    }
}
