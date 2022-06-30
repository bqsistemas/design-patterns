using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestingCode.Attributes
{
    public class HealthDamageDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string[] csvLines = File.ReadAllLines("Data\\TestData.csv");

            var testCases = new List<object[]>();

            foreach (var csvLine in csvLines)
            {
                IEnumerable<int> values = csvLine.Split(',').Select(int.Parse);

                object[] testCase = values.Cast<object>().ToArray();

                testCases.Add(testCase);
            }

            return testCases;
        }
    }
}
