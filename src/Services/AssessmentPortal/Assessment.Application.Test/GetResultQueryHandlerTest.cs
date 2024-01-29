namespace Assessment.Application.Test
{
    [TestFixture]
    public class GetResultQueryHandlerTests
    {
        private Mock<IResultRepository> _resultRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetResultQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _resultRepositoryMock = new Mock<IResultRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetResultQueryHandler(_resultRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsMappedResultResponses()
        {
            // Arrange
            Guid userId = Guid.Parse("694db67e-ae3f-438a-b106-feca3320db36");
            var query = new GetResultQuery { UserId = userId };

            var userResultDTOs = new List<UserResultDTO>
            {
                new UserResultDTO
                {
                    User_assessment_id = Guid.Parse("b7417e4e-7a47-427a-af7d-ef8cabf7fbeb"),
                    User_id = userId,
                    Topic_name = "C",
                    Skill_level = "Basic",
                    Status = "Completed",
                    Score = 80,
                    Correct_answer = 15,
                    Wrong_answer = 5
                },
                new UserResultDTO
                {
                    User_assessment_id = Guid.Parse("ce6aff9f-3760-40b7-89ff-bb7509105f9a"),
                    User_id = userId,
                    Topic_name = "C#",
                    Skill_level = "Intermediate",
                    Status = "Completed",
                    Score = 80,
                    Correct_answer = 15,
                    Wrong_answer = 5
                }
            };

            var expectedMappedResult = new List<ResultResponse>
            {
                new ResultResponse
                {
                    User_assessment_id = Guid.Parse("b7417e4e-7a47-427a-af7d-ef8cabf7fbeb"),
                    User_id = userId,
                    Topic_name = "C",
                    Skill_level = "Basic",
                    Status = "Completed",
                    Score = 80,
                    Correct_answer = 15,
                    Wrong_answer = 5
                },
                new ResultResponse
                {
                    User_assessment_id = Guid.Parse("ce6aff9f-3760-40b7-89ff-bb7509105f9a"),
                    User_id = userId,
                    Topic_name = "C#",
                    Skill_level = "Intermediate",
                    Status = "Completed",
                    Score = 80,
                    Correct_answer = 15,
                    Wrong_answer = 5
                },
            };


            _resultRepositoryMock
                .Setup(repo => repo.GetAssessmentResultByUserId(userId))
                .ReturnsAsync(userResultDTOs);

            _mapperMock
                .Setup(mapper => mapper.Map<List<ResultResponse>>(userResultDTOs))
                .Returns(expectedMappedResult);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedMappedResult));
        }

    }
}