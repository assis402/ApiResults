﻿using ApiResults.CustomAttributes;
using FluentValidation.Results;
using System.ComponentModel;
using System.Net;

namespace ApiResults.Helpers
{
    /// <summary>
    /// Class <c>Utils</c> has internal utility methods to assist in creating api responses.
    /// </summary>
    public static class Extensions
    {
        public static string Description(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        internal static HttpStatusCode StatusCode(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (StatusCodeAttribute[])fieldInfo.GetCustomAttributes(typeof(StatusCodeAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Code;
            else
                return HttpStatusCode.OK;
        }

        internal static IEnumerable<string> CastToString(this IEnumerable<ValidationFailure> validationFailures)
            => validationFailures.Select(x => x.ToString());
    }
}