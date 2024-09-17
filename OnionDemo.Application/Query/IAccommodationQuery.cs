using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnionDemo.Application.Query;


public interface IAccommodationQuery
{
    AccommodationDto GetAccommodation(int id);
    IEnumerable<AccommodationDto> GetAccommodation();
    IEnumerable<AccommodationDto> GetAccommodations(int hostId);
}