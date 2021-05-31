using Amazon.DynamoDBv2.DataModel;
using System;

namespace _301037418_yoonseop__Lab2.Models
{
    [DynamoDBTable("snapshot")]
    public class snapshot
    {
        public string PageNum { get; set; }
        public string emailAddress { get; set; }
        public string timestamp { get; set; }

    }
}
