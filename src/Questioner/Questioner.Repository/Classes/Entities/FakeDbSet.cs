using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Questioner.Repository.Classes.Entities
{
    public class FakeDbSet<TEntity> : DbSet<TEntity> where TEntity : class
    {
        private List<TEntity> _entities;

        public FakeDbSet()
            : base()
        {
            _entities = new List<TEntity>();
        }

        public override LocalView<TEntity> Local => base.Local;

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            _entities.Add(entity);

            return null;
        }

        public override void AddRange(params TEntity[] entities)
        {
            _entities.AddRange(entities);
        }

        public override void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public override IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable();
        }
    }
}