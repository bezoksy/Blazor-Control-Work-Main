using MongoDB.Bson.Serialization;
using MongoDB.Driver;
namespace AuntOnBlazor.Data
{
    public class UserToDB
    {
        public User currentUser { get; set; }
        private IMongoCollection<User> _users;
        public static IMongoDatabase db = new MongoClient("mongodb://localhost").GetDatabase("DataUser");
        public void AddToDataBase(User user)
        {
            var collection = db.GetCollection<User>("ExCollection");
            _users = db.GetCollection<User>("DataUser");
            collection.InsertOne(user);
        }
        public User AvailableUser(string log, string pas)
        {
            var collection = db.GetCollection<User>("DataUser");
            var unit = collection.Find(x => x.Login == log && x.Password == pas).FirstOrDefault();
            return unit;
            
        }
        
    }
}
