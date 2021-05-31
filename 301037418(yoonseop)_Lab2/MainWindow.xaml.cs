using System.Windows;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using _301037418_yoonseop__Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Controls;

namespace _301037418_yoonseop__Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string accessKey = "AKIAVGK3U2NUBRNMBIPA";
        private const string secretKey = "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";
        AmazonDynamoDBClient client;
        DynamoDBContext context;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void CreateTable(string tableName, string hashKey)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);

            var tableResponse = client.ListTables();
            if (!tableResponse.TableNames.Contains(tableName))
            {
                MessageBox.Show("Table not found, creating table => " + tableName);
                client.CreateTable(new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = hashKey,
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = hashKey, AttributeType=ScalarAttributeType.S }
                    }
                });

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    Console.WriteLine("Waiting for table to be active...");
                    Thread.Sleep(5000);
                    var tableStatus = client.DescribeTable(tableName);
                    isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                }
                MessageBox.Show("DynamoDB Table Created Successfully!");
            }
        }


        private void getBookListButton_Click(object sender, RoutedEventArgs e)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);

            Table bookshelfTable = Table.LoadTable(client, "bookshelf");

            ScanFilter scanFilter = new ScanFilter();
            //scanFilter.AddCondition("isActive", ScanOperator.Equal, 1);

            Search search = bookshelfTable.Scan(scanFilter);

            List<Document> documentList = new List<Document>();

            List<bookshelf> bookshelfs = new List<bookshelf>();

            documentList = search.GetNextSet();
            foreach (var document in documentList)
            {
                string isbn = string.Empty;
                string author1 = string.Empty;
                string author2 = string.Empty;
                string author3 = string.Empty;
                string title = string.Empty;
                foreach (string attribute in document.GetAttributeNames())
                {
                    string stringValue = null;
                    var value = document[attribute];
                    if (value is Primitive)
                        stringValue = value.AsPrimitive().Value.ToString();
                    else if (value is PrimitiveList)
                        stringValue = string.Join(",", (from primitive
                                        in value.AsPrimitiveList().Entries

                                                        select primitive.Value).ToArray());
                    if (attribute == "ISBN")
                    {
                        isbn = stringValue;
                    }
                    else if (attribute == "Author1")
                    {
                        author1 = stringValue;
                    }
                    else if (attribute == "Author2")
                    {
                        author2 = stringValue;
                    }
                    else if (attribute == "Author3")
                    {
                        author3 = stringValue;
                    }
                    else if (attribute == "Title")
                    {
                        title = stringValue;
                    }


                }
                bookshelfs.Add(new bookshelf() { ISBN = isbn, Author1 = author1, Author2 = author2, Author3 = author3, Title = title });
            }
            DataGrid.ItemsSource = bookshelfs;
        }

        private void createTableButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTable("bookshelf", "ISBN");
            CreateTable("snapshot", "PageNum");
        }

        private void addSnapsnotButton_Click(object sender, RoutedEventArgs e)
        {

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
            //Set a local DB context
            context = new DynamoDBContext(client);

            Random rnd = new Random();
            int randNum = rnd.Next(0, 200);

            //Create an Student object to save
            snapshot currentState = new snapshot
            {
                PageNum = randNum.ToString(),
                emailAddress = emailTextbox.Text,
                timestamp = $"{DateTime.Now}"
            };

            //Save an Student object
            context.Save<snapshot>(currentState);

            MessageBox.Show("Student snapshot Inserted Successfully!");
        }

        private void displaySnapShotButton_Click_(object sender, RoutedEventArgs e)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
            context = new DynamoDBContext(client);

            Table bookshelfTable = Table.LoadTable(client, "snapshot");

            ScanFilter scanFilter = new ScanFilter();
            //scanFilter.AddCondition("isActive", ScanOperator.Equal, 1);

            Search search = bookshelfTable.Scan(scanFilter);
            List<Document> documentList = new List<Document>();

            List<bookshelf> bookshelfs = new List<bookshelf>();

            documentList = search.GetNextSet();

            string pagenNumber = string.Empty;
            string email = string.Empty;
            string time = string.Empty;

            foreach (var document in documentList)
            {

                foreach (string attribute in document.GetAttributeNames())
                {
                    string stringValue = null;
                    var value = document[attribute];
                    if (value is Primitive)
                        stringValue = value.AsPrimitive().Value.ToString();
                    else if (value is PrimitiveList)
                        stringValue = string.Join(",", (from primitive
                                        in value.AsPrimitiveList().Entries

                                                        select primitive.Value).ToArray());


                    if (attribute == "PageNum")
                    {
                        pagenNumber = stringValue;
                    }
                    else if (attribute == "emailAddress")
                    {
                        email = stringValue;


                    }
                    else if (attribute == "timestamp")
                    {
                        time = $"{DateTime.Now.Date}";
                    }


                }
                if (emailTextbox.Text == email)
                    MessageBox.Show($"your page Number is saved as {pagenNumber}, at {time} , {email}");
            }


        }

        private void addToMyBookshelfButton_Click(object sender, RoutedEventArgs e)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
            //Set a local DB context
            context = new DynamoDBContext(client);

            //Create an Student object to save
            bookshelf currentState = new bookshelf
            {
                ISBN = ISBNTextbox.Text,
                Author1 = Author1Textbox.Text,
                Author2 = Author2Textbox.Text,
                Author3 = Author3Textbox.Text,
                Title = TitleTextbox.Text
            };

            //Save an Student object
            context.Save<bookshelf>(currentState);

            MessageBox.Show("Student Record Inserted Successfully!");
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            ISBNTextbox.Text = string.Empty;
            Author1Textbox.Text = string.Empty;
            Author2Textbox.Text = string.Empty;
            Author3Textbox.Text = string.Empty;
            TitleTextbox.Text = string.Empty;
        }


    }
}
