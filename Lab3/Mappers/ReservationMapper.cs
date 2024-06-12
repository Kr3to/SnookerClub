using Data.Entities;
using Laboratorium3_App.Models;

namespace Laboratorium3_App.Mappers
{
    public class ReservationMapper
    {
        public static Reservation FromEntity(ReservationEntity entity)
        {
            return new Reservation()
            {
                Id = entity.Id,
                CustomerName = entity.CustomerName,
                PlayTimeHours = entity.PlayTimeHours,
                ReservationDate = (DateTime)entity.ReservationDate
            };
        }

        public static ReservationEntity ToEntity(Reservation model)
        {
            return new ReservationEntity()
            {
                Id = model.Id,
                CustomerName = model.CustomerName,
                PlayTimeHours = model.PlayTimeHours,
                ReservationDate = model.ReservationDate
            };
        }
    }
}
