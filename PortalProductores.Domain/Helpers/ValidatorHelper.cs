using PortalProductores.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace PortalProductores.Domain.Helpers
{
    public static class ValidatorHelper
    {
        public static void ValidateNullObject<T>([NotNull] this T obj, string message)
            where T : class
        {
            if (obj is null)
            {
                throw new AppException(message);
            }
        }

        public static void ValidateNullOrAnyList<T>([NotNull] this IEnumerable<T> list, string message)
        {
            if (list is null || !list.Any())
            {
                throw new AppException(message);
            }
        }

        public static void ValidateNullOrEmptyString(this string value, string message)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new AppException(message);
            }
        }

        public static void ValidateByteEmpty(this byte value, string message)
        {
            if (value < 0)
            {
                throw new AppException(message);
            }
        }

        public static void ValidateInvalidId(this int value)
        {
            if (value < 0)
            {
                throw new AppException(MessagesExceptions.InvalidId);
            }
        }
    }
}
