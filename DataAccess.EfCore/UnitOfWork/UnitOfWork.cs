using DataAccess.EfCore.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext _context)
        {
            this._context = _context;
            ProjectRepository = new ProjectRepository(_context);
            DeveloperRepository = new DeveloperRepository(_context);
        }

        public IDeveloperRepository DeveloperRepository { get; private set; }

        public IProjectRepository ProjectRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
