using Dapper;
using Microsoft.Extensions.Configuration;
using NanabarSamaj.API.Common;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository;
using NanabarSamaj.Repository.Interfaces;
using Npgsql;
using System.Data;
using System.Reflection;

namespace NanabarSamaj.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Users> Add(Users entity)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_useradd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("u_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.id);
                        pgcom.Parameters.AddWithValue("u_name", NpgsqlTypes.NpgsqlDbType.Text, entity.name);
                        pgcom.Parameters.AddWithValue("u_father_name", NpgsqlTypes.NpgsqlDbType.Text, entity.father_name);
                        pgcom.Parameters.AddWithValue("u_surname", NpgsqlTypes.NpgsqlDbType.Text, entity.surname);
                        pgcom.Parameters.AddWithValue("u_mobile_number", NpgsqlTypes.NpgsqlDbType.Text, entity.mobile_number);
                        pgcom.Parameters.AddWithValue("u_email", NpgsqlTypes.NpgsqlDbType.Text, entity.email);
                        pgcom.Parameters.AddWithValue("u_gender", NpgsqlTypes.NpgsqlDbType.Text, entity.gender);
                        pgcom.Parameters.AddWithValue("u_address", NpgsqlTypes.NpgsqlDbType.Text, entity.address);
                        pgcom.Parameters.AddWithValue("u_lookup_city_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.lookup_city_id);
                        pgcom.Parameters.AddWithValue("u_lookup_state_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.lookup_state_id);
                        pgcom.Parameters.AddWithValue("u_lookup_country_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.lookup_country_id);
                        pgcom.Parameters.AddWithValue("u_pincode", NpgsqlTypes.NpgsqlDbType.Text, entity.pincode);
                        pgcom.Parameters.AddWithValue("u_lookup_sakh_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.lookup_sakh_id);
                        pgcom.Parameters.AddWithValue("u_password", NpgsqlTypes.NpgsqlDbType.Text, entity.password);
                        pgcom.Parameters.AddWithValue("u_is_terms", NpgsqlTypes.NpgsqlDbType.Boolean, entity.is_terms);
                        pgcom.Parameters.AddWithValue("u_image", NpgsqlTypes.NpgsqlDbType.Text, entity.image);
                        pgcom.Parameters.AddWithValue("u_is_active", NpgsqlTypes.NpgsqlDbType.Boolean, entity.is_active);
                        pgcom.Parameters.AddWithValue("u_is_verify", NpgsqlTypes.NpgsqlDbType.Boolean, entity.is_verify);
                        pgcom.Parameters.AddWithValue("u_created_by_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.created_by_id);
                        pgcom.Parameters.AddWithValue("u_lookup_role_id", NpgsqlTypes.NpgsqlDbType.Uuid, entity.lookup_role_id);

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
                    string sql = "UPDATE users SET is_active = false WHERE id = @Id";
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

        public Task<Users> GetByEmail(string email)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return Task.FromResult(pgcon.Query<Users>("select * from users where email = @email;SELECT 1", new { email = email }).FirstOrDefault());
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
        public Task<Users> GetByEmailPhone(string email, string mobile_number)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    //return pgcon.Query<Users>("select * from users where email = @email and mobile_number = @;SELECT 1", new { email, mobile_number }).FirstOrDefault();
                    return Task.FromResult(pgcon.Query<Users>("select * from users where email = @email OR mobile_number = @mobile_number ;SELECT 1", new { email = email, mobile_number = mobile_number }).FirstOrDefault());
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
        public Task<Users> GetByPhone(string mobile_number)
        {

            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    //return pgcon.Query<Users>("select * from users where email = @email and mobile_number = @;SELECT 1", new { email, mobile_number }).FirstOrDefault();
                    return Task.FromResult(pgcon.Query<Users>("select * from users where mobile_number = @mobile_number ;SELECT 1", new { mobile_number = mobile_number }).FirstOrDefault());
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
        public async Task<List<GetAllUsersViewModel>> GetAll()
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
                    var userList = await pgcon.QueryAsync<GetAllUsersViewModel>("SELECT * FROM proc_usergetsall(@a_pagenumber,@a_pagesize)", queryParameters);
                    return userList.AsList();
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

        public async Task<GetAllUsersViewModel> GetById(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    var user = await pgcon.QueryFirstOrDefaultAsync<GetAllUsersViewModel>(
                                            "SELECT * FROM proc_usergetbyid(@user_id)", new { user_id = id });
                    return user;
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

        public async Task<Guid> UpdateUser(UsersUpdateViewModel entity)
        {
            try
            {

                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    var parameters = new
                    {
                        p_id = entity.id,
                        p_name = entity.name,
                        p_father_name = entity.father_name,
                        p_surname = entity.surname,
                        p_mobile_number = entity.mobile_number,
                        p_email = entity.email,
                        p_gender = entity.gender,
                        p_address = entity.address,
                        p_lookup_city_id = entity.lookup_city_id,
                        p_lookup_state_id = entity.lookup_state_id,
                        p_lookup_country_id = entity.lookup_country_id,
                        p_pincode = entity.pincode,
                        p_lookup_sakh_id = entity.lookup_sakh_id,
                        p_password = entity.password,
                        p_is_terms = entity.is_terms,
                        p_image = entity.image,
                        p_is_active = entity.is_active,
                        p_is_verify = entity.is_verify,
                        p_lookup_role_id = entity.lookup_role_id,
                        p_dob = entity.dob,
                        p_lookup_marital_id = entity.lookup_marital_id,
                        p_religion = entity.religion,
                        p_mother_tongue = entity.mother_tongue,
                        p_community = entity.community,
                        p_diet_preferences = entity.diet_preferences,
                        p_annual_income = entity.annual_income,
                        p_collage_name = entity.collage_name,
                        p_hobbies = entity.hobbies,
                        p_updated_by_id = entity.updated_by_id,
                        p_updated_on = entity.updated_on
                    };


                    await pgcon.ExecuteAsync("public.proc_userupdate", parameters, commandType: CommandType.StoredProcedure);

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

        #region AdminMethods
        public Task<Users> AdminGetByEmail(string email)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return Task.FromResult(pgcon.Query<Users>("select * from users where email = @email;SELECT 1", new { email = email }).FirstOrDefault());
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

        public async Task<string> AdminGetById(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return await pgcon.QueryFirstOrDefaultAsync<string>("select name from lookup_role where id = @id", new { id = id });
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
        #endregion

        public Task<Guid> Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}