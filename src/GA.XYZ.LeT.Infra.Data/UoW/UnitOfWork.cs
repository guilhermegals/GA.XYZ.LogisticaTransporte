using GA.XYZ.LeT.Domain.Core.Commands;
using GA.XYZ.LeT.Domain.Interfaces;
using GA.XYZ.LeT.Infra.Data.Context;

namespace GA.XYZ.LeT.Infra.Data.UnitOfWork {

    public class UnitOfWork : IUnitOfWork {

        private readonly LeTContext _context;

        public UnitOfWork(LeTContext context) {
            this._context = context;
        }

        public CommandResponse Commit() {
            var rowsAffected = _context.SaveChanges();

            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
