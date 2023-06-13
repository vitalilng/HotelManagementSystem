using AutoMapper;
using HotelManagementSystem.Server;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service;
using HotelManagementSystem.Server.Service.Contracts;
using Moq;

namespace HotelManagementSystem.Tests
{
    [TestFixture]
    public class GetTransactionsByUsernameTests
    {
        public ITransactionService transactionService;
        public Mock<ITransactionRepository> transactionRepository;
        public Mock<IRepositoryManager> repositoryManager;
        public Mock<ILoggerManager> loggerManager;
        public IMapper mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new Mapper(configuration);

            transactionRepository = new Mock<ITransactionRepository>();
            repositoryManager = new Mock<IRepositoryManager>();
            loggerManager = new Mock<ILoggerManager>();

            repositoryManager.Setup(rm => rm.TransactionRepository).Returns(transactionRepository.Object);
            transactionService = new TransactionService(repositoryManager.Object, mapper, loggerManager.Object);
        }

        [Test]
        public void GetTransactionsByUsername_ValidUsername_ReturnsTransactions()
        {
            //Arrange
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

            //if model contains navigation properties those also needs to be mocked
            //here was the issue, missing ApplicationUser set to user, and it returned always null
            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023, 08, 20),
                    RoomId = room.Id,
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
            }.AsQueryable();
            transactionRepository.Setup(r => r.GetTransactionsQueryable()).Returns(transactions);

            //Act
            var result = transactionService.GetTransactionsByUsername(username);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result.First().UserName, Is.EqualTo(user.UserName));
                Assert.That(result.First().RoomPrice, Is.EqualTo(room.Price));
            });
        }

        [Test]
        public void GetTransactionsByUsername_ValidUsernameNoTransactions_ReturnsEmpty()
        {
            //Arrange
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
            var transactions = new List<Transaction>().AsQueryable();
            transactionRepository.Setup(tr => tr.GetTransactionsQueryable()).Returns(transactions);

            //Act
            var result = transactionService.GetTransactionsByUsername(username);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}
