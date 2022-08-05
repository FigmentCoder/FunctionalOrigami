
namespace FunctionalOrigami.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool IsNull(this object @object)
            => @object == null;

        public static bool IsNotNull(this object @object)
            => @object != null;
    }
}