using RequestRefund.Models.Enuns;

namespace RequestRefund.Models.Bases
{
    public class RequestRefundBase
    {
        public Guid EmployeeId { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; } = string.Empty;
        public CategoryEnum Category { get; set; }
    }
}
