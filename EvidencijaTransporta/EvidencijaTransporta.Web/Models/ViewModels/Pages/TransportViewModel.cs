using System.Collections.Generic;
using System.Linq;

namespace EvidencijaTransporta.Web.Models.ViewModels.Pages
{
	public class TransportViewModel : BaseViewModel
	{
		public TransportViewModel(IEnumerable<TransportModel> transports)
		{
			Title = "Transport Reservation";
			Transports = transports.ToList();
		}

		public IList<TransportModel> Transports { get; set; }
	}
}