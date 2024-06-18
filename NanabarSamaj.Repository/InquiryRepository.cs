using Dapper;
using Microsoft.Extensions.Configuration;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Repository.Interfaces;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Repository
{
    public class InquiryRepository : BaseRepository,IInquiryRepository
    {
        public InquiryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Inquiry>> GetAll()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Inquiry>("select * from inquiry WHERE  is_active=true order by created_on").ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public async Task<Inquiry> Add(Inquiry entity)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_inquiryadd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("p_id", entity.id);
                        pgcom.Parameters.AddWithValue("p_phonenumber", entity.phone_number);
                        pgcom.Parameters.AddWithValue("p_title", entity.title);
                        pgcom.Parameters.AddWithValue("p_message", entity.message);
                        pgcom.Parameters.AddWithValue("p_is_active", entity.is_active);
                        pgcom.Parameters.AddWithValue("p_created_by_id", entity.created_by_id);
                        await pgcom.ExecuteNonQueryAsync();
                    }
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Guid> Update(Inquiry entity)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    var parameters = new
                    {
                        p_id = entity.id,
                        p_phonenumber = entity.phone_number,
                        p_title = entity.title,
                        p_message = entity.message,
                        p_is_active = entity.is_active,
                        p_updated_by_id = entity.updated_by_id,
                        p_updated_on = entity.updated_on
                    };

                    await pgcon.ExecuteAsync("proc_inquiryupdate", parameters, commandType: CommandType.StoredProcedure);

                    return entity.id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public async Task<bool> Delete(Guid id) 
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE inquiry SET is_active = false WHERE id = @Id";
                    await pgcon.ExecuteAsync(sql, new { Id = id });
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public async Task<Inquiry> GetById(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    var inquiry = await pgcon.QueryFirstOrDefaultAsync<Inquiry>("SELECT * FROM inquiry WHERE is_active = true AND id = @Id", new { Id = id });
                    return inquiry;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
