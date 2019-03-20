using VirtoCommerce.Domain.Order.Model;

namespace VirtoCommerce.OrderWorkflowModule.Core.Models
{
    /// <summary>
    /// Customer Order Workflow
    /// <see cref="CustomerOrder"/>
    /// </summary>
    public class CustomerOrderWorkflow : CustomerOrder
    {
        public string WorkflowId { get; set; }
        public string WorkflowStatus { get; set; }
    }
}