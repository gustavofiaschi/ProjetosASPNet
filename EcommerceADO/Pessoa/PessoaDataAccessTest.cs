using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Collections.Generic;

namespace Pessoa
{
    
    
    /// <summary>
    ///This is a test class for PessoaDataAccessTest and is intended
    ///to contain all PessoaDataAccessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PessoaDataAccessTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for RetornaPessoasGastos
        ///</summary>
        [TestMethod()]
        public void RetornaPessoasGastosTest()
        {
            PessoaDataAccess target = new PessoaDataAccess(); // TODO: Initialize to an appropriate value
            DateTime dataInicial = new DateTime(2013, 4, 29);// TODO: Initialize to an appropriate value
            DateTime dataFinal = new DateTime(2013, 4, 30); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.RetornaPessoasGastos(dataInicial, dataFinal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RetornaPessoasRank
        ///</summary>
        [TestMethod()]
        public void RetornaPessoasRankTest()
        {
            PessoaDataAccess target = new PessoaDataAccess(); // TODO: Initialize to an appropriate value
            List<PessoaGasto> expected = null; // TODO: Initialize to an appropriate value
            List<PessoaGasto> actual;
            actual = target.RetornaPessoasRanqueadas();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
