using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Collections.Generic;

namespace Pessoa
{
    
    
    /// <summary>
    ///This is a test class for ProdutoDataAccessTest and is intended
    ///to contain all ProdutoDataAccessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProdutoDataAccessTest
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
        ///A test for RetornaProdutosQuantidades
        ///</summary>
        [TestMethod()]
        public void RetornaProdutosQuantidadesTest()
        {
            ProdutoDataAccess target = new ProdutoDataAccess(); // TODO: Initialize to an appropriate value
            DateTime dataInicial = new DateTime(2013, 4, 29);// TODO: Initialize to an appropriate value
            DateTime dataFinal = new DateTime(2013, 4, 30); // TODO: Initialize to an appropriate value
            List<ProdutoRentabilidade> expected = null; // TODO: Initialize to an appropriate value
            List<ProdutoRentabilidade> actual;
            actual = target.RetornaProdutosQuantidades(dataInicial, dataFinal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RetornaProdutosMaisRentaveis
        ///</summary>
        [TestMethod()]
        public void RetornaProdutosMaisRentaveisTest()
        {
            ProdutoDataAccess target = new ProdutoDataAccess(); // TODO: Initialize to an appropriate value
            List<ProdutoRentabilidade> expected = null; // TODO: Initialize to an appropriate value
            List<ProdutoRentabilidade> actual;
            actual = target.RetornaProdutosMaisRentaveis();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
