using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.IRepository;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IHostRepository _hostRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AccommodationCommand(IAccommodationRepository accommodationRepository, IHostRepository hostRepository, IUnitOfWork unitOfWork)
    {
        _accommodationRepository = accommodationRepository;
        _hostRepository = hostRepository;
        _unitOfWork = unitOfWork;
    }

    void IAccommodationCommand.AddAccommodation(AddAccommodationDto accommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();
            var host = _hostRepository.GetHost(accommodationDto.HostId);
            var accommodation = Accommodation.Create(host);
            _accommodationRepository.AddAccommodation(accommodation);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto accommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var accommodation = _accommodationRepository.GetAccommodation(accommodationDto.Id);
            if (accommodation == null)
            {
                throw new KeyNotFoundException($"Accommodation: {accommodationDto.Id} not found");
            }
            accommodation.Update();

            _accommodationRepository.UpdateAccommodation(accommodation, accommodationDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto AccommodationDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            var accommodation = _accommodationRepository.GetAccommodation(AccommodationDto.Id);
            if (accommodation == null)
            {
                throw new KeyNotFoundException($"Accommodation: {AccommodationDto.Id} not found");
            }
            _accommodationRepository.DeleteAccommodation(accommodation, AccommodationDto.RowVersion);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            Accommodation accommodation = _accommodationRepository.GetAccommodation(bookingDto.AccommodationId);
            accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);
            _accommodationRepository.CreateBooking(bookingDto.StartDate, bookingDto.EndDate);
            _unitOfWork.Commit();
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}