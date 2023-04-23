using Manuais_Data.Context;
using Manuais_Data.Repositories.Interfaces;
using Manuais_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuais_Data.Repositories.Repository
{
    public class ManuaisRepository : IManuaisRepository
    {

        private readonly ManuaisContext _manuaisContext;

        public ManuaisRepository(ManuaisContext manuaisContext)
        {
            _manuaisContext = manuaisContext;
        }
        public async Task<Manuais> Delete(int id)
        {
            var sql = $@"Update Manuais Set 
                            Deleted = 1,
                            DeletedDate = GetDate()
                        Where id = {id}";

            var query = await Dapper.SqlMapper.QueryAsync<Manuais>(_manuaisContext.Database.GetDbConnection(), sql);

            return query.FirstOrDefault();
        }

        public async Task<IQueryable<Manuais>> GetAll()
        {
            var sql = $@"Select * From Manuais Where Deleted = 0";

            var query = await Dapper.SqlMapper.QueryAsync<Manuais>(_manuaisContext.Database.GetDbConnection(), sql);

            return query.AsQueryable();
        }

        public async Task<IQueryable<Manuais>> GetAllById(int id)
        {
            var sql = $@"Select * From Manuais Where Id = {id} and Deleted = 0";

            var query = await Dapper.SqlMapper.QueryAsync<Manuais>(_manuaisContext.Database.GetDbConnection(), sql);

            return query.AsQueryable();
        }

        public async Task<Manuais> InsertOrUpdate(Manuais manuais)
        {
            if (manuais.Id > 0)
            {
                _manuaisContext.Manuais.Update(manuais);
                return manuais;
            }
            else
            {
                manuais.DataInclusao = DateTime.Now;
                manuais.Deleted = false;
                await _manuaisContext.Manuais.AddAsync(manuais);
            }
            await _manuaisContext.SaveChangesAsync();

            return manuais;
        }
    }
}
