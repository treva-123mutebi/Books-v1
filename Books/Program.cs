using System;
// Azure Storage Namespaces
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Books
{
    class MainClass
    {
        static void Main()
        {
            // Azure Storage Account and Table Service Instances.

            CloudStorageAccount storageAccount;
            CloudTableClient tableClient;

            //Connect to Storage Account.
            storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            // Create the Table 'Book', if it not exists.
            tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Book");
            table.CreateIfNotExistsAsync();

            // Create a Book instance.

            Book book = new Book()
            {
                Author = "Sozi Arthur.",
                BookName = "Gulu Gulu goes to school.",
                Publisher = "Technokrats"
            };
            book.BookId = 1;
            book.RowKey = book.BookId.ToString();
            book.PartitionKey = book.Publisher;
            book.CreatedDate = DateTime.UtcNow;
            book.UpdatedDate = DateTime.UtcNow;

            // Insert and execute operations
            TableOperation insertOperation = TableOperation.Insert(book);
            table.ExecuteAsync(insertOperation);
            Console.ReadLine();



        }
    }
}
