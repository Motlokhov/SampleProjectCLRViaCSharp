using ExternalAccessLibliary;

namespace FriendlyAccessLibliary
{
    /// <summary>
    /// Intrnal class ExternalInheritedPublicClass стал доступен благодаря FriendlyAssembly
    /// </summary>
    internal class ExternalAccessClass: ExternalInheritedPublicClass
    {
        public ExternalAccessClass()
        {
            this.PublicMember = "OK";
            this._protectedInternalMember = "OK";
            this._protectedMember = "OK";
        }

    }
}
