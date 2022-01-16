﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SampleResourceManagementApp.Utilities.Assertions;

namespace SampleResourceManagementApp.Localization.Collections.CollectionExtensions
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Adds an item to the collection if it's not already in the collection.
        /// </summary>
        /// <param name="source">The collection</param>
        /// <param name="item">Item to check and add</param>
        /// <typeparam name="T">Type of the items in the collection</typeparam>
        /// <returns>Returns True if added, returns False if not.</returns>
        public static bool AddIfNotContains<T>([NotNull] this ICollection<T> source, T item)
        {
            LocalizationAssertion.NotNull(source, nameof(source));

            if (source.Contains(item))
                return false;

            source.Add(item);
            return true;
        }
    }
}
