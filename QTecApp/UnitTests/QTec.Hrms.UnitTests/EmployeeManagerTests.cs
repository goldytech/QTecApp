using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QTec.Hrms.UnitTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Microsoft.Practices.Unity;

    using QTec.Hrms.Business.CustomExceptions;
    using QTec.Hrms.Business.Personal;
    using QTec.Hrms.DataTier;
    using QTec.Hrms.DataTier.Contracts;
    using QTec.Hrms.DataTier.Repositories;
    using QTec.Hrms.Models;
    using QTec.Hrms.Models.Dto;

    using Telerik.JustMock;

    /// <summary>
    /// The employee manager tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EmployeeManagerTests
    {
        /// <summary>
        /// The container.
        /// </summary>
        private IUnityContainer container;
        [TestInitialize]
        public void Setup()
        {

            container = BuildUnityContainer();
            


        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            

            container.RegisterInstance(typeof(RepositoryFactories), new RepositoryFactories());
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IQTecUnitOfWork, QTecUnitOfWork>();

            return container;
        }
        [TestMethod]
        public void DesignationsList_Cannot_Be_Null()
        {
            // ARRANGE
            var uow = Mock.Create<IQTecUnitOfWork>();
            var expectedDesignations = new List<Designation>
                                           {
                                               new Designation { Id = 1, Name = "HR" },
                                               new Designation { Id = 2, Name = "Finance" }
                                           };
            var queryableDesignations = expectedDesignations.AsQueryable();
            Mock.Arrange(() => uow.DesignationRepository.GetAll()).Returns(queryableDesignations);
            
            var classUnderTest = new EmployeeManager(uow);

            // ACT
            var returnValues = classUnderTest.GetDesignations();

            // ASSERT
            Assert.IsNotNull(returnValues);


        }

        [TestMethod]
        public void Assert_False_If_Email_Does_Not_Exists()
        {
            //var uow = Mock.Create<IQTecUnitOfWork>();
            //Mock.Arrange(() => uow.EmployeeRepository.IsEmailDuplicate("afzal@quipment.in")).CallOriginal();
            var svcLocator = new UnityServiceLocator(container);
           var uow = svcLocator.GetInstance<IQTecUnitOfWork>();
               
            var classunderTest = new EmployeeManager(uow);

            const bool ExpectedValue = false;
            var actualValue = classunderTest.IsEmailUnique("afzal@quipment.in");

            Assert.AreEqual(ExpectedValue,actualValue);
        }

        [TestMethod]
        public void Valid_Employee_Should_Be_Returned_When_Requested()
        {
            // ARRANGE
            var expectedEmployee = new Employee
                                       {
                                           EmployeeId = 1, 
                                           DateOfBirth = new DateTime(1998, 2, 3), 
                                           DesignationId = 2
                                       };

            var uow = Mock.Create<IQTecUnitOfWork>(Behavior.Loose);
            Mock.Arrange(() => uow.EmployeeRepository.GetById(Arg.AnyInt)).Returns(expectedEmployee);

            // ACT
            var classunderTest = new EmployeeManager(uow);

            // ASSERT
            var actualEmployee = classunderTest.GetEmployeeById(1);

            Assert.AreEqual(expectedEmployee, actualEmployee);


        }

        [TestMethod]
        public void Exception_Must_Be_Thrown_If_EmployeeId_Zero()
        {
            // ARRANGE
            var uow = Mock.Create<IQTecUnitOfWork>(Behavior.Loose);
            
            // ACT
            var classunderTest = new EmployeeManager(uow);

            Employee actualEmployee = null;
            try
            {
                 actualEmployee = classunderTest.GetEmployeeById(0);
            }
            catch (InvalidEmployeeIdException)
            {
                // ASSERT
    
                Mock.Assert(classunderTest);
                Assert.IsNull(actualEmployee);
                
            }

        }

        [TestMethod]
        public void CheckIfEmployeePersonalDetailsIsSaved()
        {
            // ARRANGE
            var uow = Mock.Create<IQTecUnitOfWork>(Behavior.Loose);

            var employeeToBeUpdated = new Employee
            {
                DateOfBirth = new DateTime(2012, 1, 1), 
                DesignationId = 2, 
                Email = "abc@domain.com", 
                FirstName = "Abc", 
                LastName = "XYZ"
            };

             var employeePersonalDtoinParamater = new EmployeePersonalInfo
                                                {
                                                    DateOfBirth = new DateTime(2012, 1, 1), 
                                                    DesignationId = 2, 
                                                    Email = "abc@domain.com", 
                                                    FirstName = "AbcDef", //firstname is changed
                                                    LastName = "XYZ"
                                                };
            Mock.Arrange(() => uow.EmployeeRepository.GetById(Arg.AnyInt)).Returns(employeeToBeUpdated);

            Mock.Arrange(() => uow.EmployeeRepository.Update(Arg.IsAny<Employee>()))
                .DoInstead(() => { employeeToBeUpdated.FirstName = employeePersonalDtoinParamater.FirstName; })
                .OccursOnce();

            Mock.Arrange(() => uow.EmployeeLanguagesRepository.GetAll()).DoNothing();

            // ACT
            var classunderTest = new EmployeeManager(uow);
            classunderTest.SaveEmployee(1, employeePersonalDtoinParamater, null);


            // ASSERT
            Assert.AreEqual("AbcDef", employeeToBeUpdated.FirstName);
            Mock.Assert(uow);
        }

        [TestMethod]
        public void CheckWhetherLanguagesAreGettingUpdatedInEmployeeSave()
        {
            // ARRANGE
            var uow = Mock.Create<IQTecUnitOfWork>(Behavior.Loose);

            var employeeToBeUpdated = new Employee
            {
                DateOfBirth = new DateTime(2012, 1, 1),
                DesignationId = 2,
                Email = "abc@domain.com",
                FirstName = "Abc",
                LastName = "XYZ"
            };

            var employeePersonalDtoinParamater = new EmployeePersonalInfo
            {
                DateOfBirth = new DateTime(2012, 1, 1),
                DesignationId = 2,
                Email = "abc@domain.com",
                FirstName = "AbcDef", // firstname is changed
                LastName = "XYZ"
            };
            Mock.Arrange(() => uow.EmployeeRepository.GetById(Arg.AnyInt)).Returns(employeeToBeUpdated);

            var currentEmployeeLanguagesKnown = new List<EmployeeLanguages>
                                                    {
                                                        new EmployeeLanguages
                                                            {
                                                                EmployeeId = 1,
                                                                Fluency = 1,
                                                                LanguageId = 1
                                                            },
                                                        new EmployeeLanguages
                                                            {
                                                                EmployeeId = 1,
                                                                Fluency = 1,
                                                                LanguageId = 2
                                                            }
                                                    };

            Mock.Arrange(() => uow.EmployeeLanguagesRepository.GetAll()).Returns(currentEmployeeLanguagesKnown.AsQueryable);

            //// updating fluency from 1 to 2
            var employeeLanguagesInfoParamater = new List<EmployeeLanguageInfo>
                                                     {
                                                         new EmployeeLanguageInfo
                                                             {
                                                                 EmployeeId = 1,
                                                                 Fluency = (Fluency)2,
                                                                 LanguageId = 1
                                                             },
                                                         new EmployeeLanguageInfo
                                                             {
                                                                 EmployeeId = 1,
                                                                 Fluency = (Fluency)2,
                                                                 LanguageId = 2
                                                             }
                                                     };

            Mock.Arrange(() => uow.EmployeeLanguagesRepository.Update(Arg.IsAny<EmployeeLanguages>())).DoInstead(
                () =>
                    {
                        foreach (var employeeLanguageInfo in employeeLanguagesInfoParamater)
                        {
                            var languageToBeUpdated =
                                currentEmployeeLanguagesKnown.FirstOrDefault(
                                    lang => lang.EmployeeId == 1 && lang.LanguageId == employeeLanguageInfo.LanguageId);

                            if (languageToBeUpdated != null)
                            {
                                languageToBeUpdated.Fluency = (int)employeeLanguageInfo.Fluency;
                               
                            }
                        }
                    });

            // ACT
            var classunderTest = new EmployeeManager(uow);
            classunderTest.SaveEmployee(1, employeePersonalDtoinParamater, employeeLanguagesInfoParamater);


            // ASSERT
            var firstOrDefault = currentEmployeeLanguagesKnown.FirstOrDefault();
            if (firstOrDefault != null)
            {
                Assert.AreEqual(2, firstOrDefault.Fluency);
            }

            Mock.Assert(uow);
        }
    }
}
