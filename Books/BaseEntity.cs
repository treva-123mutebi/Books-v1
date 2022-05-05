using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Books
{
    public class BaseEntity : TableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
