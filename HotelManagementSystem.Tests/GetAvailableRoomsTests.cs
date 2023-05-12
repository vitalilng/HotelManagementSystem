using AutoMapper;
using HotelManagementSystem.Server;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Service;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.Dto;
using HotelManagementSystem.Shared.Exceptions;
using HotelManagementSystem.Shared.RequestFeatures;
using Telerik.JustMock;

namespace HotelManagementSystem.Tests
{
    public class GetAvailableRoomsTests
    {
        public IRoomService roomService;
        public IRoomRepository roomRepository;
        public IRepositoryManager repositoryManager;
        public ILoggerManager loggerManager;
        public IMapper mapper;

        [SetUp]
        public void Setup()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg =>
                                cfg.AddProfile(profile));
            mapper = new Mapper(configuration);
            roomRepository = Mock.Create<IRoomRepository>();
            repositoryManager = Mock.Create<IRepositoryManager>();
            loggerManager = Mock.Create<ILoggerManager>();
            roomService = new RoomService(repositoryManager, mapper, loggerManager);
            Mock.Arrange(() => repositoryManager.RoomRepository)
                .Returns(roomRepository);
        }

        [Test]
        public void GetAvailableRooms_DateOfArrivalEmptyDateOfDepartureFilled_ReturnsException()
        {
            //Arrange
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = null,
                DateOfDeparture = DateTime.Today
            };

            //Act
            var ex = Assert.Throws<InValidDateRangeBadRequestException>(() => roomService.GetAvailableRooms(transactionParameters));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Both dates are required!"));
        }

        [Test]
        public void GetAvailableRooms_ValidDateRangeFalse_ReturnsException()
        {
            //Arrange
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = DateTime.Today,
                DateOfDeparture = DateTime.Today
            };

            //Act
            var ex = Assert.Throws<InValidDateRangeBadRequestException>(() => roomService.GetAvailableRooms(transactionParameters));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Date of Departure should be higher than Date of Arrival!"));
        }

        [Test]
        public void GetAvailableRooms_DatesInThePast_ReturnsException()
        {
            //Arrange
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = new DateTime(2000, 10, 22),
                DateOfDeparture = new DateTime(2000, 11, 20)
            };

            //Act
            var ex = Assert.Throws<InValidDateRangeBadRequestException>(() => roomService.GetAvailableRooms(transactionParameters));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Please, choose the date starting from today!"));
        }

        [Test]
        public void GetAvailableRooms_InvalidDateFormat_ReturnsException()
        {
            //Arrange            
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = new DateTime(00),
                DateOfDeparture = new DateTime(2000, 11, 20)
            };

            //Act
            var ex = Assert.Throws<InValidDateRangeBadRequestException>(() => roomService.GetAvailableRooms(transactionParameters));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Please, choose the date starting from today!"));
        }

        [Test]
        public void GetAvailableRooms_EmptyRoomList_ReturnsEmptyList()
        {
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = DateTime.Today,
                DateOfDeparture = DateTime.Today.AddDays(12)
            };

            var result = roomService.GetAvailableRooms(transactionParameters);

            Assert.That(result, Is.Empty);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetAvailableRooms_ValidDates_ReturnsListOfRooms()
        {
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = DateTime.Today,
                DateOfDeparture = DateTime.Today.AddDays(30),
            };

            var result = roomService.GetAvailableRooms(transactionParameters);
            
            Assert.That(result.Count(), Is.EqualTo(3));
        }


    }
}