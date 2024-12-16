using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using DA_NH.Models;

namespace DA_NH.Services
{
    public class LoginAttemptService
    {
        private readonly IMemoryCache _cache;
        private const int LockoutTimeInMinutes = 1;
        private const int MaxFailedAttempts = 2;

        public LoginAttemptService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool IsLockedOut(string username)
        {
            if (_cache.TryGetValue(username, out LoginAttempt loginAttempt))
            {
                if (loginAttempt.FailedAttempts >= MaxFailedAttempts &&
                    loginAttempt.LastAttempt.AddMinutes(LockoutTimeInMinutes) > DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }

        public void RecordFailedAttempt(string username)
        {
            if (_cache.TryGetValue(username, out LoginAttempt loginAttempt))
            {
                loginAttempt.FailedAttempts++;
                loginAttempt.LastAttempt = DateTime.Now;
                _cache.Set(username, loginAttempt, TimeSpan.FromMinutes(LockoutTimeInMinutes));
            }
            else
            {
                loginAttempt = new LoginAttempt
                {
                    UserName = username,
                    FailedAttempts = 1,
                    LastAttempt = DateTime.Now
                };
                _cache.Set(username, loginAttempt, TimeSpan.FromMinutes(LockoutTimeInMinutes));
            }
        }

        public void ResetFailedAttempts(string username)
        {
            _cache.Remove(username);
        }
    }
}

