using System;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Order.Model;
using VirtoCommerce.Domain.Order.Services;
using VirtoCommerce.OrderModule.Data.Services;
using VirtoCommerce.OrderWorkflowModule.Core.Models;

namespace VirtoCommerce.OrderWorkflowModule.Data.Services
{
    /// <summary>
    /// <see cref="CustomerOrderBuilderImpl"/>
    /// </summary>
    public class CustomerOrderWorkflowBuilderImpl : CustomerOrderBuilderImpl
    {
        public CustomerOrderWorkflowBuilderImpl(ICustomerOrderService customerOrderService) : base(customerOrderService)
        {
        }

        protected override CustomerOrder ConvertCartToOrder(ShoppingCart cart)
        {
            var result = base.ConvertCartToOrder(cart);
            var retVal = result as CustomerOrderWorkflow;

            if (retVal != null)
            {
                // [TODO] workflow's status and workflow's id will be implemented VT-1
                retVal.WorkflowId = Guid.NewGuid().ToString();
                retVal.WorkflowStatus = "Waiting for Approval";
            }

            return retVal;
        }
    }
}