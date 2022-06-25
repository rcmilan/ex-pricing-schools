namespace app.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ScopedLifetimeAttribute : Attribute
    {
    }
}