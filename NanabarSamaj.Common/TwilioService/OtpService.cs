using Microsoft.Extensions.Configuration;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2;
using Twilio.Rest.Verify.V2.Service;
using Twilio.TwiML.Voice;

namespace NanabarSamaj.Common.OtpService
{
    public class OtpService : IOtpService
    {
        public IConfiguration _configuration;

        static string accountSid = string.Empty;
        static string authToken = string.Empty;
        static string verificationCode = string.Empty;

        public OtpService(IConfiguration configuration)
        {
            _configuration = configuration;
            accountSid = _configuration["TwilioSettings:TwilioAccountSid"].ToString();
            authToken = _configuration["TwilioSettings:TwilioAuthToken"].ToString();
            verificationCode = _configuration["TwilioSettings:TwilioVerificationCode"].ToString();
        }

        public async Task<VerificationResource> SendOTP(string phoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);

            return VerificationResource.Create(
                to: phoneNumber,
                channel: "sms",
                pathServiceSid: verificationCode //verificationCode
            );
        }

        public async Task<VerificationCheckResource> VerifiyOTP(string phoneNumber, string otp)
        {
            TwilioClient.Init(accountSid, authToken);

            return VerificationCheckResource.Create(
                to: phoneNumber,
                code: otp,
                pathServiceSid: verificationCode
            );
        }

    }
}


