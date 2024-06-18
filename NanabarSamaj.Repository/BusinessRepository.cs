using Dapper;
using Microsoft.Extensions.Configuration;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Repository
{
    public class BusinessRepository : BaseRepository, IBusinessRepository
    {
        public BusinessRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Business> Add(Business entity)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_businessadd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("p_id", entity.id);
                        pgcom.Parameters.AddWithValue("p_concern_name", entity.concern_name);
                        pgcom.Parameters.AddWithValue("p_business_name", entity.business_name);
                        pgcom.Parameters.AddWithValue("p_business_details", entity.business_details);
                        pgcom.Parameters.AddWithValue("p_lookup_business_category_id", entity.lookup_business_category_id ?? Guid.Empty);
                        pgcom.Parameters.AddWithValue("p_address", entity.address ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_lookup_city_id", entity.lookup_city_id);
                        pgcom.Parameters.AddWithValue("p_lookup_country_id", entity.lookup_country_id);
                        pgcom.Parameters.AddWithValue("p_lookup_state_id", entity.lookup_state_id);
                        pgcom.Parameters.AddWithValue("p_zipcode", entity.zipcode ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_contact_number_1", entity.contact_number_1 ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_contact_number_2", entity.contact_number_2 ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_website", entity.website ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_email", entity.email ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_facebook_link", entity.facebook_link ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_instagram_link", entity.instagram_link ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_business_image_1", entity.business_image_1 ?? string.Empty);
                        pgcom.Parameters.AddWithValue("p_is_active", entity.is_active);
                        pgcom.Parameters.AddWithValue("p_created_by_id", entity.created_by_id);
                        pgcom.Parameters.AddWithValue("p_user_id", entity.user_id);
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
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE business SET is_active = false WHERE id = @Id";
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
        public async Task<IEnumerable<GetBusinessViewModel>> GetAll()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();

                    var queryParameters = new
                    {
                        a_pagenumber = 1,
                        a_pagesize = 10
                    };

                    var businessList = await pgcon.QueryAsync<GetBusinessViewModel>(
                        "SELECT * FROM proc_businessgetall(@a_pagenumber, @a_pagesize)",
                        queryParameters);

                    return businessList.AsList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    await pgcon.CloseAsync();
                    pgcon.Dispose();
                }
            }
        }
        public async Task<GetBusinessViewModel> GetById(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    var business = await pgcon.QueryFirstOrDefaultAsync<GetBusinessViewModel>(
                        "SELECT * FROM proc_businessgetbyid(@business_id)", new { business_id = id });

                    return business;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    await pgcon.CloseAsync();
                    pgcon.Dispose();
                }
            }
        }
        public async Task<Guid> Update(Business entity)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    var parameters = new
                    {
                        b_id = entity.id,
                        b_concern_name = entity.concern_name,
                        b_business_name = entity.business_name,
                        b_business_details = entity.business_details,
                        b_lookup_business_category_id = entity.lookup_business_category_id,
                        b_address = entity.address,
                        b_lookup_city_id = entity.lookup_city_id,
                        b_lookup_country_id = entity.lookup_country_id,
                        b_lookup_state_id = entity.lookup_state_id,
                        b_zipcode = entity.zipcode,
                        b_contact_number_1 = entity.contact_number_1,
                        b_contact_number_2 = entity.contact_number_2,
                        b_website = entity.website,
                        b_email = entity.email,

                        b_facebook_link = entity.facebook_link,
                        b_instagram_link = entity.instagram_link,
                        b_business_image_1 = entity.business_image_1,

                        b_is_active = entity.is_active,
                        b_updated_by_id = entity.updated_by_id,
                        b_user_id = entity.user_id,
                    };

                    await pgcon.ExecuteAsync("proc_businessupdate", parameters, commandType: CommandType.StoredProcedure);

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
    }
}
