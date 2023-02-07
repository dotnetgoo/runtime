﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections.Frozen
{
    /// <summary>
    /// A few numbers to drive implementation selection heuristics.
    /// </summary>
    /// <remarks>
    /// These numbers were arrived through simple benchmarks conducted against .NET 7.
    /// It's worth potentially tweaking these values if the implementation of the
    /// collections changes in a substantial way, or if the JIT improves related code gen over time.
    /// </remarks>
    internal static class Constants
    {
        /// <summary>Threshold when we switch from scanning to hashing for non-value-type or non-default-comparer collections.</summary>
        /// <remarks>
        /// This determines the threshold where we switch from
        /// the scanning-based SmallFrozenDictionary/Set to the hashing-based
        /// DefaultFrozenDictionary/Set.
        /// </remarks>
        public const int MaxItemsInSmallFrozenCollection = 4;

        /// <summary>Threshold when we switch from scanning to hashing value type collections using a default comparer.</summary>
        /// <remarks>
        /// This determines the threshold when we switch from the scanning
        /// SmallValueTypeDefaultComparerFrozenDictionary/Set to the
        /// hashing ValueTypeDefaultComparerFrozenDictionary/Set.
        /// </remarks>
        public const int MaxItemsInSmallComparableValueTypeFrozenCollection = 10;
    }
}
