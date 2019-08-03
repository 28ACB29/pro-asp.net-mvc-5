using System.Collections.Generic;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{

	public class WebController : ApiController
	{
		private ReservationRespository repo = ReservationRespository.Current;

		public IEnumerable<Reservation> GetAllReservations()
		{
			return this.repo.GetAll();
		}

		public Reservation GetReservation(int id)
		{
			return this.repo.Get(id);
		}

		[HttpPost]
		public Reservation CreateReservation(Reservation item)
		{
			return this.repo.Add(item);
		}

		[HttpPut]
		public bool UpdateReservation(Reservation item)
		{
			return this.repo.Update(item);
		}

		public void DeleteReservation(int id)
		{
			this.repo.Remove(id);
		}
	}
}
