using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantApp.BOL;
using ResturantApp.DAL;
using Repository;
using Repository.UnitOfWork;
using Xunit;

namespace ResturantApp.Tests
{
    public class CustomerTests
    {
        //[Fact]
        public async void InsertCustomer_ShouldInsert()
        {
            //Arrange
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            Customer customer = new Customer
            {
                FirstName = "Biola",
                LastName = "Kolawole",
                Phone = "23480789346",
                Mobile = "23480789078",
                OfficePhone = "23470456798",
                Email = "kollyk@yahoo.com",
                Fax = "Test",
                Remarks = "Test",
                Address = "234, Alarere Street, Lagos"
            };
            int expectedResult = 1;

            //Act
            unitOfWork.Customers.Add(customer);
            int rsult = await unitOfWork.Complete();

            //Assert
            Assert.Equal(expectedResult, rsult);
        }

        //[Fact]
        //public async void CustomerGetAll_ShouldGet()
        //{
        //    //Arrange
        //    var unitOfWork = new UnitOfWork(new RestaurantContext());
        //    int expectedValue = 3;

        //    //Act
        //    var actualValue = await unitOfWork.Customers.GetAll();

        //    //Assert
        //    Assert.Equal(expectedValue, actualValue);
        //}

        [Fact]
        public async void CustomerGetSingle_ShouldGet()
        {
            //Arrange
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            Customer expectedValue = null;
            //Customer expectedValue = unitOfWork.Customers.GetAll()
            //    .Single(x => x.CusID == 2);

            //Act
            //int actualValue = unitOfWork.Customers.GetAll()
            //    .Where(x => x.CusID == 1).Count();
            Customer actualValue = await unitOfWork.Customers.GetAsync(7);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

        //[Fact]
        public async void CustomerUpdate_ShouldPass()
        {
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            Customer fetchCustomer = await unitOfWork.Customers.GetAsync(1);
            fetchCustomer.FirstName = "Adekunle";
            fetchCustomer.LastName = "Fajuyi";
            unitOfWork.Customers.Update(fetchCustomer);
            int actual = await unitOfWork.Complete();
            Assert.True(actual == 1);
        }

        //[Fact]
        public async void CustomerAddRange_ShouldPass()
        {
            //Arrange
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            List<Customer> Customers = new List<Customer>()
            {
                new Customer
                {
                     FirstName = "Jumoke",
                     LastName = "Akinyo",
                     Phone = "23480730916",
                     Mobile = "23480330985",
                     OfficePhone = "23478777962",
                     Email = "jummylee@yahoo.com",
                     Fax = "Test",
                     Remarks = "Test",
                     Address = "4587, Alakia Street, Ibadan"

                },
                 new Customer
                {
                     FirstName = "Lukman",
                     LastName = "Arasi",
                     Phone = "23480730916",
                     Mobile = "23480330985",
                     OfficePhone = "23478777962",
                     Email = "Lookzo@gmail.com",
                     Fax = "Test",
                     Remarks = "Test",
                     Address = "4587, Alakia Street, Ibadan"

                }
            };

            //Act
            unitOfWork.Customers.AddRange(Customers);
            int actual = await unitOfWork.Complete();

            //Assert
            Assert.True(actual > 0);

        }
        
        //[Fact]
        public async void CustomerRemoveOne_ShouldPass()
        {
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            Customer fetchCustomer = await unitOfWork.Customers.GetAsync(1);

            unitOfWork.Customers.Remove(fetchCustomer);
            int actual = await unitOfWork.Complete();

            Assert.True(actual > 0);
        }

        //[Fact]
        public async void CustomerRemoveRange_ShouldPass()
        {
            var unitOfWork = new UnitOfWork(new RestaurantContext());
            //IEnumerable<Customer> customers = await unitOfWork.Customers.GetAll()
            List<Customer> customers = unitOfWork.Customers.Find(x => x.Email == "kollyk@yahoo.com").ToList();
            unitOfWork.Customers.RemoveRange(customers);
            int actual = await unitOfWork.Complete();

            Assert.True(actual == 0);
        }
    }
}
