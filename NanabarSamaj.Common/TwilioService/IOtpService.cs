using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Verify.V2.Service;

namespace NanabarSamaj.Common.OtpService
{
    public interface IOtpService
    {
        Task<VerificationResource> SendOTP(string phoneNumber);

        Task<VerificationCheckResource> VerifiyOTP(string phoneNumber, string otp);
    }
}
