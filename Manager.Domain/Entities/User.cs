using Manager.Domain.Validators;
using System;
using System.Collections.Generic;
using Manager.Utils.Constants.Entitites.User;
using System.Linq;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        /// <summary>
        /// The attribute is private because we will only change the values ​​through methods, and we will be able to validate this data.
        /// </summary>
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        // EntityFramework
        protected User() { }

        /// <summary>
        /// method alter name
        /// </summary>
        /// <param name="name"></param>
        public void ChangeName(string name)
        {
            Name = name;
            Validade();
        }

        /// <summary>
        /// method alter password
        /// </summary>
        /// <param name="password"></param>
        public void ChangePassowrd(string password)
        {
            Password = password;
            Validade();
        }

        /// <summary>
        /// method alter passowrd
        /// </summary>
        /// <param name="email"></param>
        public void ChangeEmail(string email)
        {
            Email = email;
            Validade();
        }

        /// <summary>
        /// Auto validate
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override bool Validade()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new Exception(UserConstants.EXCEPTION_VALIDATOR + _errors.FirstOrDefault());
            }

            return validation.IsValid;
        }
    }
}
