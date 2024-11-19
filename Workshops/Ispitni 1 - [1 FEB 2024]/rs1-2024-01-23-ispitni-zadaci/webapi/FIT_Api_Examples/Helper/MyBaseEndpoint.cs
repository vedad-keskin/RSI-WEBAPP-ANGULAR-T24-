using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Helper;

[ApiController]
public abstract class MyBaseEndpoint<TRequest, TResponse>:ControllerBase
{
    public abstract Task<TResponse> Obradi(TRequest request, CancellationToken cancellationToken);
}