using Dapper;
using DapperTest.Models;
using Microsoft.Data.SqlClient;

namespace DapperTest.Services
{
    public class NoteServices:INoteServices
    {
        private readonly IConfiguration config;
        private readonly string connectionstring;
        public NoteServices(IConfiguration config)
        {
            this.config = config;
            connectionstring = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<NoteModels>> GetAll()
        {
            using (SqlConnection con =  new SqlConnection(connectionstring))
            {
                var result = await con.QueryAsync<NoteModels>("select * from notes");
                return result;
            }
        }

        public async Task<NoteDTO> GetbyID(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    var result = await con.QueryAsync<NoteDTO>($"select * from notes where id={Id}");
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> AddNew(NoteDTO model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    await con.ExecuteAsync($"insert into notes (note) Values('{model.note}')");
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditNote(int id, NoteDTO model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    await con.ExecuteAsync($"update notes set note='{model.note}' where id={id}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteNote(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    await con.ExecuteAsync($"delete from notes where id={id}");
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
