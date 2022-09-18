namespace Katalyst_TDD_Starter.UserValidation
{
    internal class Name
    {
        private string name;

        public Name(string name)
        {
            this.name = name;
        }

        internal bool IsValid()
        {
            return name.Length > 0;
        }
    }
}
