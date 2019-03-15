using System;
using GA.XYZ.LeT.Domain.Core.Commands;

namespace GA.XYZ.LeT.Domain.Interfaces {

    public interface IUnitOfWork : IDisposable{

        CommandResponse Commit();

    }
}
