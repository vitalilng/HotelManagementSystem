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
    public class GetTransactionsToBeDisplayedTests
    {
        public ITransactionService transactionService;
        public Mock<ITransactionRepository> transactionRepository;
        public Mock<IRepositoryManager> repositoryManager;
        public Mock<ILoggerManager> loggerManager;
        public IMapper mapper;

        [SetUp]
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
        public void GetTransactionsToBeDisplayed_NoTransactions_ReturnsEmptyList()
        {
            //Arrange
            var transactions = new List<Transaction>()
                .AsQueryable()
                .OrderByDescending(t => t.TransactionDateTime);

            transactionRepository.Setup(tr => tr
                .GetTransactionsQueryable())
                .Returns(transactions);

            //Act
            var result = transactionService.GetTransactionsToBeDisplayed();

            //Assert
            Assert.That(result, Is.Empty);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTransactionsToBeDisplayed_GivenTransactions_ReturnOrderedList()
        {
            var user = new ApplicationUser()
            {
                Id = "22",
                UserName = "user1"
            };

            var room = new Room()
            {
                Id = Guid.NewGuid(),
                Price = 1000,
                RoomType = "Single",
                Description = "Test"
            };

            //if model contains navigation properties those also needs to be mocked
            //here was the issue, missing ApplicationUser set to user, and it returned always null
            var transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023, 05, 20),
                    RoomId = room.Id,
                    DepartureDate = new DateTime(2023, 05, 27),
                    TotalSum = 23456,
                    TransactionDateTime = new DateTime(2023, 05, 20),
                    ApplicationUser = user,
                    Room = room
                },
                new Transaction()
                {
                    Id = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023, 04, 20),
                    DepartureDate = new DateTime(2023, 04, 27),
                    TotalSum = 23456,
                    TransactionDateTime = new DateTime(2023, 04, 20),
                    ApplicationUser = user,
                    Room = room
                }
            }.AsQueryable();

            transactionRepository
                .Setup(tr => tr.GetTransactionsQueryable())
                .Returns(transactions);

            //Act
            var result = transactionService.GetTransactionsToBeDisplayed();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(2));
                Assert.That(result, Is.Ordered.Descending.By("TransactionDateTime"));
            });
        }
    }
}