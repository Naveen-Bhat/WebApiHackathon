using BusBooking.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.DataAccess
{
    public class BusBookingRepo
    {
        private readonly BusDBContext dBContext;

        public BusBookingRepo()
        {
            dBContext = new BusDBContext();
        }

        public int AddBus(BusBooking.DataAccess.Entities.BusBooking bus)
        {
            dBContext.BusBookings.Add(bus);
            dBContext.SaveChanges();
            return bus.Id;
        }

        public IEnumerable<BusBooking.DataAccess.Entities.BusBooking> GetAllBus()
        {
            return dBContext.BusBookings;
        }

        public int Update( int id, BusBooking.DataAccess.Entities.BusBooking bus)
        {
            var item = dBContext.BusBookings.Where(a => a.Id == id).FirstOrDefault();
            if (item != null)
            {
                item.Number = bus.Number;
                item.Name = bus.Name;
                item.Seats = bus.Seats;
                item.IsAvailable = bus.IsAvailable;
                item.Type = bus.Type;
                return 1;
            }
            return 0;

        }

        public int BookSeat(int id, int noOfSeats)
        {
            var item = dBContext.BusBookings.Where(a => a.Id == id).FirstOrDefault();
            if (item != null)
            {
                if(noOfSeats <= item.Seats && item.IsAvailable == 1)
                {
                    item.Seats = item.Seats - noOfSeats;



                    dBContext.SaveChanges();
                    return 1;

                }
                return 0;
            }
            return 0;

        }

        public int DeleteBus(int id)
        {
            var res = dBContext.BusBookings.Where(a => a.Id == id).FirstOrDefault();

            if(res != null)
            {
                dBContext.BusBookings.Remove(res);
                dBContext.SaveChanges();
                return 1;
            }

            return 0;
        }

    }
}
