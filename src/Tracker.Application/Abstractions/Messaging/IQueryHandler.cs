using MediatR;
using Tracker.Domain.Primitives;

namespace Tracker.Application.Abstractions.Messaging;

internal interface IQueryHandler<TQuery>
    : IRequestHandler<TQuery, Result>
    where TQuery : IQuery
{
}

internal interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}