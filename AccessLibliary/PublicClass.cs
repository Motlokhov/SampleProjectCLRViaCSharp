namespace AccessLibliary
{
    /// <summary>
    /// Публичный класс: доступен всем сборкам снаружи
    /// </summary>
    public class PublicClass
    {
        /// <summary>
        /// Доступен всем кому виден класс
        /// </summary>
        public string PublicMember = "public";
        /// <summary>
        /// Доступен только внутри класса включая вложенные классы
        /// </summary>
        private string _privateMember = "private";
        /// <summary>
        /// Доступен внутри класса и всем кто наследует этот класс.
        /// </summary>
        protected string _protectedMember = "protected";
        /// <summary>
        /// Доступен всем внутри текущей сборки
        /// </summary>
        internal string _internalMember = "internal";
        /// <summary>
        /// Доступен всем внутри текущей сборки и тем, кто наследует данный класс.
        /// </summary>
        protected internal string _protectedInternalMember = "protected internal";
        /// <summary>
        /// Доступен только наследуемым классам внутри текущей сборки
        /// </summary>
        private protected string _privateProtectedMember = "private protected";


        class NestedClassOfPublic
        {
            NestedClassOfPublic()
            {
                var publicClass = new PublicClass();
                publicClass.PublicMember = "Access OK";
                publicClass._internalMember = "Access OK";
                publicClass._privateMember = "Access OK";
                publicClass._privateProtectedMember = "Access OK";
                publicClass._protectedMember = "Access OK";
                publicClass._protectedInternalMember = "Access OK";
            }
        }

    }

    /// <summary>
    /// Класс описания доступа к членам разных областей видимости
    /// </summary>
    public class AccessToMember: PublicClass
    {
        public void Access(PublicClass publicClass)
        {
            publicClass.PublicMember = "Access OK";
            publicClass._internalMember = "Access OK";
            publicClass._protectedInternalMember = "Access OK";

            //publicClass._protectedMember = "Access False"; Класс не наследует PublicClass
            //publicClass._privateMember = "Access False"; Класс полностью закрыт для всех снаружи
            //publicClass._privateProtectedMember = "Access False"; Класс не наследует PublicClass
        }
    }

}
