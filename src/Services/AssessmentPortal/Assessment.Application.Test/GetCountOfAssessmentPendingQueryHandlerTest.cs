namespace Assessment.Application.Test
{
    [TestFixture]
    public class GetCountOfAssessmentPendingQueryHandlerTest
    {
        private Mock<IResultRepository> _userResultRepositoryMock;
        private GetCountOfAssessmentPendingQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _userResultRepositoryMock = new Mock<IResultRepository>();
            _handler = new GetCountOfAssessmentPendingQueryHandler(_userResultRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsCountOfPendingAssessments()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var query = new GetCountOfAssessmentPendingQuery { UserId = userId };

            var pendingAssessments = new List<UserResultDTO>
        {
            new UserResultDTO { Status = "pending" },
            new UserResultDTO { Status = "pending" },
            new UserResultDTO { Status = "completed" } // This should be excluded from the count
        };

            _userResultRepositoryMock
                .Setup(repo => repo.GetAssessmentResultByUserId(userId))
                .ReturnsAsync(pendingAssessments);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(2)); // Expecting 2 pending assessments
        }

        [Test]
        public async Task Handle_ReturnsZeroCountWhenNoPendingAssessments()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var query = new GetCountOfAssessmentPendingQuery { UserId = userId };

            var completedAssessments = new List<UserResultDTO>
        {
            new UserResultDTO { Status = "completed" },
            new UserResultDTO { Status = "completed" },
        };

            _userResultRepositoryMock
                .Setup(repo => repo.GetAssessmentResultByUserId(userId))
                .ReturnsAsync(completedAssessments);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(0)); // Expecting 0 pending assessments
        }

    }
}
