using Microsoft.Extensions.Configuration;
using Npgsql;
using static Dapper.SqlMapper;
using System.Data;
using Dapper;
using static System.Data.CommandType;
using NanabarSamaj.Repository;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System.Xml.Linq;

namespace NanabarSamaj.Repository
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<IEnumerable<Lookup_Country>> GetCountries()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Country>("select * from lookup_country WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_City>> GetCities()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_City>("select * from lookup_city WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_State>> GetState()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_State>("select * from lookup_state WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Sakh>> GetSakh()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Sakh>("select * from lookup_sakh WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Village>> GetVillage()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Village>("select * from lookup_village WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Besnu>> GetBesnu()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Besnu>("select * from lookup_besnu WHERE is_active=true order by created_on").ToList();
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

        public async Task<IEnumerable<Lookup_Blood_Group>> GetBloodGroup()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Blood_Group>("select * from lookup_blood_group WHERE  is_active=true order by created_on").ToList();
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

        public async Task<IEnumerable<Lookup_Business_Category>> GetBusinesses()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Business_Category>("select * from lookup_business_category WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Education_Type>> GetEducationTypes()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Education_Type>("select * from lookup_education_type WHERE  is_active=true order by created_on").ToList();
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

        public async Task<IEnumerable<Lookup_Education_Sub_Type>> GetEducationSubTypes()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Education_Sub_Type>("select * from lookup_education_sub_type WHERE  is_active=true order by created_on").ToList();
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

        public async Task<IEnumerable<Lookup_Marital_Type>> GetMaritalTypes()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Marital_Type>("select * from lookup_marital_type WHERE  is_active=true order by created_on").ToList();
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

        public async Task<IEnumerable<Lookup_News>> GetNews()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_News>("select * from lookup_news WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Occupation>> GetOccupations()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Occupation>("select * from lookup_occupation WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Position>> GetPositions()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Position>("select * from lookup_position WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Pragatimandal>> GetPragatimandals()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Pragatimandal>("select * from lookup_pragatimandal WHERE  is_active=true order by created_on").ToList();
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
        public async Task<IEnumerable<Lookup_Relation_Type>> GetRelationTypes()
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    return pgcon.Query<Lookup_Relation_Type>("select * from lookup_relation_type WHERE  is_active=true order by created_on").ToList();
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
        #region Besnu
        public async Task<Lookup_Besnu> AddBesnu(Lookup_Besnu besnu)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_besnuadd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("b_id", besnu.id);
                        pgcom.Parameters.AddWithValue("b_name", besnu.name);
                        pgcom.Parameters.AddWithValue("b_lookup_village_id", besnu.lookup_village_id);
                        pgcom.Parameters.AddWithValue("b_death_date", besnu.death_date);
                        pgcom.Parameters.AddWithValue("b_besnu_date", besnu.besnu_date);
                        pgcom.Parameters.AddWithValue("b_address", besnu.address);
                        pgcom.Parameters.AddWithValue("b_start_time", besnu.start_time);
                        pgcom.Parameters.AddWithValue("b_end_time", besnu.end_time);
                        pgcom.Parameters.AddWithValue("b_relative_name", besnu.relative_name);
                        pgcom.Parameters.AddWithValue("b_image", besnu.image);
                        pgcom.Parameters.AddWithValue("b_village", besnu.village);
                        pgcom.Parameters.AddWithValue("b_age", besnu.age);
                        pgcom.Parameters.AddWithValue("b_is_active", besnu.is_active);
                        pgcom.Parameters.AddWithValue("b_created_by_id", besnu.created_by_id);
                        await pgcom.ExecuteNonQueryAsync();
                    }
                }
                return besnu;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Lookup_Besnu> UpdateBesnu(Lookup_Besnu besnu)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_besnuupdate", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("b_id", besnu.id);
                        pgcom.Parameters.AddWithValue("b_name", besnu.name);
                        pgcom.Parameters.AddWithValue("b_lookup_village_id", besnu.lookup_village_id);
                        pgcom.Parameters.AddWithValue("b_death_date", besnu.death_date);
                        pgcom.Parameters.AddWithValue("b_besnu_date", besnu.besnu_date);
                        pgcom.Parameters.AddWithValue("b_address", besnu.address);
                        pgcom.Parameters.AddWithValue("b_start_time", besnu.start_time);
                        pgcom.Parameters.AddWithValue("b_end_time", besnu.end_time);
                        pgcom.Parameters.AddWithValue("b_relative_name", besnu.relative_name);
                        pgcom.Parameters.AddWithValue("b_image", besnu.image);
                        pgcom.Parameters.AddWithValue("b_village", besnu.village);
                        pgcom.Parameters.AddWithValue("b_age", besnu.age);
                        pgcom.Parameters.AddWithValue("b_is_active", besnu.is_active);
                        pgcom.Parameters.AddWithValue("b_updated_by_id", besnu.updated_by_id);
                        pgcom.Parameters.AddWithValue("b_updated_on", besnu.updated_on);

                        await pgcom.ExecuteNonQueryAsync();
                    }

                    return besnu;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteBesnu(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_besnu SET is_active = false WHERE id = @Id";
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


        #endregion
        #region News
        public async Task<Lookup_News> AddNews(Lookup_News news)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();

                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_newsadd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("b_id", news.id);
                        pgcom.Parameters.AddWithValue("b_title", news.title);
                        pgcom.Parameters.AddWithValue("b_description", news.description);
                        pgcom.Parameters.AddWithValue("b_image", news.image);
                        pgcom.Parameters.AddWithValue("b_village", news.village);
                        pgcom.Parameters.AddWithValue("b_datetime", news.dateTime);
                        pgcom.Parameters.AddWithValue("b_is_active", news.is_active);
                        pgcom.Parameters.AddWithValue("b_created_by_id", news.created_by_id);
                        pgcom.Parameters.AddWithValue("b_created_on", news.created_on);

                        await pgcom.ExecuteNonQueryAsync();
                    }
                }
                return news;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Lookup_News> UpdateNews(Lookup_News news)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_newsupdate", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;
                        pgcom.Parameters.AddWithValue("b_id", news.id);
                        pgcom.Parameters.AddWithValue("b_title", news.title);
                        pgcom.Parameters.AddWithValue("b_description", news.description);
                        pgcom.Parameters.AddWithValue("b_image", news.image);
                        pgcom.Parameters.AddWithValue("b_village", news.village);
                        pgcom.Parameters.AddWithValue("b_datetime", news.dateTime);
                        pgcom.Parameters.AddWithValue("b_is_active", news.is_active);
                        pgcom.Parameters.AddWithValue("b_updated_by_id", news.updated_by_id);
                        pgcom.Parameters.AddWithValue("b_updated_on", news.updated_on);
                        await pgcom.ExecuteNonQueryAsync();
                    }
                    return news;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public async Task<bool> DeleteNews(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_news SET is_active = false WHERE id = @Id";
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

        #endregion
        #region Lookup_Delete
        public async Task<bool> DeleteSakh(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_sakh SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteVillage(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_village SET is_active = false WHERE id = @Id";
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



        public async Task<bool> DeleteBloodgroup(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_blood_group SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteBusinessCategory(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_business_category SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteEducationType(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_education_type SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteEducationSubType(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_education_sub_type SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteMaritalType(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_marital_type SET is_active = false WHERE id = @Id";
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



        public async Task<bool> DeleteOccupation(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_occupation SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeletePosition(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_position SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeletePragatimandal(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_pragatimandal SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteRelationtype(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_relation_type SET is_active = false WHERE id = @Id";
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

        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    string sql = "UPDATE lookup_role SET is_active = false WHERE id = @Id";
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
        #endregion
        #region City
        public async Task<Lookup_City> Add(Lookup_City city)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_cityadd", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", city.id);
                    pgcom.Parameters.AddWithValue("p_name", city.name);
                    pgcom.Parameters.AddWithValue("p_lookup_state_id", city.lookup_state_id);
                    pgcom.Parameters.AddWithValue("p_is_active", city.is_active);
                    pgcom.Parameters.AddWithValue("p_created_by_id", city.created_by_id);
                    pgcom.Parameters.AddWithValue("p_created_on", city.created_on);

                    await pgcom.ExecuteNonQueryAsync();
                    return city;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public async Task<bool> DeleteCity(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE lookup_city SET is_active = false WHERE id = @id", pgcon);
                    npgsqlCommand.Parameters.AddWithValue("id", id);
                    await npgsqlCommand.ExecuteNonQueryAsync();
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
        }
        public async Task<Guid> Update(Lookup_City city)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_cityupdate", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", city.id);
                    pgcom.Parameters.AddWithValue("p_name", city.name);
                    pgcom.Parameters.AddWithValue("p_lookup_state_id", city.lookup_state_id);
                    pgcom.Parameters.AddWithValue("p_updated_by_id", city.updated_by_id);
                    pgcom.Parameters.AddWithValue("p_updated_on", city.updated_on);

                    await pgcom.ExecuteNonQueryAsync();
                    return city.id;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        #endregion
        #region Country
        public async Task<Lookup_Country> Add(Lookup_Country country)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_countryadd", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", country.id);
                    pgcom.Parameters.AddWithValue("p_name", country.name);
                    pgcom.Parameters.AddWithValue("p_image", country.image);
                    pgcom.Parameters.AddWithValue("p_code", country.code);
                    pgcom.Parameters.AddWithValue("p_is_active", country.is_active);
                    pgcom.Parameters.AddWithValue("p_created_by_id", country.created_by_id);
                    pgcom.Parameters.AddWithValue("p_created_on", country.created_on);

                    await pgcom.ExecuteNonQueryAsync();
                    return country;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public async Task<bool> DeleteCountry(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE lookup_country SET is_active = false WHERE id = @id", pgcon);
                    npgsqlCommand.Parameters.AddWithValue("id", id);
                    await npgsqlCommand.ExecuteNonQueryAsync();
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
        }
        public async Task<Guid> Update(Lookup_Country country)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_countryupdate", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", country.id);
                    pgcom.Parameters.AddWithValue("p_name", country.name);
                    pgcom.Parameters.AddWithValue("p_image", country.image);
                    pgcom.Parameters.AddWithValue("p_code", country.code);
                    pgcom.Parameters.AddWithValue("p_updated_by_id", country.updated_by_id);
                    pgcom.Parameters.AddWithValue("p_updated_on", country.updated_on);

                    await pgcom.ExecuteNonQueryAsync();
                    return country.id;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        #endregion
        #region State
        public async Task<Lookup_State> Add(Lookup_State state)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_stateadd", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", state.id);
                    pgcom.Parameters.AddWithValue("p_name", state.name);
                    pgcom.Parameters.AddWithValue("p_lookup_country_id", state.lookup_country_id);
                    pgcom.Parameters.AddWithValue("p_is_active", state.is_active);
                    pgcom.Parameters.AddWithValue("p_created_by_id", state.created_by_id);

                    await pgcom.ExecuteNonQueryAsync();
                    return state;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public async Task<bool> DeleteState(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE lookup_state SET is_active = false WHERE id = @id", pgcon);
                    npgsqlCommand.Parameters.AddWithValue("id", id);
                    await npgsqlCommand.ExecuteNonQueryAsync();
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
        }
        public async Task<Guid> Update(Lookup_State state)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_stateupdate", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", state.id);
                    pgcom.Parameters.AddWithValue("p_name", state.name);
                    pgcom.Parameters.AddWithValue("p_lookup_country_id", state.lookup_country_id);
                    pgcom.Parameters.AddWithValue("p_is_active", state.is_active);
                    pgcom.Parameters.AddWithValue("p_updated_by_id", state.updated_by_id);

                    await pgcom.ExecuteNonQueryAsync();
                    return state.id;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        #endregion
    }
}
