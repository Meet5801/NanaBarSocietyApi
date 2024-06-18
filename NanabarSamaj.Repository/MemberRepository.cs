using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using Npgsql;
using System.Data;
using System.Net.Http;
using System.Security.Claims;

namespace NanabarSamaj.Repository
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MemberRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(configuration)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Members> Add(Members member)
        {
            try
            {
                using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
                {
                    await pgcon.OpenAsync();
                    using (NpgsqlCommand pgcom = new NpgsqlCommand("proc_memberadd", pgcon))
                    {
                        pgcom.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        pgcom.Parameters.AddWithValue("p_id", member.id);
                        pgcom.Parameters.AddWithValue("p_lookup_relation_type_id", member.lookup_relation_type_id);
                        pgcom.Parameters.AddWithValue("p_surname", member.surname);
                        pgcom.Parameters.AddWithValue("p_name", member.name);
                        pgcom.Parameters.AddWithValue("p_father_or_husband_name", member.father_or_husband_name);
                        pgcom.Parameters.AddWithValue("p_gender", member.gender);
                        pgcom.Parameters.AddWithValue("p_phone_number", member.phone_number);
                        pgcom.Parameters.AddWithValue("p_email", member.email);
                        pgcom.Parameters.AddWithValue("p_dob", member.dob);
                        pgcom.Parameters.AddWithValue("p_age", member.age);
                        pgcom.Parameters.AddWithValue("p_lookup_village_id", member.lookup_village_id);
                        pgcom.Parameters.AddWithValue("p_lookup_sakh_id", member.lookup_sakh_id);
                        pgcom.Parameters.AddWithValue("p_address", member.address);
                        pgcom.Parameters.AddWithValue("p_lookup_city_id", member.lookup_city_id);
                        pgcom.Parameters.AddWithValue("p_lookup_country_id", member.lookup_country_id);
                        pgcom.Parameters.AddWithValue("p_lookup_marital_type_id", member.lookup_marital_type_id);
                        pgcom.Parameters.AddWithValue("p_lookup_education_type_id", member.lookup_education_type_id);
                        pgcom.Parameters.AddWithValue("p_lookup_education_sub_type_id", member.lookup_education_sub_type_id);
                        pgcom.Parameters.AddWithValue("p_lookup_occupation_id", member.lookup_occupation_id);
                        pgcom.Parameters.AddWithValue("p_designation", member.designation);
                        pgcom.Parameters.AddWithValue("p_company", member.company);
                        pgcom.Parameters.AddWithValue("p_occupation_address", member.occupation_address);
                        pgcom.Parameters.AddWithValue("p_mama_name", member.mama_name);
                        pgcom.Parameters.AddWithValue("p_lookup_blood_group_id", member.lookup_blood_group_id);
                        pgcom.Parameters.AddWithValue("p_lookup_pragatimandal_id", member.lookup_pragatimandal_id);
                        pgcom.Parameters.AddWithValue("p_height_foot", member.height_foot);
                        pgcom.Parameters.AddWithValue("p_height_inch", member.height_inch);
                        pgcom.Parameters.AddWithValue("p_weight", member.weight);
                        pgcom.Parameters.AddWithValue("p_image", member.image);
                        pgcom.Parameters.AddWithValue("p_interested_matrimonial", member.interested_matrimonial);
                        pgcom.Parameters.AddWithValue("p_interested_blood_donate", member.interested_blood_donate);
                        pgcom.Parameters.AddWithValue("p_about_me", member.about_me);
                        pgcom.Parameters.AddWithValue("p_is_active", member.is_active);
                        pgcom.Parameters.AddWithValue("p_created_by_id", member.created_by_id);
                        pgcom.Parameters.AddWithValue("p_user_id", member.user_id);
                        pgcom.Parameters.AddWithValue("p_you_live_abroad", member.you_live_abroad);

                        await pgcom.ExecuteNonQueryAsync();
                    }
                }
                return member;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding member: " + ex.Message, ex);
            }
        }



        public async Task<bool> Delete(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("UPDATE members SET is_active = false WHERE id = @id", pgcon);
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

        public async Task<List<GetMemberViewModel>> GetAll(GetMemberRequestViewModel getMemberRequestViewModel)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    var queryParameters = new
                    {
                        p_user_id = getMemberRequestViewModel.user_id,
                        p_page_number = getMemberRequestViewModel.page_number,
                        p_page_size = getMemberRequestViewModel.page_size,
                        p_age = getMemberRequestViewModel.age,
                        p_education = getMemberRequestViewModel.education,
                        p_occupation = getMemberRequestViewModel.occupation,
                        p_gender = getMemberRequestViewModel.gender,
                        p_you_live_abroad = getMemberRequestViewModel.you_live_abroad,
                        p_marital = getMemberRequestViewModel.marital,
                        p_height = getMemberRequestViewModel.height,
                        p_weight = getMemberRequestViewModel.weight,
                        p_interested_matrimonial = getMemberRequestViewModel.interested_matrimonial
                    };

                    var userList = await pgcon.QueryAsync<GetMemberViewModel>(
                        "SELECT * FROM proc_memberget(@p_page_number, @p_page_size, @p_user_id, @p_age, @p_education, @p_occupation, @p_gender, @p_you_live_abroad, @p_marital, @p_height, @p_weight, @p_interested_matrimonial)",
                        queryParameters);

                    return userList.AsList();
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

        public async Task<GetMemberViewModel> GetById(Guid id)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    pgcon.Open();
                    NpgsqlCommand pgcom = new NpgsqlCommand();
                    var result = await pgcon.QueryFirstOrDefaultAsync<GetMemberViewModel>(
                             "SELECT * FROM proc_membergetbyid(@id)",
                             new { id = id });
                    return result;
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

        public async Task<Members> Update(Members member)
        {
            using (NpgsqlConnection pgcon = new NpgsqlConnection(con.ConnectionString))
            {
                try
                {
                    await pgcon.OpenAsync();
                    NpgsqlCommand pgcom = new NpgsqlCommand("proc_memberupdate", pgcon);
                    pgcom.CommandType = CommandType.StoredProcedure;

                    pgcom.Parameters.AddWithValue("p_id", member.id);
                    pgcom.Parameters.AddWithValue("p_lookup_relation_type_id", member.lookup_relation_type_id);
                    pgcom.Parameters.AddWithValue("p_surname", member.surname);
                    pgcom.Parameters.AddWithValue("p_name", member.name);
                    pgcom.Parameters.AddWithValue("p_father_or_husband_name", member.father_or_husband_name);
                    pgcom.Parameters.AddWithValue("p_gender", member.gender);
                    pgcom.Parameters.AddWithValue("p_phone_number", member.phone_number);
                    pgcom.Parameters.AddWithValue("p_email", member.email);
                    pgcom.Parameters.AddWithValue("p_dob", member.dob);
                    pgcom.Parameters.AddWithValue("p_age", member.age);
                    pgcom.Parameters.AddWithValue("p_lookup_village_id", member.lookup_village_id);
                    pgcom.Parameters.AddWithValue("p_lookup_sakh_id", member.lookup_sakh_id);
                    pgcom.Parameters.AddWithValue("p_address", member.address);
                    pgcom.Parameters.AddWithValue("p_lookup_city_id", member.lookup_city_id);
                    pgcom.Parameters.AddWithValue("p_lookup_country_id", member.lookup_country_id);
                    pgcom.Parameters.AddWithValue("p_lookup_marital_type_id", member.lookup_marital_type_id);
                    pgcom.Parameters.AddWithValue("p_lookup_education_type_id", member.lookup_education_type_id);
                    pgcom.Parameters.AddWithValue("p_lookup_education_sub_type_id", member.lookup_education_sub_type_id);
                    pgcom.Parameters.AddWithValue("p_lookup_occupation_id", member.lookup_occupation_id);
                    pgcom.Parameters.AddWithValue("p_designation", member.designation);
                    pgcom.Parameters.AddWithValue("p_company", member.company);
                    pgcom.Parameters.AddWithValue("p_occupation_address", member.occupation_address);
                    pgcom.Parameters.AddWithValue("p_mama_name", member.mama_name);
                    pgcom.Parameters.AddWithValue("p_lookup_blood_group_id", member.lookup_blood_group_id);
                    pgcom.Parameters.AddWithValue("p_lookup_pragatimandal_id", member.lookup_pragatimandal_id);
                    pgcom.Parameters.AddWithValue("p_height_foot", member.height_foot);
                    pgcom.Parameters.AddWithValue("p_height_inch", member.height_inch);
                    pgcom.Parameters.AddWithValue("p_weight", member.weight);
                    pgcom.Parameters.AddWithValue("p_image", member.image);
                    pgcom.Parameters.AddWithValue("p_interested_matrimonial", member.interested_matrimonial);
                    pgcom.Parameters.AddWithValue("p_interested_blood_donate", member.interested_blood_donate);
                    pgcom.Parameters.AddWithValue("p_about_me", member.about_me);
                    pgcom.Parameters.AddWithValue("p_is_active", member.is_active);
                    pgcom.Parameters.AddWithValue("p_updated_by_id", member.updated_by_id);
                    pgcom.Parameters.AddWithValue("p_user_id", member.user_id);
                    pgcom.Parameters.AddWithValue("p_you_live_abroad", member.you_live_abroad);

                    await pgcom.ExecuteNonQueryAsync();
                    return member;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while updating member: " + ex.Message, ex);
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