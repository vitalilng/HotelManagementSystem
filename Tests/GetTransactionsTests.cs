using AutoMapper;
using HotelManagementSystem.Server;
using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Models;
using HotelManagementSystem.Server.Service;
using Telerik.JustMock;

namespace HotelManagementSystem.Tests
{
    public class GetTransactionsTests
    {
        public TransactionService transactionService;
        public ITransactionRepository transactionRepository;
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
            loggerManager = Mock.Create<ILoggerManager>();
            repositoryManager = Mock.Create<IRepositoryManager>();
            transactionService = new(repositoryManager, mapper, loggerManager);
            transactionRepository = Mock.Create<ITransactionRepository>();
            Mock.Arrange(() => repositoryManager.TransactionRepository)
                .Returns(transactionRepository);
        }

        [Test]
        public void GetTransactionsEnumerable_ListOfTwoElements_ReturnsTransactionsMapped()
        {
            //Arrange
            var list = new List<Transaction>() {
                new Transaction{
                    Id = Guid.NewGuid(),
                    ApplicationUserId = "userID",
                    RoomId = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023,08,20),
                    DepartureDate = new DateTime(2023, 08, 27),
                    RoomPrice = 1230,
                    TotalSum = 23456,
                    TransactionDateTime = DateTimeOffset.Now,
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    ApplicationUserId = "userID11",
                    RoomId = Guid.NewGuid(),
                    ArrivalDate = new DateTime(2023,09,20),
                    DepartureDate = new DateTime(2023, 09, 27),
                    RoomPrice = 1110,
                    TotalSum = 2156,
                    TransactionDateTime = DateTimeOffset.Now,
                }
            };
            Mock.Arrange(() => transactionRepository.GetTransactionsEnumerable())
                .Returns(list);

            //Act
            var result = transactionService.GetTransactions();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(result.First().Id, Is.EqualTo(list[0].Id));
                Assert.That(result.First().TotalSum, Is.EqualTo(list[0].TotalSum));
            });
        }

        [Test]
        public void GetTransactionsEnumerable_ExceptionIsThrown_ReturnsEmptyList()
        {
            //Arrange
            Mock.Arrange(() => transactionRepository.GetTransactionsEnumerable())
                .Throws(new Exception());

            //Act
            var result = transactionService.GetTransactions();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}