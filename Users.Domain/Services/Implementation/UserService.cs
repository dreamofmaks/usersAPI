using Users.Data.Interfaces;
using Users.Data.Model;
using Users.Domain.Services.Interfaces;

namespace Users.Domain.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<Person> unitOfWork;

        public UserService(IUnitOfWork<Person> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Person AddUser(Person person)
        {
            //var newUser = new Person
            //{
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
            //    DateOfBirth = person.DateOfBirth,
            //    AddressNavigation = person.AddressNavigation
            //};
            var user = unitOfWork.GetRepository().Add(person);
            return user;
        }
    }
}
