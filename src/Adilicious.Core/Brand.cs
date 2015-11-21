namespace Adilicious.Core
{
    using System;

    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Brand(int id, string name)
        {
            const string nameParamName = "name";

            if (name == null)
            {
                throw new ArgumentNullException(nameParamName);
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("Cannot be empty", nameParamName);
            }

            Id = id;
            Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Id.GetHashCode();
        }
    }
}