namespace MVCHamburgerciOtomasyonu.Web.ResultMessages
{
    
    public static class Messages
	{
		public static class Menu
		{
			public static string Add(string menuName)
			{
				return $"{menuName} The menu titled has been added successfully.";
			}
			public static string Update(string menuName)
			{
				return $"{menuName} The menu titled has been updated successfully.";
			}
			public static string Delete(string menuName)
			{
				return $"{menuName} The menu titled has been deleted successfully.";
			}
			public static string UndoDelete(string menuName)
			{
				return $"{menuName} The menu titled has been undedeleted successfully.";
			}
		}
        public static class Message
        {
            public static string Send(string messageName)
            {
                return $"{messageName} The message titled has been added successfully.";
            }
            
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} The user with the email address has been added successfully.";
            }
            public static string Update(string userName)
            {
                return $"{userName} The user with the email address has been updated successfully..";
            }
            public static string Delete(string userName)
            {
                return $"{userName} The user with the email address has been deleted successfully.";
            }
        }
        public static class MenuSize
        {
            public static string Add(string menuSizeName)
            {
                return $"{menuSizeName} The titled menu dimension has been added successfully.";
            }
            public static string Update(string menuSizeName)
            {
                return $"{menuSizeName} The titled menu dimension has been updated successfully.";
            }
            public static string Delete(string menuSizeName)
            {
                return $"{menuSizeName} The titled menu dimension has been deleted successfully.";
            }
            public static string UndoDelete(string menuSizeName)
            {
                return $"{menuSizeName} The titled menu dimension has been undodeleted successfully.";
            }
        }
        public static class Extra
        {
            public static string Add(string extraName)
            {
                return $"{extraName} The extra titled has been added successfully.";
            }
            public static string Update(string extraName)
            {
                return $"{extraName} The extra titled has been updated successfully.";
            }
            public static string Delete(string extraName)
            {
                return $"{extraName} The extra titled has been deleted successfully.";
            }
            public static string UndoDelete(string extraName)
            {
                return $"{extraName} The extra titled has been undodeleted successfully.";
            }
        }
    }

}