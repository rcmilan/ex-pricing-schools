namespace app.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class ScopedAttribute : Attribute
    {
    }
}
