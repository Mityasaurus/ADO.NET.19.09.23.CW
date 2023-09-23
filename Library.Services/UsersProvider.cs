using Library.DAL.SQL.Entity;
using Library.DAL.SQL.Repositories;

namespace Library.Services
{
    public class UsersProvider
    {
        private readonly IRepository<User> _repository;

        public UsersProvider(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void AddUser(User user)
        {
            _repository.Add(user);
        }

        public void AddUsers(List<User> users)
        {
            users.ForEach(user => _repository.Add(user));
        }

        public User GetUserByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public void Remove(User user)
        {
            _repository.Remove(user);
        }

        public void Update(int id, User user)
        {
            _repository.Update(id, user);
        }

        public IEnumerable<User> GetUsersByNameOrLastName(string filter)
        {
            if(filter == "")
            {
                return GetAllUsers();
            }

            var filters = filter.Split(' ').ToList();

            filters.ForEach(f => f = f.ToLower());
            if(filters.Count == 1)
            {
                filters.Add("");
            }


            return GetAllUsers()
                  .Where(u => u.Name.ToLower().Contains(filters[0])
                  && u.LastName.ToLower().Contains(filters[1])
                  || u.Name.ToLower().Contains(filters[1])
                  && u.LastName.ToLower().Contains(filters[0]));
        }

        public IEnumerable<User> GetUsersMoreThan3Books()
        {
            return GetAllUsers().Where(u => u.Lendings.Count() >= 3);
        }
    }
}
