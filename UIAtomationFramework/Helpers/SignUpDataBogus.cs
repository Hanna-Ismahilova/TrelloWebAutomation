using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using UIAtomationFramework.Base.Models;

namespace UIAtomationFramework.Helpers
    {
    public static class SignUpDataBogus
        {

        public static SignUpModel signUpData;

        public static void SignUpDataGenerator ( )
            {
            var newAccountFaker = new Faker<SignUpModel>()
                     .RuleFor(a => a.SignUpEmail, f => f.Internet.Email())
                     .RuleFor(a => a.SignUpFullName, f => f.Name.FullName())
                     .RuleFor(a => a.SignUpCreatePassword, f => f.Internet.Password());

            }
        }
    }
