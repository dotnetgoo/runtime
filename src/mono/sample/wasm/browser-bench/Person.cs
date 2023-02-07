// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Sample
{
    public class Person
    {
        static readonly string[] Clearances = new[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };

        public string Name { get; set; }
        public int Salary { get; set; }
        public bool IsAdmin { get; set; }
        public List<Person> Subordinates { get; set; }
        public Dictionary<string, object> SecurityClearances { get; set; }

        public static Person GenerateOrgChart(int totalDepth, int numDescendantsPerNode, int thisDepth = 0, string namePrefix = null, int siblingIndex = 0)
        {

            var name = $"{namePrefix ?? "CEO"} - Subordinate {siblingIndex}";
            var rng = new Random(0);
            return new Person
            {
                Name = name,
                IsAdmin = siblingIndex % 2 == 0,
                Salary = 10000000 / (thisDepth + 1),
                SecurityClearances = Clearances
                    .ToDictionary(c => c, _ => (object)(rng.Next(0, 2) == 0)),
                Subordinates = Enumerable.Range(0, thisDepth < totalDepth ? numDescendantsPerNode : 0)
                    .Select(index => GenerateOrgChart(totalDepth, numDescendantsPerNode, thisDepth + 1, name, index))
                    .ToList()
            };
        }
    }

    class TextContainer
    {
        public string Text { get; set; }
    }

    [JsonSerializable(typeof(TextContainer))]
    [JsonSerializable(typeof(Person))]
    [JsonSerializable(typeof(List<Person>))]
    [JsonSerializable(typeof(Dictionary<string, object>))]
    partial class TestSerializerContext : JsonSerializerContext { }

}
