namespace dkwebapp.api.models
{
    public class usermaster
    {
        public int id { get; set; }
        public string username { get; set; }

        public byte[] passwordhash { get; set; }

        public byte[] passwordsalt { get; set; }
    }
}