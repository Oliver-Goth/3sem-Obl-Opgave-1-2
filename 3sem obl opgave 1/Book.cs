namespace _3sem_obl_opgave_1
{
    public class Book
    {
        public int _id;
        public string _title;
        public decimal _price;

        public void ValidateTitle()
        {
            if (_title == null)
                throw new ArgumentNullException("Title cannot be empty");
            if (_title.Length<3)
                throw new ArgumentException("Title must be minnimum 3 characters");
        }

        public void ValidatePrice()
        {
            if (_price <= 0)
                throw new ArgumentException("Price must be higher than 0");
            if (_price > 1200)
                throw new ArgumentException("Price must be lesser or te same as 1200");
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();

        }
        
        public override string ToString()
        {
            return $"Book(Id, Title, Price)";
        }
    }
}