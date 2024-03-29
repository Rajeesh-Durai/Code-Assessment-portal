﻿using MediatR.Pipeline;
namespace AssessmentPortal.Application.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        await Task.Delay(500);
        _logger.LogInformation("Request: {Name}  {@Request}",
            requestName, request);
    }
}
