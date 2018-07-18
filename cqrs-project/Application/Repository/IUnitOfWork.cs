using System;
using Domain.Core.Commands;

namespace Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}