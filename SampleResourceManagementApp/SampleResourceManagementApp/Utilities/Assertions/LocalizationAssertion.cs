using System;
using JetBrains.Annotations;

namespace SampleResourceManagementApp.Utilities.Assertions
{
    public static class LocalizationAssertion
    {
        public static T NotNull<T>(T value, [System.Diagnostics.CodeAnalysis.NotNull] string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);

            return value;
        }

        public static string NotNullOrWhiteSpace(string value, [System.Diagnostics.CodeAnalysis.NotNull] string parameterName, int maxLength = int.MaxValue, int minLength = 0)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName);

            if (value.Length > maxLength)
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);

            if (minLength > 0 && value.Length < minLength)
                throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);

            return value;
        }


        [ContractAnnotation("value:null => halt")]
        public static string NotNullOrEmpty(
            string value,
            [InvokerParameterName][System.Diagnostics.CodeAnalysis.NotNull] string parameterName,
            int maxLength = int.MaxValue,
            int minLength = 0)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName);

            if (value.Length > maxLength)
                throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);

            if (minLength > 0 && value.Length < minLength)
                throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);

            return value;
        }

    }
}
