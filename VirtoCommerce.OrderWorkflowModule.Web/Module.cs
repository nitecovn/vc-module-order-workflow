using Microsoft.Practices.Unity;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.OrderModule.Data.Services;
using VirtoCommerce.OrderWorkflowModule.Core.Models;
using VirtoCommerce.OrderWorkflowModule.Data.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;

namespace VirtoCommerce.OrderWorkflowModule.Web
{
    public class Module : ModuleBase
    {
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void Initialize()
        {
            base.Initialize();
            _container.RegisterType<ICustomerOrderBuilder, CustomerOrderWorkflowBuilderImpl>();

        }
        public override void PostInitialize()
        {
            base.PostInitialize();
            AbstractTypeFactory<IOperation>.OverrideType<CustomerOrder, CustomerOrderWorkflow>();
            AbstractTypeFactory<CustomerOrder>.OverrideType<CustomerOrder, CustomerOrderWorkflow>()
                .WithFactory(() => new CustomerOrderWorkflow { OperationType = "CustomerOrder" });
        }
    }
}