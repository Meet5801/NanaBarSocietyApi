using Microsoft.AspNetCore.Hosting;
﻿using Microsoft.AspNetCore.Http;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Service.Interfaces;
using System.Net;
using System.Security.Claims;

namespace NanabarSamaj.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IHostingEnvironment _env;

        public MemberService(IMemberRepository memberRepository, IHostingEnvironment env)
        {
            _memberRepository = memberRepository;
            _env = env;
        }

        public async Task<Members> Add(MemberViewModel member)
        {
            try
            {
                string fileName = string.Empty;
                if (!string.IsNullOrEmpty(member.image))
                { 
                    fileName = ConvertImageSave(member.image);
                }
                Members newMember = new Members
                {
                    id = Guid.NewGuid(),
                    lookup_relation_type_id = member.lookup_relation_type_id,
                    surname = member.surname,
                    name = member.name,
                    father_or_husband_name = member.father_or_husband_name,
                    gender = member.gender,
                    phone_number = member.phone_number,
                    email = member.email,
                    dob = member.dob,
                    age = member.age,
                    lookup_village_id = member.lookup_village_id,
                    lookup_sakh_id = member.lookup_sakh_id,
                    address = member.address,
                    lookup_city_id = member.lookup_city_id,
                    lookup_country_id = member.lookup_country_id,
                    lookup_marital_type_id = member.lookup_marital_type_id,
                    lookup_education_sub_type_id = member.lookup_education_sub_type_id,
                    lookup_education_type_id = member.lookup_education_type_id,
                    lookup_occupation_id = member.lookup_occupation_id,
                    designation = member.designation,
                    company = member.company,
                    occupation_address = member.occupation_address,
                    mama_name = member.mama_name,
                    lookup_blood_group_id = member.lookup_blood_group_id,
                    lookup_pragatimandal_id = member.lookup_pragatimandal_id,
                    height_foot = member.height_foot,
                    height_inch = member.height_inch,
                    weight = member.weight,
                    image = fileName,
                    interested_matrimonial = member.interested_matrimonial,
                    interested_blood_donate = member.interested_blood_donate,
                    about_me = member.about_me,
                    is_active = true,
                    created_by_id = Guid.NewGuid(),
                    user_id = member.user_id,
                    you_live_abroad = member.you_live_abroad
                };

                return await _memberRepository.Add(newMember);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding member: " + ex.Message, ex);
            }
        }


        public async Task<bool> Delete(Guid id)
        {
            return await _memberRepository.Delete(id);
        }

        public async Task<List<GetMemberViewModel>> GetAll(GetMemberRequestViewModel getMemberRequestViewModel)
        {
            return await _memberRepository.GetAll(getMemberRequestViewModel);
        }

        public async Task<GetMemberViewModel> GetById(Guid id)
        {
            return await _memberRepository.GetById(id);
        }

        public async Task<Members> Update(MemberViewModel member)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(member.image))
            {
                fileName = ConvertImageSave(member.image);
            }

            Members members = new Members
            {
                id = member.id,
                lookup_relation_type_id = member.lookup_relation_type_id,
                surname = member.surname,
                name = member.name,
                father_or_husband_name = member.father_or_husband_name,
                gender = member.gender,
                phone_number = member.phone_number,
                email = member.email,
                dob = member.dob,
                age = member.age,
                lookup_village_id = member.lookup_village_id,
                lookup_sakh_id = member.lookup_sakh_id,
                address = member.address,
                lookup_city_id = member.lookup_city_id,
                lookup_country_id = member.lookup_country_id,
                lookup_marital_type_id = member.lookup_marital_type_id,
                lookup_education_sub_type_id = member.lookup_education_sub_type_id,
                lookup_education_type_id = member.lookup_education_type_id,
                lookup_occupation_id = member.lookup_occupation_id,
                designation = member.designation,
                company = member.company,
                occupation_address = member.occupation_address,
                mama_name = member.mama_name,
                lookup_blood_group_id = member.lookup_blood_group_id,
                lookup_pragatimandal_id = member.lookup_pragatimandal_id,
                height_foot = member.height_foot,
                height_inch = member.height_inch,
                weight = member.weight,
                image = fileName,
                interested_matrimonial = member.interested_matrimonial,
                interested_blood_donate = member.interested_blood_donate,
                about_me = member.about_me,
                is_active = true,
                updated_by_id = Guid.NewGuid(),
                user_id = member.user_id
            };
            return await _memberRepository.Update(members);
        }
            #region private
            private string SaveImageFromUrl(string imageUrl, string targetFolderPath)
            {
                byte[] imageData;
                using (var client = new WebClient())
                {
                    imageData = client.DownloadData(imageUrl);
                }

                string originalFileName = Path.GetFileName(new Uri(imageUrl).LocalPath);

                string fileName = originalFileName;

                string imagePath = Path.Combine(targetFolderPath, fileName);

                File.WriteAllBytes(imagePath, imageData);

                return fileName;
            }

        private string ConvertImageSave(string imageUrl)
        {
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "Members");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "Members", fileName);

            return relativePath;
        }


        #endregion
    }
}
