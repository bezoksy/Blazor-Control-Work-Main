using MongoDB.Bson.Serialization;
using MongoDB.Driver;
namespace AuntOnBlazor.Data
{
    public class UserToDB
    {
        public User currentUser { get; set; }
        private IMongoCollection<User> _users;

        public UserToDB()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var dataBase = client.GetDatabase("Users");
            _users = dataBase.GetCollection<User>("Users");
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }
    }
}
