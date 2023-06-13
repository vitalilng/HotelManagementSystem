using AutoMapper;
using HotelManagementSystem.Server;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service;
using HotelManagementSystem.Server.Service.Contracts;
using HotelManagementSystem.Shared.RequestFeatures;
using Moq;

namespace HotelManagementSystem.Tests
{
    [TestFixture]
    public class GetAvailableRoomsTestsWithMoq
    {
        public IRoomService roomService;
        public Mock<IRoomRepository> roomRepository;
        public Mock<IRepositoryManager> repositoryManager;
        public Mock<ILoggerManager> loggerManager;
        public IMapper mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

            mapper = new Mapper(configuration);
            roomRepository = new Mock<IRoomRepository>(MockBehavior.Strict);
            repositoryManager = new Mock<IRepositoryManager>(MockBehavior.Strict);
            repositoryManager.Setup(rm => rm.RoomRepository).Returns(roomRepository.Object);            
            loggerManager = new Mock<ILoggerManager>(MockBehavior.Strict);
            roomService = new RoomService(repositoryManager.Object, mapper, loggerManager.Object);
        }

        [Test]
        public void GetAvailableRooms_ValidDates_ReturnsListOfRooms()
        {
            //Arrange
            var transactionParameters = new TransactionParameters()
            {
                DateOfArrival = DateTime.Today,
                DateOfDeparture = DateTime.Today.AddDays(15)
            };

            const string username = "speedy";

            var user = new ApplicationUser()
            {
                Id = "22",
                UserName = username
            };

            var room = new Room()
            {
                Id = Guid.NewGuid(),
                Price = 1000,
            };

            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023, 08, 20),
                    DepartureDate = new DateTime(2023, 08, 27),
                    TotalSum = 23456,
                    TransactionDateTime = DateTimeOffset.Now,
                    ApplicationUser = user,
                    Room = room
                },
                new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023, 08, 20),
                    DepartureDate = new DateTime(2023, 08, 27),
                    TotalSum = 23456,
                    TransactionDateTime = DateTimeOffset.Now,
                    ApplicationUser = user,
                    Room = room
                }
            };

            var queryRooms = new List<Room>()
            {
                new Room
                {
                    Id = Guid.NewGuid(),
                    RoomType = "Double",
                    RoomSize = "40m2",
                    NrOfBedsAndSizes = "2 beds",
                    RoomOptions = "TV, Wifi",
                    MaxPersonsAllowed = "2",
                    Availability = "yes",
                    Description = "description",
                    Price = 1233,
                    Transactions = transactions,
                },
                new Room
                {
                    Id = Guid.NewGuid(),
                    RoomType = "Triple",
                    RoomSize = "70m2",
                    NrOfBedsAndSizes = "3 beds",
                    RoomOptions = "TV, Wifi",
                    MaxPersonsAllowed = "2",
                    Availability = "yes",
                    Description = "description",
                    Price = 1233,
                    Transactions = transactions,
                }
            }.AsQueryable();

            roomRepository.Setup(r => r.GetRoomsQueryable()).Returns(queryRooms);

            //Act
            var result = roomService.GetAvailableRooms(transactionParameters);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First().RoomType, Is.EqualTo("Double"));
                Assert.That(result.Last().RoomType, Is.EqualTo("Triple"));
            });
        }
    }
}