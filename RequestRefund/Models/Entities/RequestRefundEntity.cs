using RequestRefund.Models.Bases;

namespace RequestRefund.Models.Entities
{
    public class RequestRefundEntity: RequestRefundBase
    {
        public Guid Id { get; set; }

		private DateTime? _createAt;
		public DateTime? CreateAt
		{
			get { return _createAt; }
			set { _createAt = DateTime.UtcNow; }
		}

        public DateTime? UpdateAt { get; set; }
    }
}
