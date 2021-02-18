using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMongoDb.Helpers
{
    public static class Constants
    {
        public const string DatabaseName = "usersDB";

        public const string CollectionName_users = "users";
        public const string PersonID_fieldName = "_id";
        public const string PersonFirstName_fieldName = "firstName";
        public const string PersonLastName_fieldName = "lastName";

        public const string CollectionName_address = "address";
        public const string AddressID_fieldName = "_id";
        public const string AddressStreet_fieldName = "street";
        public const string AddressCity_fieldName = "city";
    }
}
