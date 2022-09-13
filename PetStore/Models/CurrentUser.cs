namespace PetStore.Models
{
    public class CurrentUser
    {
        public string UserName { get; set; }
        public int UserRank { get; set; }

        private static CurrentUser instance = new CurrentUser();
        private CurrentUser() { }
        public static CurrentUser Instance
        {
            get { return instance; }
        }
            
   
    }
}
