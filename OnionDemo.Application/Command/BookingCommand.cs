﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command
{
    public class BookingCommand : IBookingCommand
    {
        //private readonly IBookingDomainService _domainService;
        private readonly IBookingRepository _repository;
        private readonly IUnitOfWork _uow;

        public BookingCommand(IUnitOfWork uow, IBookingRepository repository)
        {
            _uow = uow;
            _repository = repository;
            //_domainService = domainService;
        }

        void IBookingCommand.CreateBooking(CreateBookingDto bookingDto)
        {
            try
            {
                _uow.BeginTransaction();

                var existingBookings = _repository.GetBookings();

                // Do
                var booking = Booking.Create(bookingDto.StartDate, bookingDto.EndDate, existingBookings);

                // Save
                _repository.AddBooking(booking);

                _uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _uow.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", e);
                }

                throw;
            }
        }

        void IBookingCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            try
            {
                _uow.BeginTransaction();

                var existingBookings = _repository.GetBookings();
                // Load
                var booking = _repository.GetBooking(updateBookingDto.Id);

                // Do
                booking.Update(updateBookingDto.StartDate, updateBookingDto.EndDate, existingBookings);

                // Save
                _repository.UpdateBooking(booking, updateBookingDto.RowVersion);
                _uow.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _uow.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}", e);
                }

                throw;
            }
        }
        void IBookingCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            try
            {
                _uow.BeginTransaction();
                var booking = _repository.GetBooking(deleteBookingDto.Id);
                if (booking == null)
                {
                    throw new Exception("Booking not found.");
                }
                _repository.DeleteBooking(booking, deleteBookingDto.RowVersion);
                _uow.Commit();

            }
            catch (Exception e)
            {
                throw new Exception($"Rollback failed: {e.Message}");
            }
        }
    }
}
