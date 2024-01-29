namespace Assessment.Application.Test
{
    [TestFixture]
    public class GetAssessmentQuestionQueryHandlerTests
    {
        private Mock<IAssessmentQuestionRepository> _assessmentQuestionRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetAssessmentQuestionQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _assessmentQuestionRepositoryMock = new Mock<IAssessmentQuestionRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAssessmentQuestionQueryHandler(_assessmentQuestionRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsMappedAssessmentQuestionResponses()
        {
            // Arrange
            var userAssessmentId = Guid.Parse("694db67e-ae3f-438a-b106-feca3320db36");
            var query = new GetAssessmentQuestionQuery { UserAssessmentId = userAssessmentId };

            var assessmentQuestions = new List<GetAssessmentQuestionDTO>
            {
            new GetAssessmentQuestionDTO { id = 1, Question = "Sum of 2 numbers", sample_input = "10 2", sample_output = "12", expected_input = "11 11", expected_output = "22" },
            new GetAssessmentQuestionDTO { id = 1, Question = "Multiplication of 2 numbers", sample_input = "10 2", sample_output = "20", expected_input = "11 11", expected_output = "121" }
            };


            var expectedMappedResult = new List<AssessmentQuestionResponse>
            {
            new AssessmentQuestionResponse { id = 1, question = "Sum of 2 numbers", sample_input = "10 2", sample_output = "12", expected_input = "11 11", expected_output = "22" },
            new AssessmentQuestionResponse { id = 1, question = "Multiplication of 2 numbers", sample_input = "10 2", sample_output = "20", expected_input = "11 11", expected_output = "121" }
            };

            _assessmentQuestionRepositoryMock
                .Setup(repo => repo.GetAssessmentQuestionByIdAsync(userAssessmentId))
                .ReturnsAsync(assessmentQuestions);

            _mapperMock
                .Setup(mapper => mapper.Map<List<AssessmentQuestionResponse>>(assessmentQuestions))
                .Returns(expectedMappedResult);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedMappedResult));
        }
    }
}

