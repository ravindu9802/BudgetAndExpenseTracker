using MediatR;
using Tracker.Domain.Primitives;

namespace Tracker.Application.Abstractions.Messaging;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}