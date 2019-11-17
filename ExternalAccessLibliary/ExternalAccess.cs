using AccessLibliary;

namespace ExternalAccessLibliary
{
    /// <summary>
    /// Внешний не наследующий класс
    /// </summary>
    internal class ExternalAccess
    {
        public void Access(ClassForInheritance @class)
        {
            @class.PublicMember = "Access OK";

            //class._internalMember = "Access False"; Доступен внутри сборки AccessLibliary
            //class._protectedInternalMember = "Access False"; Доступен внутри сборки AccessLibliary
            //class._privateMember = "Access False"; Доступен внутри класса ClassForInheritance
            //class._privateProtectedMember = "Access False"; Доступен внутри сборки AccessLibliary наследуемым классам
            //class._protectedMember = "Access False"; Доступен внутри сборки AccessLibliary

        }
    }

    /// <summary>
    /// Внешний наследующий класс
    /// </summary>
    internal class ExternalInheritedPublicClass:ClassForInheritance
    {
        ExternalInheritedPublicClass()
        {
            PublicMember = "Access OK";
            _protectedMember = "Access OK";
            _protectedInternalMember = "Access OK";

            //_privateMember = "Access False"; Доступен внутри класса ClassForInheritance
            //_privateProtectedMember = "Access False"; Доступен внутри сборки AccessLibliary наследуемым классам
            //_internalMember = "Access False"; Доступен внутри сборки AccessLibliary
        }
    }
}
