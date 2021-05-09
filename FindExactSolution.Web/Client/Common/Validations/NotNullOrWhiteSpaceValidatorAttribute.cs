﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FindExactSolution.Web.Client.Common.Validations
{
    public class NotNullOrWhiteSpaceValidatorAttribute : ValidationAttribute
    {
        public NotNullOrWhiteSpaceValidatorAttribute() : base("Invalid Field") { }
        public NotNullOrWhiteSpaceValidatorAttribute(string Message) : base(Message) { }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            if (string.IsNullOrWhiteSpace(value.ToString())) return false;

            return true;
        }

        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            if (IsValid(value)) return ValidationResult.Success;
            return new ValidationResult("Value cannot be empty or white space.");
        }
    }
}
