using Dapper;
using System.Linq;
using user_service_v1.Database.Interfaces;
using user_service_v1.Models;
using user_service_v1.Repositories.Interfaces;

namespace user_service_v1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> InsertUser(User user)
        {
            var result = -1;
            var sql = @" /* PetStore.User.Api */
insert into users.user (id, username, firstname, lastname, email, passwordhash, salt, phone, status, created, createdby) 
values (@id, @username, @firstname, @lastname, @email, @passwordhash, @salt, @phone, @status, current_timestamp, 'PetStore.User.Api');";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    result = await _connection.ExecuteAsync(sql, user);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }

                return user.Id;
            }
        }

        public async Task<User> GetUser(string username)
        {
            var result = new User();
            var sql = @"select u.id, u.username, u.status, u.firstname, u.lastname, u.email, u.phone, u.PasswordHash, u.salt
                        from users.user u
                        where u.IsDelete = false
                        and u.UserName = @UserName";

            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    result = await _connection.QuerySingleAsync<User>(sql, new { username });
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }

                return result;
            }

        }

        public async Task UpdateUser(User user)
        {
            var sql = @"update users.user set
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Email = @Email,
                        PasswordHash = @PasswordHash,
                        Salt = @Salt,
                        Phone = @Phone,                      
                        Status = @Status,
                        Modified = current_timestamp,
                        ModifiedBy = 'PetStore.User.Api'
                        where UserName = @UserName";


            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    await _connection.ExecuteAsync(sql, user);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public async Task DeleteUser(string username)
        {
            var sql = @" /* PetStore.User.Api */
delete from users.user where id = @Id"; ;


            using (var _connection = _connectionFactory.CreateDBConnection())
            {
                _connection.Open();

                try
                {
                    await _connection.ExecuteAsync(sql, new { username });
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
    }
}
