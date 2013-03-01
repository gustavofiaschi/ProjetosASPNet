using Ecommerce.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ecommerce.Database;
using System.Collections.Generic;

namespace BusinessUnitTest
{
    
    
    /// <summary>
    ///This is a test class for UsuarioBusinessTest and is intended
    ///to contain all UsuarioBusinessTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioBusinessTest
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
        ///A test for ListarUsuarios
        ///</summary>
        [TestMethod()]
        public void ListarUsuariosTest()
        {
            UsuarioBusiness target = new UsuarioBusiness(); // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ListarUsuarios().Count;
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///A test for UsuarioBusiness Constructor
        ///</summary>
        [TestMethod()]
        public void UsuarioBusinessConstructorTest()
        {
            UsuarioBusiness target = new UsuarioBusiness();            
        }
    }
}
