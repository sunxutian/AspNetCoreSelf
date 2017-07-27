namespace AspNetCore.Configuration
{
    public class MyOption
    {
        public MyOption()
        {
            Option1 = "From Ctor";
            Option2 = -1;
        }
        public string Option1 { get; set; }
        public int Option2 { get; set; }
    }
}