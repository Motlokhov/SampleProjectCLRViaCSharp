namespace AccessLibliary
{
    /// <summary>
    /// Публичный класс: доступен всем сборкам снаружи
    /// </summary>
    public class ClassForInheritance
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
                var publicClass = new ClassForInheritance();
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
    /// Наследуемый класс
    /// </summary>
    internal class InheritedClass : ClassForInheritance
    {
        InheritedClass()
        {
            PublicMember = "Access OK";
            _internalMember = "Access OK";
            _protectedMember = "Access OK";
            _protectedInternalMember = "Access OK";
            _privateProtectedMember = "Access OK";

            //_privateMember = "Access False"; доступен только внутри класса
        }
    }

    /// <summary>
    /// Класс описания доступа к членам разных областей видимости снаружи 
    /// </summary>
    internal class AccessToMember
    {
        public void Access(ClassForInheritance publicClass)
        {
            publicClass.PublicMember = "Access OK";
            publicClass._internalMember = "Access OK"; //Внутри сборки
            publicClass._protectedInternalMember = "Access OK"; //Внутри сборки

            //publicClass._protectedMember = "Access False"; доступен только внутри класса
            //publicClass._privateMember = "Access False"; доступен только внутри класса
            //publicClass._privateProtectedMember = "Access False"; доступен только внутри класса
        }

        public void Access(InheritedClass inheritedClass)
        {
            inheritedClass.PublicMember = "Access OK";
            inheritedClass._internalMember = "Access OK"; //Наследует ClassForInheritance
            inheritedClass._protectedInternalMember = "Access OK"; //Наследует ClassForInheritance

            //inheritedClass._protectedMember = "Access False"; доступен только внутри класса
            //inheritedClass._privateProtectedMember = "Access False"; доступен только внутри класса
            //inheritedClass._privateMember = "Access False"; доступен только внутри класса
        }
    }

}
