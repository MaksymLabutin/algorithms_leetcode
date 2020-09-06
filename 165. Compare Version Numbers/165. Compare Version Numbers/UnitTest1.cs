using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var version1 = "0.1"; 
            var version2 = "1.1";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void Test2()
        {
            var version1 = "1.0.1"; 
            var version2 = "1";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void Test3()
        {
            var version1 = "7.5.2.4"; 
            var version2 = "7.5.3";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void Test4()
        {
            var version1 = "1.01"; 
            var version2 = "1.001";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Test5()
        {
            var version1 = "1.0"; 
            var version2 = "1.0.0";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Test6()
        {
            var version1 = ""; 
            var version2 = "";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(0, actual);
        } 

        [Test]
        public void Test7()
        {
            var version1 = ""; 
            var version2 = "1";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void Test8()
        {
            var version1 = ""; 
            var version2 = "0";

            var actual = CompareVersion(version1, version2);

            Assert.AreEqual(0, actual);
        }

        public int CompareVersion(string version1, string version2)
        {
            if (string.IsNullOrEmpty(version1) && string.IsNullOrEmpty(version2)) return 0;


            var versions = GetListOfVersions(version1, version2);

            for (var i = 0; i < versions.v1.Count; i++)
            {
                if (versions.v1[i] > versions.v2[i]) return 1;
                else if (versions.v1[i] < versions.v2[i]) return -1;
            }

            return 0;
        }

        private (List<int> v1, List<int> v2) GetListOfVersions(string version1, string version2)
        {
            var v1 = string.IsNullOrEmpty(version1) ? new List<int>() : version1.Split('.').Select(int.Parse).ToList();
            var v2 = string.IsNullOrEmpty(version2) ? new List<int>() :  version2.Split('.').Select(int.Parse).ToList();

            while (v1.Count != v2.Count)
            {
                if(v1.Count > v2.Count) v2.Add(0);
                else v1.Add(0);
            }

            return (v1, v2);
        }
    }
}