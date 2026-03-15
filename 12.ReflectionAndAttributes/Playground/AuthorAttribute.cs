namespace Playground
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute()
        {

        }

        public string Name
        {
            get; set;
        }
    }
}
