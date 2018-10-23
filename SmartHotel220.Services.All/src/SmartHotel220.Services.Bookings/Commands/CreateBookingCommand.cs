using SmartHotel220.Services.Bookings.Data.Repositories;
using SmartHotel220.Services.Bookings.Domain;
using SmartHotel220.Services.Bookings.Domain.Booking;
using System;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Bookings.Commands
{
    /// <summary>
    /// Команда (условно) для создания бронирований
    /// </summary>
    public class CreateBookingCommand
    {
        /// <summary>
        /// Репозиторий, содержащий контекст базы. По сути обвёртка над контекстом для добавления
        /// </summary>
        private readonly BookingRepository _bookingRepository;
        /// <summary>
        /// Используется для асихнронного сохранения изменений. Также обвёртка над контекстом
        /// </summary>
        private readonly UnitOfWork _uow;

        public CreateBookingCommand(BookingRepository bookingRepostiory, UnitOfWork uow)
        {
            _bookingRepository = bookingRepostiory;
            _uow = uow;
        }

        /// <summary>
        /// Выполняем добавление запроса в репозиторий и сохраняет изменения
        /// </summary>
        /// <param name="bookingRequest">Запрос</param>
        public async Task<bool> Execute(BookingRequest bookingRequest)
        {
            var booking = new Booking {
                IdHotel = bookingRequest.HotelId,
                ClientEmail = bookingRequest.UserId,
                CheckInDate = bookingRequest.From,
                CheckOutDate = bookingRequest.To,
                TotalCost = bookingRequest.Price,
                NumberOfAdults = bookingRequest.Adults,
                NumberOfChildren = bookingRequest.Kids,
                NumberOfBabies = bookingRequest.Babies,
                IdRoomType = bookingRequest.RoomType
            };

            // Добавляем
            _bookingRepository.Add(booking);

            // Сохраняем
            await _uow.SaveChangesAsync();

            return true;
        } // Execute
    } // CreateBookingCommand

    /// <summary>
    /// Для запроса бронирования
    /// </summary>
    public class BookingRequest
    {
        public int HotelId { get; set; }
        public string UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public byte Adults { get; set; }
        public byte Kids { get; set; }
        public byte Babies { get; set; }
        public int RoomType { get; set; }
        public int Price { get; set; }
    } // BookingRequest
}