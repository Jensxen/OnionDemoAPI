//using Microsoft.EntityFrameworkCore;
//using OnionDemo.Application.Query;
//using OnionDemo.Application.Query.QueryDto;

//namespace OnionDemo.Infrastructure.Queries;

//public class AccommodationQuery : IAccommodationQuery
//{
//    private readonly BookMyHomeContext _db;

//    public AccommodationQuery(BookMyHomeContext context)
//    {
//        _db = context;
//    }

//    AccommodationDto IAccommodationQuery.GetAccommodation(int id)
//    {
//        return _db.Accommodations
//            .Where(a => a.Id == id)
//            .Select(a => new AccommodationDto
//            {
//                Id = a.Id,
//                RowVersion = a.RowVersion
//            })
//            .Single();
//    }

//    public IEnumerable<AccommodationDto> GetAccommodation()
//    {
//        var result = _db.Accommodations.AsNoTracking().Select(a => new AccommodationDto
//        {
//            Id = a.Id,
//            RowVersion = a.RowVersion,
//        });
//        return result;
//    }

//    public IEnumerable<AccommodationDto> GetAccommodations(int hostId)
//    {
//        var result = _db.Accommodations
//            .Where(a => a.Host.Id == hostId)
//            .Select(a => new AccommodationDto
//            {
//                Id = a.Id,
//                RowVersion = a.RowVersion
//            });
//        return result;
//    }
//}