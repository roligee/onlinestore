using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineStore.Domain.Models;
using BlastAsia.Infra.Specifications;
using System.Collections.Generic;
using BlastAsia.Infra;

namespace OnlineStore.Domain.Test
{
    [TestClass]
    public class LoginManagerTest
    {
        [TestMethod]
        public void LoginWithValidCredentials()
        {
            // Arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var username = "rsaberon@blastasia.com";
            var password = "Bl@st123";
            var employee = new Employee
            {
                UserName = username,
                Password = password
            };
        
            mockEmployeeRepository.Setup(
                    r => r.Find(It.IsAny<ISpecification<Employee>>()))
                .Returns(new List<Employee>{ employee });
                
                       
            var sut = new LoginManager(mockEmployeeRepository.Object);


            // Act
            var result = sut.Login(username, password);

            // Assert
            Assert.AreEqual("Login successful!", result);

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void LoginWithBlankUserNameThrowsException()
        {
            // arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(
                r => r.Find(It.IsAny<ISpecification<Employee>>()))
                .Returns(new List<Employee>());

            IEmployeeRepository repository = mockEmployeeRepository.Object;
            var sut = new LoginManager(repository);

            // act
            var result = sut.Login(string.Empty, string.Empty);
            
        }

        [TestMethod]
        public void LoginBlankUserNameShouldNotCallRepositoryFind()
        {
            // arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            mockEmployeeRepository.Setup(
                r => r.Find(It.IsAny<ISpecification<Employee>>()))
                .Returns(new List<Employee>());

            IEmployeeRepository repository = mockEmployeeRepository.Object;
            var sut = new LoginManager(repository);

            // act
            var result = sut.Login(string.Empty, "Bl@st123");

            // Assert
            mockEmployeeRepository.Verify(r => r.Find(It.IsAny<ISpecification<Employee>>()), Times.Never);

        }



        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void LoginWithInvalidPasswordThrowsException()
        {
            // arrange
            var mockEmployeeRepository = new Mock<IEmployeeRepository>();
            var employee = new Employee
            {
                UserName = "rsaberon@blastasia.com",
                Password = "Bl@st123"
            };
            mockEmployeeRepository.Setup(
                r => r.Find(It.IsAny<ISpecification<Employee>>()))
                .Returns(new List<Employee> { employee });

            IEmployeeRepository repository = mockEmployeeRepository.Object;
            var sut = new LoginManager(repository);

            // act
            var result = sut.Login("rsaberon@blastasia.com", "WrongPassword");

        }
    }
}
