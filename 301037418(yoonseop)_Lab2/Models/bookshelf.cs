using Amazon.DynamoDBv2.DataModel;

namespace _301037418_yoonseop__Lab2.Models
{

    [DynamoDBTable("bookshelf")]
    public class bookshelf
    {
        public string ISBN { get; set; }
        public string Author1 { get; set; }
        public string Author2 { get; set; }
        public string Author3 { get; set; }
        public string Title { get; set; }
    }
}
