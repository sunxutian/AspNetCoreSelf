namespace AspNetCore.Configuration
{
    public class MyOption
    {
        public MyOption()
        {
            Option = "From Ctor";
            Key = "1";
        }
        public string Option { get; set; }
        public string Key { get; set; }
    }
}