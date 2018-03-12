using Dapper;
using HelloWorld.Interfaces;
using HelloWorld.Models;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Repositories
{
    public class PersonRepository : BaseRepository, IPerson
    {
        public PersonRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public async Task<string> AddPerson(Person model)
        {
            return await WithConnection(async c =>
            {
                var p = new DynamicParameters();
                p.Add("@name", model.Name, DbType.String, ParameterDirection.Input);
                p.Add("@lastName", model.LastName, DbType.String, ParameterDirection.Input);
                p.Add("@age", model.Age, DbType.Int32, ParameterDirection.Input);
                p.Add("@opinion", model.Opinion, DbType.String, ParameterDirection.Input);
                p.Add("@genre", model.Genre, DbType.String, ParameterDirection.Input);
                var result = await c.QueryAsync<string>(
                    sql: "[dbo].[sp_AddPerson]",
                    param: p,
                    commandType: CommandType.StoredProcedure
                    );            
                return result.FirstOrDefault();
            });
        }

        public async Task<bool> DeletePerson(int personID)
        {
            return await WithConnection(async c =>
            {
                var p = new DynamicParameters();
                p.Add("@personID", personID, DbType.Int32, ParameterDirection.Input);
                var persons = await c.QueryAsync<bool>(
                    sql: "[dbo].[sp_DeletePerson]",
                    param: p,
                    commandType: CommandType.StoredProcedure
                    );
                return persons.FirstOrDefault();
            });
        }

        public async Task<Person> GetPerson(int personID)
        {
            return await WithConnection(async c =>
            {
                var p = new DynamicParameters();
                p.Add("@option", 1, DbType.Int32, ParameterDirection.Input);
                p.Add("@personId", personID, DbType.Int32, ParameterDirection.Input);                            
                var persons = await c.QueryAsync<Person>(
                    sql: "[dbo].[sp_persons]",
                    param: p,
                    commandType: CommandType.StoredProcedure
                    );               
                return persons.FirstOrDefault();

            });
        }

        public async Task<IQueryable<Person>> GetPersonList()
        {
            return await WithConnection(async c =>
            {
                var watch = Stopwatch.StartNew();
                var persons = await c.QueryAsync<Person>(
                    sql: "[dbo].[sp_persons]",
                    param: null,
                    commandType: CommandType.StoredProcedure
                    );
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Debug.Write($"GetPerson method => {elapsedMs} ms");
                return persons.AsQueryable();
            });
        }
    }
}