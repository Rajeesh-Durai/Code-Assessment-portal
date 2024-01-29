namespace Assessment.Application.Test
{
    [TestFixture]
    public class GetCountOfCompletedAssessmentQueryHandlerTest
    {
        private Mock<IResultRepository> _userResultRepositoryMock;
        private GetCountOfCompletedAssessmentQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _userResultRepositoryMock = new Mock<IResultRepository>();
            _handler = new GetCountOfCompletedAssessmentQueryHandler(_userResultRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsCountOfCompletedAssessments()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var query = new GetCountOfCompletedAssessmentQuery { UserId = userId };

            var completedAssessments = new List<UserResultDTO>
        {
            new UserResultDTO { Status = "completed" },
            new UserResultDTO { Status = "completed" },
            new UserResultDTO { Status = "in_progress" }
        };

            _userResultRepositoryMock
                .Setup(repo => repo.GetAssessmentResultByUserId(userId))
                .ReturnsAsync(completedAssessments);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public async Task Handle_ReturnsZeroCountWhenNoCompletedAssessments()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var query = new GetCountOfCompletedAssessmentQuery { UserId = userId };

            var inProgressAssessments = new List<UserResultDTO>
        {
            new UserResultDTO { Status = "progress" },
            new UserResultDTO { Status = "progress" },
        };

            _userResultRepositoryMock
                .Setup(repo => repo.GetAssessmentResultByUserId(userId))
                .ReturnsAsync(inProgressAssessments);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Expecting 0 completed assessments
        }
    }
}
