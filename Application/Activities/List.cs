using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext context;
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                this._logger = logger;
                this.context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //cancellationToken.ThrowIfCancellationRequested();
                        //await Task.Delay(1000, cancellationToken);
                        //this._logger.LogInformation($"Task {i} executed.");
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Task was cacelled by user.");
                }
                return await this.context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}