using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command;

public interface IAccommodationCommand
{
    void AddAccommodation(AddAccommodationDto AccommodationDto);
    void UpdateAccommodation(UpdateAccommodationDto AccommodationDto);
    void DeleteAccommodation(DeleteAccommodationDto AccommodationDto);
}